using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barrarosa : MonoBehaviour


{

    // Referência ao componente Slider que será usado como termômetro
    public Slider thermometerSlider;  // Certifique-se de que este campo esteja preenchido no Inspector

    // Valor inicial do termômetro (entre 0 e 10)
    [Range(0, 10)]
    public int initialValue = 5;

    void Start()
    {
        // Configura o valor inicial do termômetro
        SetThermometerValue(initialValue);
    }

    // Função para alterar o valor do termômetro
    public void SetThermometerValue(int value)
    {
        // Verificar se a referência ao Slider é nula antes de usá-la
        if (thermometerSlider != null)
        {
            // Limita o valor para garantir que esteja dentro do intervalo do Slider
            thermometerSlider.value = Mathf.Clamp(value, thermometerSlider.minValue, thermometerSlider.maxValue);
        }
        else
        {
            Debug.LogError("Referência ao Slider não foi atribuída no Inspector!");
        }
    }

    void Update()
    {
        // Exemplo de alteração do valor do termômetro usando teclas de entrada
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SetThermometerValue((int)thermometerSlider.value + 1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SetThermometerValue((int)thermometerSlider.value - 1);
        }

        // Verificar se as teclas ">" ou "<" foram pressionadas
        if (Input.GetKeyDown(KeyCode.Period))  // Tecla ">" (ponto)
        {
            SetThermometerValue((int)thermometerSlider.value + 1);
        }
        if (Input.GetKeyDown(KeyCode.Comma))   // Tecla "<" (vírgula)
        {
            SetThermometerValue((int)thermometerSlider.value - 1);
        }
    }
}

