using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RocketBar : MonoBehaviour
{
    public TMP_Text valueText;
    float progresso = 50;
    public TMP_Text timerText;
    public Slider slider;
    public float updateTime = 0.5f; // tempo em segundos para a atualização
    private float timer = 0f;
    public float timeEndGame = 60f;
    public float dificuldade = 1.2f;
    public GameObject victoryPanel;
    public GameObject losePanel;
    public Button Botao;
    public MovimentoFundo movimentoFundo;
    public GameObject Spawn;
    GameObject[] planetas = null;
    public GameObject[] rockets;

    private void Start()
    {
        UpdateTimerText();
    }
    public void OnSliderChanged(float value)
    {
        valueText.text = value.ToString();
    }
    public void UpdateProgress()
    {
        if (slider.value > 90 && timeEndGame >35) {
            progresso+= 0.7f;
            slider.value = progresso;
        }
        else if(slider.value <40)
        {
            progresso+= 1.5f;
            slider.value = progresso;
        }
        else
        {
            progresso += 1f;
            slider.value = progresso;
        }
    }
    public void Update()
    {
            UpdateTimerText();
            slider.value = progresso;
            timer += Time.deltaTime;
            timeEndGame -= Time.deltaTime;
            if (timer >= updateTime)
            {
                timer -= updateTime;
                if (slider.value >= 0 && slider.value <= 100)
                {
                    if(progresso > 0)
                        progresso = (progresso - dificuldade);
                    
                    if (dificuldade < 1.5f)
                        dificuldade = (dificuldade + 0.01f);

                    if(dificuldade > 1.5f && dificuldade < 2f)
                        { dificuldade = (dificuldade + 0.005f); }
                }


            }

        if(progresso >= 100 || timeEndGame < 0f)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        planetas = GameObject.FindGameObjectsWithTag("Planetas");
        foreach (GameObject obj in planetas)
        {
            // Obtém o componente MovimentoFundo e desativa o script
            PlanetMoviment movimentoScript = obj.GetComponent<PlanetMoviment>();
            if (movimentoScript != null)
            {
                movimentoScript.setEndOfTheGame();
            }
        }

        foreach(GameObject rocket in rockets)
        {
            MovimentoRocket movimento = rocket.GetComponent<MovimentoRocket>();
            if(movimento != null)
            {
                movimento.setEndOfTheGame();
            }
        }

        Spawner spawner = Spawn.GetComponent<Spawner>();
        if( Spawn != null && spawner != null)
        {
            spawner.enabled = false;
        }
        else
        {
            Debug.Log("Script não encontrado");
        }

        if (progresso >= 100)
        {
            // Ativa o painel de vitória
            if (victoryPanel != null)
            {
                victoryPanel.SetActive(true);
                Botao.interactable = false;
                movimentoFundo.enabled = false;
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
            if(losePanel != null)
            {
                losePanel.SetActive(true);
                Botao.interactable=false;
                movimentoFundo.enabled = false;
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
