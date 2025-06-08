using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Profile", menuName = "Character Profile")]
public class CharacterProfile : ScriptableObject
{
    public string myName;
    private Sprite myPortrait;

    public float afeto;

    
   


    public Sprite MyPortrait
    {
        get
        {
            SetEmotionType(Emotion);
            return myPortrait;
        }
    }

    [System.Serializable]
    public class EmotionPortraits
    {
        public Sprite neutro;
        public Sprite feliz;
        public Sprite raiva;
    }

    public EmotionPortraits emotionPortraits;

    public EmotionType Emotion { get; set; }

    public void SetEmotionType(EmotionType newEmotion)
    {
        Emotion = newEmotion;
        switch (Emotion)
        {
            case EmotionType.Neutro:
                myPortrait = emotionPortraits.neutro;
                break;
            case EmotionType.Feliz:
                myPortrait = emotionPortraits.feliz;
                break;
            case EmotionType.Raiva:
                myPortrait = emotionPortraits.raiva;
                break;
        }
    }
        public void aumentoAfeto()
        {
            afeto += 0.1f;
        }
    

    public enum EmotionType
    {
        Neutro,
        Feliz,
        Raiva
    }
}
