using UnityEngine;
using UnityEngine.UI;

//public enum Mood {
    // TODO: Ver se dá pra transferir os moods de CharacterItem Para cá ou então colocar as imagens de cada mood em CharacterItem
    //Neutral,
    //Angry
//}

[System.Serializable]
public struct Line
{
    public CharacterItem character;

    [TextArea(2, 5)]
    public string text;
    //public Mood mood;
}

[CreateAssetMenu(fileName = "New Conversation", menuName = "Conversation")]
public class Conversation : ScriptableObject
{
    public CharacterItem speakerLeft;
    public CharacterItem speakerRight;
    public Line[] lines;
    public Question question;
    public Conversation nextConversation;
}