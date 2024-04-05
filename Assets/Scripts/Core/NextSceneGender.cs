using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSceneGender : MonoBehaviour
{
    private void Start()
    {
        // Acessa informação de gênero guardada no GameManager
        string selectedGender = GameManager.Instance.selectedGender;
        GameObject selectedDialogueBox = GameManager.Instance.selectedDialogueBox;

        // Usa os dados de gênero como necessário
        Debug.Log("Selected gender in next scene: " + selectedGender);
    }
}
