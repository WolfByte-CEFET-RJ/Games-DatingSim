using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SearchingWord : MonoBehaviour
{
    public Text displayedText;
    public Image crossLine;
    private int wordsToFind;
    private string _word;
   
    void Start()
    {
        wordsToFind = GameObject.FindWithTag("WordGrid").GetComponent<WordGrid>().currentGameData.selectedBoardData.SearchWords.Count;
        Debug.Log("Faltam: " + wordsToFind);

    }

    private void OnEnable()
    {
        GameEvents.OnCorrectWord += CorrectWord;
    }

    private void OnDisable()
    {
        GameEvents.OnCorrectWord -= CorrectWord;
    }

    public void SetWord(string word)
    {
        _word = word;
        displayedText.text = word;
    }

    private void CorrectWord(string word, List<int> squareIndexes)
    {
        if (word == _word)
        {
            crossLine.gameObject.SetActive(true);
            GameObject endGameObject = GameObject.Find("Timer");

            if (endGameObject != null)
            {
                // Obtém o componente EndGameScript
                EndGameScript endGameScript = endGameObject.GetComponent<EndGameScript>();

                if (endGameScript != null)
                {
                    endGameScript.setWordsFinded(); // Chama o método
                }
                else
                {
                    Debug.LogError("EndGameScript não encontrado no GameObject!");
                }
            }
            else
            {
                Debug.LogError("GameObject com o nome especificado não encontrado!");
            }
        }
    }
}