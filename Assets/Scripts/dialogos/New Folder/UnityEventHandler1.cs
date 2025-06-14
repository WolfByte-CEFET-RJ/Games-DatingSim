using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UnityEventHandler1 : MonoBehaviour , IPointerDownHandler
{
    public UnityEvent eventHandler;
    public DialogueBase myDialogue;
    
    // ADICIONAR: Para identificar qual opção este botão representa
    public int optionIndex;

    public void OnPointerDown(PointerEventData pointerEventData){
        eventHandler.Invoke();
        
        // ADICIONAR: Processar aumento de afeição ANTES de desativar botões
        ProcessAffectionIncrease();
        
        DialogueManager1.instance.DeactivateAllOptionButtons();

        if(myDialogue != null){
            DialogueManager1.instance.EnqueueDialogue(myDialogue);
        }
    }
    
    // NOVO MÉTODO: Processar aumento de afeição
    private void ProcessAffectionIncrease()
    {
        // Verificar se o diálogo atual é do tipo DialogueOptions
        if(DialogueManager1.instance.currentDialogue is DialogueOptions1)
        {
            DialogueOptions1 options = DialogueManager1.instance.currentDialogue as DialogueOptions1;
            
            // Verificar se o índice da opção é válido
            if(optionIndex >= 0 && optionIndex < options.optionsInfo.Length)
            {
                var selectedOption = options.optionsInfo[optionIndex];
                
                // Verificar se esta opção aumenta afeição
                if(selectedOption.increasesAffection && selectedOption.targetCharacter != null)
                {
                    selectedOption.targetCharacter.aumentoAfeto();
                    
                }
            }
        }
    }
}
