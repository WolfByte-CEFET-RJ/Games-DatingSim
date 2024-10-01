using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using UnityEngine;

public class EndGameScript : MonoBehaviour
{
    public TMP_Text timerText;
    public GameObject victoryPanel;
    public GameObject losePanel;
    public float updateTime = 0.5f; // tempo em segundos para a atualização
    private float timer = 0f;
    public float timeEndGame = 60f;
    private int wordsToFind;
    private int wordsFinded;

    private void Start()
    {
        UpdateTimerText();
        wordsToFind = GameObject.FindWithTag("WordGrid").GetComponent<WordGrid>().currentGameData.selectedBoardData.SearchWords.Count;
        Debug.Log("Faltam: " + wordsToFind);
        wordsFinded = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimerText();
        timer += Time.deltaTime;
        timeEndGame -= Time.deltaTime;
        if (wordsFinded == wordsToFind || timeEndGame < 0f)
        {
            EndGame();
        }
    }

    public void setWordsFinded()
    {
        wordsFinded++;
        Debug.Log("Atualizou!!!!!!! : " + wordsFinded);
    }
    public void EndGame()
    {
        GameObject wordCheckerObject = GameObject.Find("WordsGrid"); // Substitua pelo nome do GameObject

        if (wordCheckerObject != null)
        {
            // Obtém o componente WordChecker
            WordChecker wordChecker = wordCheckerObject.GetComponent<WordChecker>();

            if (wordChecker != null)
            {
                wordChecker.enabled = false; // Chama o método
                Debug.Log("WordChecker desativado.");
            }
            else
            {
                Debug.LogError("WordChecker não encontrado no GameObject!");
            }
        }
        else
        {
            Debug.LogError("GameObject com o nome especificado não encontrado!");
        }

        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Letters");

        foreach (var obj in objectsWithTag)
        {
            // Obtém o componente Collider e desativa o collider
            BoxCollider collider = obj.GetComponent<BoxCollider>();
            if (collider != null)
            {
                collider.enabled = false; // Desativa o collider
                Debug.Log($"Collider desativado: {obj.name}");
            }
        }
        Debug.Log("Todos os Colliders foram desativados.");

        if (wordsToFind == wordsFinded)
        {
            // Ativa o painel de vitória
            if (victoryPanel != null)
            {
                victoryPanel.SetActive(true);
            }
            else
            {
                Debug.Log("Victory! Game Over.");
            }
            // Desativa o script para garantir que não continue atualizando
            this.enabled = false;
        }
        else
        {
            if (losePanel != null)
            {
                losePanel.SetActive(true);
            }
            // Desativa o script para garantir que não continue atualizando
            this.enabled = false;
        }
    }

    void UpdateTimerText()
    {
        // Converte o tempo restante para minutos, segundos e décimos de segundo
        int minutes = Mathf.FloorToInt(timeEndGame / 60);
        int seconds = Mathf.FloorToInt(timeEndGame % 60);
        int hundredths = Mathf.FloorToInt((timeEndGame % 1) * 100);

        // Formata a string de tempo com dois dígitos para minutos, segundos e décimos de segundo
        timerText.text = string.Format("{0:D2}:{1:D2}:{2:D2}", minutes, seconds, hundredths);
    }
}
