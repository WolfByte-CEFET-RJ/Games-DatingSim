using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharacterProfile;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogues")]
public class DialogueBase : ScriptableObject
{

    [Header("Insert Characters Below")]
    public CharacterProfile[] characters = new CharacterProfile[4];

    [System.Serializable]
    public class Info
    {
        public CharacterProfile character;
        public EmotionType characterEmotion;



        [TextArea(4, 8)]
        public string myText;
        public float delay;


        public void ChangeEmotion()
        {
            character.Emotion = characterEmotion;
        }
    }

    [Header("Insert Dialogue Information Below")]
    public Info[] dialogueInfo;
}
