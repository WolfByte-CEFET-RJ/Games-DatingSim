using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Responsivo : MonoBehaviour
{
    public Slider slider, responsivo;
    public void Update()
    {
        slider.value = responsivo.value;
    }

}
