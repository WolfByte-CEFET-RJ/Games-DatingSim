using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacterImage", menuName = "Dialogue/CharacterImage")]
public class CharacterItem : ScriptableObject
{
    public Sprite feliz;
    public Sprite normal;

    public Dictionary<string, Sprite> dictImages;

    void OnEnable()
    {
        dictImages = new Dictionary<string, Sprite>()
        {
            {"feliz", feliz},
            {"normal", normal},
        };
    }

    public Sprite getPoseByName(string pose)
    {
        if (dictImages.ContainsKey(pose))
        {
            return dictImages[pose];
        }
        Debug.LogError("Sprite a adicionar nesse dicionário: " + pose);
        return normal;

    }
}
