using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    [SerializeField] private Button b1, b2, b3;
    public static bool doma;

    private void Awake()
    {
        b1.onClick.AddListener(OnClickDown);
        b2.onClick.AddListener(OnClickDown);
        b3.onClick.AddListener(OnClickDown);
    }

    private void OnClickDown()
    {
        doma = true;
    }
}
