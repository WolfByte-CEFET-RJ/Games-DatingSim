using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueButton : MonoBehaviour
{
    [SerializeField] public string dialogueManagerID = "default"; // Especifica qual manager usar
    
    public void GetNextLine()
    {
        DialogueManager manager = DialogueManager.GetInstance(dialogueManagerID);
        if (manager != null)
        {
            manager.DequeueDialogue();
        }
        else
        {
            Debug.LogWarning($"DialogueManager com ID '{dialogueManagerID}' não encontrado!");
        }
    }
}
