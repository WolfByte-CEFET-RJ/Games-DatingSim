using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelecaoLugar : MonoBehaviour
{
    DialogueSystem ds;
    private GameObject filas;
    private GameObject escolha;

    [SerializeField] private Button b1, b2, b3, b4;
    public static char selec;

    private void Awake()
    {
        b1.onClick.AddListener(Flip);
        b2.onClick.AddListener(Mesa);
        b3.onClick.AddListener(Solda);
        b4.onClick.AddListener(Pcs);
    }

    //void Start()
    //{
    //    selec = 'N';
    //    ds = DialogueSystem.instance;
    //    filas = ds.dialogueContainer.root;
    //    escolha = ds.dialogueContainer.escolha;
    //}

    private void Flip()
    {
        selec = 'F';
        //escolha.SetActive(false);
        //filas.SetActive(true);

    }

    private void Mesa()
    {
        selec = 'M';
        //escolha.SetActive(false);
        //filas.SetActive(true);
    }

    private void Solda()
    {
        selec = 'S';
        //escolha.SetActive(false);
        //filas.SetActive(true);       
    }

    private void Pcs()
    {
        selec = 'P';
        //escolha.SetActive(false);
        //filas.SetActive(true);
    }
}
