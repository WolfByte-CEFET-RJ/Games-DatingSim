using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
   private static Dictionary<string, DialogueManager> instances = new Dictionary<string, DialogueManager>();

    [SerializeField]
    public string managerID = "default"; 
    
    private void Awake()
    {
        if (!instances.ContainsKey(managerID))
        {
            instances[managerID] = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    
    public static DialogueManager GetInstance(string id = "default")
    {
        return instances.ContainsKey(id) ? instances[id] : null;
    }
    
    public static DialogueManager instance => GetInstance();

    public GameObject dialogueBox;
    public GameObject dialogueOptionUI;
    public GameObject[] optionButtons;

    public TextMeshProUGUI dialogueName;
    public TextMeshProUGUI dialogueText;

    public Image[] characterPortraits;


    public float delay = 0.001f;
    private bool isDialogueOption;
    private bool isCurrentlyTyping;
    private int optionsAmount;
    public Text questionText;

    public Transform nameHolder;
    public DialogueBase currentDialogue;


    public Queue<DialogueBase.Info> dialogueInfo; // FIFO Collection

    private void Start()
    {
        dialogueInfo = new Queue<DialogueBase.Info>();
    }

    public void EnqueueDialogue(DialogueBase db)
    {

        if (isCurrentlyTyping)
        {
            return;
        }
        else
        {
            isCurrentlyTyping = true;
        }

        currentDialogue = db;

        dialogueBox.SetActive(true);
        dialogueInfo.Clear();
        SetCharacterPortraits(db);

        if (db is DialogueOptions)
        {
            isDialogueOption = true;
            DialogueOptions dialogueOptions = db as DialogueOptions;
            optionsAmount = dialogueOptions.optionsInfo.Length;
            questionText.text = dialogueOptions.questionText;
          for (int i = 0; i < optionsAmount; i++)
                {
                    optionButtons[i].SetActive(true);
                    optionButtons[i].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = dialogueOptions.optionsInfo[i].buttonName;
                    UnityEventHandler myEventHandler = optionButtons[i].GetComponent<UnityEventHandler>();
                    myEventHandler.eventHandler = dialogueOptions.optionsInfo[i].myEvent;
                    
                    myEventHandler.optionIndex = i;
                    
                    if (dialogueOptions.optionsInfo[i].nextDialogue != null)
                    {
                        myEventHandler.myDialogue = dialogueOptions.optionsInfo[i].nextDialogue;
                    }
                    else
                    {
                        myEventHandler.myDialogue = null;
                    }
                }
        }
        else
        {
            isDialogueOption = false;
        }


        foreach (DialogueBase.Info info in db.dialogueInfo)
        {
            dialogueInfo.Enqueue(info);
        }

        DequeueDialogue();
    }

    public void DequeueDialogue()
    {
        if (dialogueInfo.Count == 0)
        {
            EndOfDialogue();
            return;
        }

        DialogueBase.Info info = dialogueInfo.Dequeue();


        nameHolder.position = characterPortraits[GetCurrentCharacterIndex(info)].gameObject.transform.position - new Vector3(0, 0);
        dialogueName.text = info.character.myName;
        dialogueText.text = info.myText;
        info.ChangeEmotion();
        //dialoguePortrait.sprite = info.character.MyPortrait;
        characterPortraits[GetCurrentCharacterIndex(info)].sprite = info.character.MyPortrait;
        DarkenOtherPortraits(info);

        StartCoroutine(TypeText(info));
    }


    private void DarkenOtherPortraits(DialogueBase.Info info)
    {
        for (int i = 0; i < characterPortraits.Length; i++)
        {
            if (i == GetCurrentCharacterIndex(info)) // this character is talking
            {
                characterPortraits[i].color = hexToColor("FFFFFF");
                characterPortraits[i].rectTransform.localScale = new Vector3(1.1f, 1.1f);
                //mudar tamanho dos personagens quando falando, cuidado com a resolução
            }
            else // this character is not talking
            {
                characterPortraits[i].color = hexToColor("9F9F9F");
                characterPortraits[i].rectTransform.localScale = new Vector3(1, 1);
            }
        }
    }



    private int GetCurrentCharacterIndex(DialogueBase.Info info)
    {
        for (int i = 0; i < currentDialogue.characters.Length; i++)
        {
            if (info.character == currentDialogue.characters[i])
            {
                return i;
            }
        }

        Debug.Log("Error! Character is not in the list!");
        return 0;
    }



    private void SetCharacterPortraits(DialogueBase db)
    {
        for (int i = 0; i < characterPortraits.Length; i++)
        {
            characterPortraits[i].sprite = db.characters[i].emotionPortraits.neutro;
        }
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DequeueDialogue();
        }
    }

    IEnumerator TypeText(DialogueBase.Info info)
    {
        dialogueText.text = "";
        foreach (char c in info.myText.ToCharArray())
        {
            yield return new WaitForSeconds(delay);
            dialogueText.text += c;
            yield return null;
        }
    }

    public void EndOfDialogue()
    {
        //eventualmente quando formos pra proxima cena ela será chamada aqui
        dialogueBox.SetActive(false);
        OptionInfo();
    }

    public void DeactivateAllOptionButtons()
    {
        dialogueOptionUI.SetActive(false);
    }

    private void OptionInfo()
    {
        if (isDialogueOption)
        {
            dialogueOptionUI.SetActive(true);
        }
        isCurrentlyTyping = false;

    }


    
    public Color hexToColor(string hex)
    {
        hex = hex.Replace("0x", ""); // In case the string is formatted 0xFFFFFF
        hex = hex.Replace("#", "");  // In case the string is formatted #FFFFFF
        byte a = 255; // Assume fully visible unless specified in hex
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

        // Only use alpha if the string has enough characters
        if (hex.Length == 8)
        {
            a = byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
        }

        return new Color32(r, g, b, a);
    }
}