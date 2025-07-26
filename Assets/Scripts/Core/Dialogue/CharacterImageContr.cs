using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterImageContr : MonoBehaviour
{
    public static CharacterImageContr instance;
    [Header("Items")]
    [SerializeField] private CharacterItem socialF;
    [SerializeField] private CharacterItem gestaoM;
    [SerializeField] private CharacterItem botzF;
    Dictionary<string, CharacterItem> dictCharacter;


    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        dictCharacter = new Dictionary<string, CharacterItem>()
        {
            {"Social(F)", socialF},
            {"Gestão(M)", gestaoM},
            {"Botz(F)", botzF},
            {"Narrador", null},
            {"Trainee", null}, 
            //Adicione os outros personagens gradualmente
        };
    }

    public CharacterItem selectCharByName(string name)
    {
        if (dictCharacter.ContainsKey(name))
        {
            return dictCharacter[name];
        }
        return null;
    }

}
