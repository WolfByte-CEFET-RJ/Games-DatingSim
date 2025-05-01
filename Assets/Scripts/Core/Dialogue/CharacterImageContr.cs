using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterImageContr : MonoBehaviour
{
    public static CharacterImageContr instance;
    [Header("Items")]
    [SerializeField] private CharacterItem botzF;
    [SerializeField] private CharacterItem botzM;
    [SerializeField] private CharacterItem byteF;
    [SerializeField] private CharacterItem byteM;
    [SerializeField] private CharacterItem gestaoF;
    [SerializeField] private CharacterItem gestaoM;
    [SerializeField] private CharacterItem marketingF;
    [SerializeField] private CharacterItem marketingM;
    [SerializeField] private CharacterItem powerF;
    [SerializeField] private CharacterItem powerM;
    [SerializeField] private CharacterItem rocketF;
    [SerializeField] private CharacterItem rocketM;
    [SerializeField] private CharacterItem socialF;
    [SerializeField] private CharacterItem socialM;
    [SerializeField] private CharacterItem wieF;
    [SerializeField] private CharacterItem wieM;
    Dictionary<string, CharacterItem> dictCharacter;


    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        dictCharacter = new Dictionary<string, CharacterItem>()
        {
            {"Botz(F)", botzF},
            {"Botz(M)", botzM},
            {"Byte(F)", byteF},
            {"Byte(M)", byteM},
            {"Gest�o(F)", gestaoF},
            {"Gest�o(M)", gestaoM},
            {"Marketing(F)", marketingF},
            {"Marketing(M)", marketingM},
            {"Power(F)", powerF},
            {"Power(M)", powerM},
            {"Rocket(F)", rocketF},
            {"Rocket(M)", rocketM},
            {"Social(F)", socialF},
            {"Social(M)", socialM},
            {"Wie(F)", wieF},
            {"Wie(M)", wieM},
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
