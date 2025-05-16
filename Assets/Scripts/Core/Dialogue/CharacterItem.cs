using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacterImage", menuName = "Dialogue/CharacterImage")]
public class CharacterItem : ScriptableObject
{
    public Sprite feliz;
    public Sprite normal;
    public Sprite surpresaTriste;
    public Sprite surpresaFeliz;
    public Sprite raiva;
    public Sprite raivaVergonha;
    public Sprite nojo;
    public Sprite desprezo;
    public Sprite confusa;
    public float afeto;
    public Dictionary<string, Sprite> dictImages;

    void OnEnable()
    {
        dictImages = new Dictionary<string, Sprite>()
        {
            {"feliz", feliz},
            {"normal", normal},
            {"surpresaTriste", surpresaTriste},
            {"surpresaFeliz", surpresaFeliz},
            {"raiva", raiva},
            {"raivaVergonha", raivaVergonha},
            {"nojo", nojo},
            {"desprezo", desprezo},
            {"confusa", confusa},
        };
    }

    public Sprite getPoseByName(string pose)
    {
        if (dictImages.ContainsKey(pose))
        {
            return dictImages[pose];
        }
        Debug.LogError("Sprite a adicionar nesse dicion�rio: " + pose);
        return normal;

    }

    public void aumentoAfeto()
    {
        afeto += 0.1f;
    }
}
