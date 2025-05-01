using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelecaoLugar2 : MonoBehaviour
{
    DialogueSystem2 ds;
    private GameObject oJogo;
    private GameObject selecLugar;

    [SerializeField] private Button b1,b2,b3,b4;
    public static char selec;

    private void Awake()
    {
        b1.onClick.AddListener(Flip);
        b2.onClick.AddListener(Mesa);
        b3.onClick.AddListener(Solda);
        b4.onClick.AddListener(Pcs);
    }

    void Start()
    {
        selec = 'N';
        ds = DialogueSystem2.instance;
        oJogo = ds.dialogueContainer2.oJogo;
        selecLugar = ds.dialogueContainer2.selecLugar;
    }

    private void Flip()
    {
        selec = 'F';
        selecLugar.SetActive(false);
        oJogo.SetActive(true);
    }

    private void Mesa()
    {
        selec = 'M';
        selecLugar.SetActive(false);
        oJogo.SetActive(true);
    }

    private void Solda()
    {
        selec = 'S';
        selecLugar.SetActive(false);
        oJogo.SetActive(true);       
    }

    private void Pcs()
    {
        selec = 'P';
        selecLugar.SetActive(false);
        oJogo.SetActive(true);
    }
}
