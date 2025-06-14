using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueButton1 : MonoBehaviour
{
    [SerializeField] public string dialogueManagerID1 = "default1"; // Especifica qual manager usar
    
    public void GetNextLine()
    {
        DialogueManager1 manager = DialogueManager1.GetInstance(dialogueManagerID1);
        if (manager != null)
        {
            manager.DequeueDialogue();
        }
        else
        {
            Debug.LogWarning($"DialogueManager com ID '{dialogueManagerID1}' não encontrado!");
        }
    }
}
