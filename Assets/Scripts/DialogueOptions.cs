using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "DialogueOptions", menuName = "Dialogue System/Dialogue Options")]
public class DialogueOptions : DialogueBase
{
    [System.Serializable]
    public class Options{
        public string buttonName;
        public UnityEvent myEvent;
        public DialogueBase nextDialogue;
    }
    public Options[] optionsInfo;

    [TextArea(2, 5)]
    public string questionText;

}