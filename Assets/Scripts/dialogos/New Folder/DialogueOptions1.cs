using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "DialogueOptions1", menuName = "Dialogue System/Dialogue Options1")]
public class DialogueOptions1 : DialogueBase
{
    [System.Serializable]
    public class Options
    {
        public string buttonName;
        public UnityEvent myEvent;
        public DialogueBase nextDialogue;
        
        public bool increasesAffection = false;
        public CharacterProfile targetCharacter;
    }
    public Options[] optionsInfo;

    [TextArea(4, 5)]
    public string questionText;

}