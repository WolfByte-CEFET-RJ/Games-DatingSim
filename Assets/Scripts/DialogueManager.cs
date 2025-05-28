using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Fix this" + gameObject.name);
        }
        else
        {
            instance = this;
        }
    }

    public GameObject dialogueBox;
    public GameObject dialogueOptionUI;
    public GameObject[] optionButtons;

    public TextMeshProUGUI dialogueName;
    public TextMeshProUGUI dialogueText;
    public Image dialoguePortrait;
    public float delay = 0.001f;
    private bool isDialogueOption;
    private bool isCurrentlyTyping;
    private int optionsAmount;
    public Text questionText;
    

    public Queue<DialogueBase.Info> dialogueInfo; // FIFO Collection

    private void Start()
    {
        dialogueInfo = new Queue<DialogueBase.Info>();
    }

    public void EnqueueDialogue(DialogueBase db)
    {

        if (isCurrentlyTyping){
            return;
        }
        else    
        {
            isCurrentlyTyping = true;
        }
        dialogueBox.SetActive(true);
        dialogueInfo.Clear();

        if(db is DialogueOptions){
            isDialogueOption = true;
            DialogueOptions dialogueOptions = db as DialogueOptions;
            optionsAmount = dialogueOptions.optionsInfo.Length;
            questionText.text = dialogueOptions.questionText;
            for (int i = 0; i < optionsAmount; i++){
                optionButtons[i].SetActive(true);
                optionButtons[i].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = dialogueOptions.optionsInfo[i].buttonName;
                UnityEventHandler myEventHandler = optionButtons[i].GetComponent<UnityEventHandler>();
                myEventHandler.eventHandler = dialogueOptions.optionsInfo[i].myEvent;
                if(dialogueOptions.optionsInfo[i].nextDialogue != null){
                    myEventHandler.myDialogue = dialogueOptions.optionsInfo[i].nextDialogue;
                }
                else{
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

        dialogueName.text = info.myName;
        dialogueText.text = info.myText;
        dialoguePortrait.sprite = info.portrait;

        StartCoroutine(TypeText(info));
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
        dialogueBox.SetActive(false);
        OptionInfo();
    }

    public void DeactivateAllOptionButtons()
    {
       dialogueOptionUI.SetActive(false);
    }

    private void OptionInfo(){
         if(isDialogueOption){
            dialogueOptionUI.SetActive(true);            
        }
        isCurrentlyTyping = false;

    }
}