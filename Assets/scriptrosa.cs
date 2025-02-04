using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scriptrosa : MonoBehaviour

{
    public Slider slider;  // Referência ao Slider na interface
    public int minValue = 1;  // Valor mínimo do Slider
    public int maxValue = 15; // Valor máximo do Slider
    public Image fillImage; // Referência ao Fill do slider

    private bool hasMoved = false;

    void Start()
    {
        // Verifica se o slider foi atribuído no Inspector, caso contrário, busca o componente
        if (slider == null)
        {
            slider = GetComponent<Slider>();
        }
        
        // Define os valores mínimo e máximo do slider
        slider.minValue = minValue;
        slider.maxValue = maxValue;
        
        // Define o valor inicial para o meio (8)
        slider.value = 8;
    
        
       
    }

    void Update()
    {
        // Quando a tecla "1" for pressionada, aumenta o valor do slider em 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            IncreaseValue();
        }

        // Quando a tecla "2" for pressionada, diminui o valor do slider em 1
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DecreaseValue();
        }
    }

    // Função que aumenta o valor do slider
    void IncreaseValue()
    {
        slider.value = Mathf.Min(slider.value + 1, slider.maxValue);
    }

    // Função que diminui o valor do slider
    void DecreaseValue()
    {
        slider.value = Mathf.Max(slider.value - 1, slider.minValue);
    }
    void OnSliderValueChanged(float value)
    {
        if (!hasMoved)
        {
            // Ativa o Fill na primeira movimentação do Handle
            fillImage.enabled = true;
            hasMoved = true;
        }
    }
}
