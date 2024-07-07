using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class GameData : ScriptableObject
{
    public string selectedCategoryName;
    public List<BoardData> allBoardDatas; // Lista de todos os BoardDatas disponíveis

    [HideInInspector]
    public BoardData selectedBoardData = null; // BoardData selecionado aleatoriamente
    public bool IsGameDataReady = false;
    private int randomIndex = 0;

    public void SelectRandomBoardData()
    {
        if (allBoardDatas != null && allBoardDatas.Count > 0)
        {
            Debug.Log("Index antes:" + randomIndex);
            randomIndex = Random.Range(0, allBoardDatas.Count);
            selectedBoardData = allBoardDatas[randomIndex];
            Debug.Log("Index depois: " + randomIndex);
            IsGameDataReady = true;
        }
        else
        {
            Debug.LogWarning("Lista de BoardDatas está vazia ou nula.");
        }
    }
}
