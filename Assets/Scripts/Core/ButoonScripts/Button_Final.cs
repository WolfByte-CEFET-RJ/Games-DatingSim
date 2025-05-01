using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Final : MonoBehaviour
{
    //Passar: pra qual id a fala deve ir, e se teve aumento de afeição.
    //Passar ou receber: Qual o id da próxima pergunta e quantas perguntas são.
    //Receber o Json com as perguntas.

    [SerializeField] private Button b1, b2, b3, b4, b5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        b1.onClick.AddListener(Buttons2_1);
        b2.onClick.AddListener(Buttons2_2);
        b3.onClick.AddListener(Buttons3_1);
        b4.onClick.AddListener(Buttons3_2);
        b5.onClick.AddListener(Buttons3_3);

    }

    private void Buttons2_1()
    {
        
    }

    private void Buttons2_2()
    {
        
    }

    private void Buttons3_1()
    {
        
    }

    private void Buttons3_2()
    {
        
    }

    private void Buttons3_3()
    {
        
    }
    

}
