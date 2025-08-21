using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Para exibir o texto no canvas

public class GameTimer : MonoBehaviour
{

    [Header("Timer Settings")]
    [SerializeField] private float startTime;
    [SerializeField] private TextMeshProUGUI timerText; // Referência ao texto no Canvas

    private float currentTime; //Tempo atual do timer
    private bool isRunning = true; //Controla se timer está rodando

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
        UpdateTimerUI();
    }

    // Update is called once per frame
    void Update()
    {
        if(isRunning){
            currentTime -= Time.deltaTime;
            if(currentTime <= 0){
                currentTime = 0;
                isRunning = false;
                OnTimerEnd();
            }
            UpdateTimerUI();
        }
    }

    void UpdateTimerUI(){
        //convertendo tempo para minutos e segundos
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        int miliseconds = Mathf.FloorToInt((currentTime - Mathf.Floor(currentTime)) * 100); // Pega a parte decimal do tempo e converte em milissegundos

        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, miliseconds);
    }

    void OnTimerEnd(){
        Debug.Log("Timer acabou!");
    }

    public void PauseTimer(bool pause){
        isRunning = !pause;
    }
}
