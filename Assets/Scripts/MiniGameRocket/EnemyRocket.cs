using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyRocket : MonoBehaviour
{
    public Text valueText;
    float progresso = 50;
    public Slider slider;
    public float updateTime = 0.5f; // tempo em segundos para a atualização
    private float timer = 0f;
    public float dificuldade = 1;

    public void OnSliderChanged(float value)
    {
        valueText.text = value.ToString();
    }
    public void UpdateProgress()
    {
        progresso--;
        slider.value = progresso;
    }
    public void Update()
    {
        slider.value = progresso;
        timer += Time.deltaTime;
        if (timer >= updateTime)
        {
            timer -= updateTime;
            if (slider.value >= 0 && slider.value <= 100)
            {
                progresso = (progresso + dificuldade);
                if (dificuldade < 2f)
                { dificuldade = (dificuldade + 0.1f); }
            }
        }

    }

}
