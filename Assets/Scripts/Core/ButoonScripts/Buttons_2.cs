    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons_2 : MonoBehaviour
{
    [SerializeField] private Button b1, b2;
    public static bool doma;
    public static int ajuesc, elimn, alt;
    public static char elim;

    [System.Serializable]
    public class Fala
    {
        public int aju;
        public int elimn;
        public string msg;
    }

    [System.Serializable]
    public class ListaFalas
    {
        public Fala[] escolhaFlip1;
        public Fala[] escolhaFlip2;
        public Fala[] escolhaMesa1;
        public Fala[] escolhaMesa2;
        public Fala[] escolhaPcs1;
        public Fala[] escolhaPcs2;
        public Fala[] escolhaSolda1;
        public Fala[] escolhaSolda2;
    }
    public ListaFalas lista_de_falas = new ListaFalas();

    DialogueSystem ds;
    TextArchitect architectb1;
    TextArchitect architectb2;
    public TextArchitect.BuildMethod bm = TextArchitect.BuildMethod.instant;
    public char select;
    public TextAsset JSONEscolha;
    public int id_fala;
    public int bot, bye, elimna, elimnb;
    string longLine;
    string lingLine;


    private void Awake()
    {
        b1.onClick.AddListener(esc1);
        b2.onClick.AddListener(esc2);

    }
    
    void Start()
    {
        lista_de_falas = JsonUtility.FromJson<ListaFalas>(JSONEscolha.text);
        id_fala = 0;
        select = SelecaoLugar.selec;
        ds = DialogueSystem.instance;
        architectb1 = new TextArchitect(ds.dialogueContainer.esc2b1);
        architectb2 = new TextArchitect(ds.dialogueContainer.esc2b2);
        architectb1.speed = 0.5f;
        architectb2.speed = 0.5f;
        elim = 'C';
        elimn = 50;

        switch (select)
        {
            case 'M':
                longLine = lista_de_falas.escolhaMesa1[id_fala].msg;
                lingLine = lista_de_falas.escolhaMesa2[id_fala].msg;
                bot = lista_de_falas.escolhaMesa1[id_fala].aju;
                bye = lista_de_falas.escolhaMesa2[id_fala].aju;
                elimna = lista_de_falas.escolhaMesa1[id_fala].elimn;
                elimnb = lista_de_falas.escolhaMesa2[id_fala].elimn;
                id_fala = id_fala + 0;
                break;
            case 'F':
                longLine = lista_de_falas.escolhaFlip1[id_fala].msg;
                lingLine = lista_de_falas.escolhaFlip2[id_fala].msg;
                bot = lista_de_falas.escolhaFlip1[id_fala].aju;
                bye = lista_de_falas.escolhaFlip2[id_fala].aju;
                elimna = lista_de_falas.escolhaFlip1[id_fala].elimn;
                elimnb = lista_de_falas.escolhaFlip2[id_fala].elimn;
                id_fala = id_fala + 0;
                break;
            case 'S':
                longLine = lista_de_falas.escolhaSolda1[id_fala].msg;
                lingLine = lista_de_falas.escolhaSolda2[id_fala].msg;
                bot = lista_de_falas.escolhaSolda1[id_fala].aju;
                bye = lista_de_falas.escolhaSolda2[id_fala].aju;
                elimna = lista_de_falas.escolhaSolda1[id_fala].elimn;
                elimnb = lista_de_falas.escolhaSolda2[id_fala].elimn;
                id_fala = id_fala + 0;
                break;
            case 'P':
                longLine = lista_de_falas.escolhaPcs1[id_fala].msg;
                lingLine = lista_de_falas.escolhaPcs2[id_fala].msg;
                bot = lista_de_falas.escolhaPcs1[id_fala].aju;
                bye = lista_de_falas.escolhaPcs2[id_fala].aju;
                elimna = lista_de_falas.escolhaPcs1[id_fala].elimn;
                elimnb = lista_de_falas.escolhaPcs2[id_fala].elimn;
                id_fala = id_fala + 0;
                break;
        }

        architectb1.Build(longLine);
        architectb2.Build(lingLine);

    }

    private void esc1()
    {
        elim = 'A';
        alt = 0;
        elimn = elimna;
        ajuesc = bot;
        id_fala++;
        doma = true;
        
    }

    private void esc2()
    {
        elim = 'B';
        alt = 1;
        elimn = elimnb;
        ajuesc = bye;
        id_fala++;
        doma = true;
        
    }
    
}
