using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UnityEventHandler : MonoBehaviour , IPointerDownHandler
{
    public UnityEvent eventHandler;
    public DialogueBase myDialogue;

    public void OnPointerDown(PointerEventData pointerEventData){
        eventHandler.Invoke();
        DialogueManager.instance.DeactivateAllOptionButtons();

        if(myDialogue != null){
            DialogueManager.instance.EnqueueDialogue(myDialogue);
        }
    }
}
