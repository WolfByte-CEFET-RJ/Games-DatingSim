using UnityEngine;
using UnityEngine.UI;

public class SpeakerUIController : MonoBehaviour
{
    public Sprite portrait;
    public Text name;
    public Text dialog;
    //public Mood mood;

    private CharacterItem speaker;
    public CharacterItem Speaker {
        get { return speaker; }
        set {
            speaker = value;
            // portrait.sprite = speaker.portrait;
            name.text = speaker.name;
        }
    }
    
    public string Dialog
    {
        get { return dialog.text; }
        set { dialog.text = value; }
    }

 

    public bool HasSpeaker()
    {
        return speaker != null;
    }

    public bool SpeakerIs(CharacterItem character)
    {
        return speaker == character;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
