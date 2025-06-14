using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager1 : MonoBehaviour
{
   private static Dictionary<string, DialogueManager1> instances = new Dictionary<string, DialogueManager1>();

    [SerializeField]
    public string managerID1 = "default1"; 
    
    private void Awake()
    {
        if (!instances.ContainsKey(managerID1))
        {
            instances[managerID1] = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    
    public static DialogueManager1 GetInstance(string id = "default1")
    {
        return instances.ContainsKey(id) ? instances[id] : null;
    }
    
    public static DialogueManager1 instance => GetInstance();

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

    public GameObject root;
    public Button botaodelugar;


    public Queue<DialogueBase.Info> dialogueInfo; // FIFO Collection

    private void Start()
    {
        dialogueInfo = new Queue<DialogueBase.Info>();
    }
    
    private GameObject[] GetAllOptionButtons()
{
    if (dialogueOptionUI == null)
    {
        Debug.LogError("dialogueOptionUI não está configurado!");
        return optionButtons ?? new GameObject[0];
    }
    
    // Busca todos os botões filhos que tenham o componente UnityEventHandler
    UnityEventHandler1[] handlers = dialogueOptionUI.GetComponentsInChildren<UnityEventHandler1>(true);
    GameObject[] foundButtons = new GameObject[handlers.Length];
    
    for (int i = 0; i < handlers.Length; i++)
    {
        foundButtons[i] = handlers[i].gameObject;
    }
    
    Debug.Log($"Encontrados {foundButtons.Length} botões automaticamente");
    return foundButtons;
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

        if (db is DialogueOptions1)
        {
            isDialogueOption = true;
            DialogueOptions1 dialogueOptions = db as DialogueOptions1;

            // Usa busca automática de botões
            GameObject[] currentOptionButtons = GetAllOptionButtons();

            if (dialogueOptions.optionsInfo == null)
            {
                Debug.LogError("optionsInfo é null no DialogueOptions!");
                isCurrentlyTyping = false;
                return;
            }

            optionsAmount = dialogueOptions.optionsInfo.Length;

            if (questionText != null)
            {
                questionText.text = dialogueOptions.questionText ?? "";
            }

            // Primeiro, desativa todos os botões
            for (int i = 0; i < currentOptionButtons.Length; i++)
            {
                if (currentOptionButtons[i] != null)
                {
                    currentOptionButtons[i].SetActive(false);
                }
            }

            // Configura apenas os botões necessários
            int maxButtons = Mathf.Min(optionsAmount, currentOptionButtons.Length);

            for (int i = 0; i < maxButtons; i++)
            {
                if (currentOptionButtons[i] == null)
                {
                    Debug.LogWarning($"Botão {i} é null!");
                    continue;
                }

                if (dialogueOptions.optionsInfo[i] == null)
                {
                    Debug.LogWarning($"optionsInfo[{i}] é null!");
                    continue;
                }

                // Ativa o botão
                currentOptionButtons[i].SetActive(true);

                // Configura o texto do botão
                Transform childTransform = currentOptionButtons[i].transform.GetChild(0);
                if (childTransform != null)
                {
                    TextMeshProUGUI buttonText = childTransform.GetComponent<TextMeshProUGUI>();
                    if (buttonText != null)
                    {
                        buttonText.text = dialogueOptions.optionsInfo[i].buttonName ?? $"Opção {i + 1}";
                    }
                    else
                    {
                        Debug.LogWarning($"TextMeshProUGUI não encontrado no botão {i}!");
                    }
                }

                // Configura o UnityEventHandler
                UnityEventHandler1 myEventHandler = currentOptionButtons[i].GetComponent<UnityEventHandler1>();
                if (myEventHandler != null)
                {
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
                else
                {
                    Debug.LogWarning($"UnityEventHandler não encontrado no botão {i}!");
                }
            }

            // Avisa se há mais opções do que botões disponíveis
            if (optionsAmount > currentOptionButtons.Length)
            {
                Debug.LogWarning($"Há {optionsAmount} opções, mas apenas {currentOptionButtons.Length} botões disponíveis!");
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
            if (optionsAmount == 0)
            {
                root.SetActive(false);
                botaodelugar.interactable = false;

            }

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
                characterPortraits[i].rectTransform.localScale = new Vector3(1.2f, 1.2f);
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