using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class SaveData
{
    // Informações que precisam ser salvas
    public int day;
    public string playerName;
    public int affectionPoints;
    public string selectedGender;
    public GameObject selectedDialogueBox;
    public Sprite playerSprite;

    // Construtor com valores padrão para a criação de um novo jogo
    public SaveData()
    {
        this.day = 1;
        this.playerName = null;
        this.affectionPoints = 0;
        this.selectedGender = null;
        this.selectedDialogueBox = null;
        this.playerSprite = null;
    }
}