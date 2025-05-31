using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
   public DialogueBase dialogue;
    [SerializeField] public string dialogueManagerID = "default"; // Especifica qual manager usar

    public void TriggerDialogue()
    {
        DialogueManager manager = DialogueManager.GetInstance(dialogueManagerID);
        if (manager != null)
        {
            manager.EnqueueDialogue(dialogue);
        }
    }
    void Start()
    {
        TriggerDialogue();
        
    }
}