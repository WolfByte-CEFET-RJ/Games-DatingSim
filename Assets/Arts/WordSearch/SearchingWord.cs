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
        }
    }
}
