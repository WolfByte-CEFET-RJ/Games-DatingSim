using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript1 : MonoBehaviour
{
   public DialogueBase dialogue;
    [SerializeField] public string dialogueManagerID1 = "default1"; // Especifica qual manager usar

    public void TriggerDialogue1()
    {
        DialogueManager1 manager = DialogueManager1.GetInstance(dialogueManagerID1);
        if (manager != null)
        {
            manager.EnqueueDialogue(dialogue);
        }
    }
    void Start()
    {
        TriggerDialogue1();
        
    }
}