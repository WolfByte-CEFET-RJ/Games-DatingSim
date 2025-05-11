using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    [SerializeField] private Button b1, b2, b3;
    public static bool doma;
    public static int ajustesc;
    private int alt;

    [System.Serializable]
    public class Fala
    {
        public int aju;
        public string msg;
    }

    [System.Serializable]
    public class ListaFalas
    {
        public Fala[] escolhaFlip1;
        public Fala[] escolhaFlip2;
        public Fala[] escolhaFlip3;
        public Fala[] escolhaMesa1;
        public Fala[] escolhaMesa2;
        public Fala[] escolhaMesa3;
        public Fala[] escolhaPcs1;
        public Fala[] escolhaPcs2;
        public Fala[] escolhaPcs3;
        public Fala[] escolhaSolda1;
        public Fala[] escolhaSolda2;
        public Fala[] escolhaSolda3;
    }
    public ListaFalas lista_de_falas = new ListaFalas();

    DialogueSystem ds;
    TextArchitect architectb1;
    TextArchitect architectb2;
    TextArchitect architectb3;
    public TextArchitect.BuildMethod bm = TextArchitect.BuildMethod.instant;
    public char select;
    public TextAsset JSONEscolha;
    public int id_fala;
    public int bot, bye, wie;
    string longLine;
    string lingLine;
    string lengLine;
    public CharacterItem character;


    private void Awake()
    {
        b1.onClick.AddListener(esc1);
        b2.onClick.AddListener(esc2);
        b3.onClick.AddListener(esc3);

    }
    
    void Start()
    {
        lista_de_falas = JsonUtility.FromJson<ListaFalas>(JSONEscolha.text);
        id_fala = 0;
        alt = Buttons_2.alt;
        id_fala = id_fala+alt;
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
                longLine = lista_de_falas.escolhaMesa1[id_fala].msg;
                lingLine = lista_de_falas.escolhaMesa2[id_fala].msg;
                lengLine = lista_de_falas.escolhaMesa3[id_fala].msg;
                bot = lista_de_falas.escolhaMesa1[id_fala].aju;
                bye = lista_de_falas.escolhaMesa2[id_fala].aju;
                wie = lista_de_falas.escolhaMesa3[id_fala].aju;
                
                id_fala = id_fala + 0;
                break;
            case 'F':
                longLine = lista_de_falas.escolhaFlip1[id_fala].msg;
                lingLine = lista_de_falas.escolhaFlip2[id_fala].msg;
                lengLine = lista_de_falas.escolhaFlip3[id_fala].msg;
                bot = lista_de_falas.escolhaFlip1[id_fala].aju;
                bye = lista_de_falas.escolhaFlip2[id_fala].aju;
                wie = lista_de_falas.escolhaFlip3[id_fala].aju;

                id_fala = id_fala + 0;
                break;
            case 'S':
                longLine = lista_de_falas.escolhaSolda1[id_fala].msg;
                lingLine = lista_de_falas.escolhaSolda2[id_fala].msg;
                lengLine = lista_de_falas.escolhaSolda3[id_fala].msg;
                bot = lista_de_falas.escolhaSolda1[id_fala].aju;
                bye = lista_de_falas.escolhaSolda2[id_fala].aju;
                wie = lista_de_falas.escolhaSolda3[id_fala].aju;

                id_fala = id_fala + 0;
                break;
            case 'P':
                longLine = lista_de_falas.escolhaPcs1[id_fala].msg;
                lingLine = lista_de_falas.escolhaPcs2[id_fala].msg;
                lengLine = lista_de_falas.escolhaPcs3[id_fala].msg;
                bot = lista_de_falas.escolhaPcs1[id_fala].aju;
                bye = lista_de_falas.escolhaPcs2[id_fala].aju;
                wie = lista_de_falas.escolhaPcs3[id_fala].aju;

                id_fala = id_fala + 0;
                break;
        }

        architectb1.Build(longLine);
        architectb2.Build(lingLine);
        architectb3.Build(lengLine);
    }

    private void esc1()
    {
        ajustesc = bot;
        id_fala++;
        doma = true;
    }

    private void esc2()
    {
        ajustesc = bye;
        id_fala++;
        doma = true;
    }

    private void esc3()
    {
        ajustesc = wie;
        id_fala++;
        doma = true;
    }

    void Update()
    {  
        /*if (architectb1.isBuilding)
        {
            if (!architectb1.hurryUp)
            {
                architectb1.hurryUp = true;
                architectb2.hurryUp = true;
                architectb1.libera = true;
            }
            else
            {
                architectb1.ForceComplete();
                architectb2.ForceComplete();
            }
        }
        else if (architectb1.libera == false)
            {
            id_fala ++;
            architectb1.Build(longLine);
            architectb2.Build(lingLine);
            }*/
    }
}