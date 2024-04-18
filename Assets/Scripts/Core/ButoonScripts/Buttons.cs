using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    Testing_Architect ta;
    DialogueSystem ds;
    [SerializeField] private Button b1, b2, b3;
    private GameObject control;
    private GameObject filas;

    private void Awake()
    {
        b1.onClick.AddListener(OnClickDown);
        b2.onClick.AddListener(OnClickDown);
        b3.onClick.AddListener(OnClickDown);
    }
    // Start is called before the first frame update
    void Start()
    {
        control = ds.dialogueContainer.buttonsControl;
        filas = ds.dialogueContainer.root;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnClickDown()
    {
        control.SetActive(false);
        filas.SetActive(true);
        ta.id_fala = 6;
    }
}
