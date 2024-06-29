using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    [SerializeField] private Button b1, b2, b3;
    public static bool doma;

    [System.Serializable]
    public class Fala
    {
        public int id;
        public string character;
        public string msg;
    }

    [System.Serializable]
    public class ListaFalas
    {
        public Fala[] fala;
    }
    DialogueSystem ds;
    TextArchitect architectb1;
    TextArchitect architectb2;
    TextArchitect architectb3;
    public TextArchitect.BuildMethod bm = TextArchitect.BuildMethod.instant;
    public ListaFalas lista_de_falas = new ListaFalas();
    public char select;
    public TextAsset JSONEscolha;
    public int id_fala;

    private void Awake()
    {
        b1.onClick.AddListener(OnClickDown);
        b2.onClick.AddListener(OnClickDown);
        b3.onClick.AddListener(OnClickDown);
    }
    
    void Start()
    {
        id_fala = 1;
        lista_de_falas = JsonUtility.FromJson<ListaFalas>(JSONEscolha.text);
        select = SelecaoLugar.selec;
        ds = DialogueSystem.instance;
        architectb1 = new TextArchitect(ds.dialogueContainer.esc3b1);
        architectb2 = new TextArchitect(ds.dialogueContainer.esc3b2);
        architectb3 = new TextArchitect(ds.dialogueContainer.esc3b3);
        architectb1.speed = 0.5f;
        architectb2.speed = 0.5f;
        architectb3.speed = 0.5f;
        
        switch (select)
        {
            case 'M':
                id_fala = id_fala + 0;
                break;
            case 'F':
                id_fala = id_fala + 0;
                break;
            case 'S':
                id_fala = id_fala + 0;
                break;
            case 'P':
                id_fala = id_fala + 0;
                break;
        }
    }

    private void OnClickDown()
    {
        doma = true;
    }

    void Update()
    {
        string longLine = lista_de_falas.fala[id_fala].msg;
        string lingLine = lista_de_falas.fala[id_fala++].msg;
        string lengLine = lista_de_falas.fala[id_fala + 2].msg;
        
        architectb1.Build(longLine);
        architectb2.Build(lingLine);
        architectb3.Build(lengLine);
        
    }


    
}
