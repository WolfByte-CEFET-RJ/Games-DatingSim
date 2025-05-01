using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conversa : MonoBehaviour
{
    DialogueSystem2 ds;
    TextArchitect2 architect;
    TextArchitectPlayer2 architectPlayer;
    private GameObject balao;
    public TextArchitect2.BuildMethod bm = TextArchitect2.BuildMethod.instant;
    public TextArchitectPlayer2.BuildMethod bmp = TextArchitectPlayer2.BuildMethod.instant;

    public TextAsset JSONMesa,JSONPcs,JSONSolda,JSONFlip, JSONEscolha;
    string longLine;
    string name;
    public static char select;
    public int ids;
    public int indexa;

    [System.Serializable]
    public class Fala
    {
        public int id;
        public int indexa;
        public int nescolhas;
        public string chara;
        public string msg;
        public string pose;
    }

    [System.Serializable]
    public class ListaFalas
    {
        public Fala[] fala;
    }
    public ListaFalas lista_de_falas = new ListaFalas();




    // Start is called before the first frame update
    void Start()
    {
        ds = DialogueSystem2.instance;
        architect = new TextArchitect2(ds.dialogueContainer2.dialogueText);
        architectPlayer = new TextArchitectPlayer2(ds.dialogueContainer2.nameText);
        architectPlayer.speed = 1f;
        architect.speed = 0.5f;
        ids = 1;
    }

    // Update is called once per frame
    void Update()
    {
        lista_de_falas = JsonUtility.FromJson<ListaFalas>(JSONMesa.text);
        select = SelecaoLugar2.selec;
        longLine = lista_de_falas.fala[ids].msg;
        name = lista_de_falas.fala[ids].chara;
        indexa = lista_de_falas.fala[ids].indexa;

        if(select == 'N')
        {
            return;
        }

        if (indexa != 0)
        {
            ids = indexa;
            indexa = 0;
        }

        if (bm != architect.buildMethod)
        {
            architect.buildMethod = bm;
            architect.Stop();
            architectPlayer.buildMethod = bmp;
            architectPlayer.Stop();
        }

        if (select != 'N' && ((ids == 1) || (Input.GetKeyDown(KeyCode.Space)) || (indexa != 0)))
        {
            if (architect.isBuilding)
            {
                if (!architect.hurryUp)
                {
                    architect.hurryUp = true;
                    architectPlayer.hurryUp = true;
                    architect.libera = true;
                }
                else
                {
                    architect.ForceComplete();
                    architectPlayer.ForceComplete();
                }
            }
            else if (architect.libera == false)
                {
                architect.Build(longLine);
                architectPlayer.Build(name);
                ids++;
                }
        } 
    }
}
