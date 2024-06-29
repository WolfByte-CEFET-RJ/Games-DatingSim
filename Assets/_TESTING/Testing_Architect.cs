using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Testing_Architect : MonoBehaviour
    {
        Buttons_2 bs;
        DialogueSystem ds;
        TextArchitect architect;
        TextArchitectPlayer architectPlayer;
        private GameObject filas;
        private GameObject escolha2;
        private GameObject escolha3;

        public TextArchitect.BuildMethod bm = TextArchitect.BuildMethod.instant;
        public TextArchitectPlayer.BuildMethod bmp = TextArchitectPlayer.BuildMethod.instant;

        public TextAsset JSONMesa;
        public TextAsset JSONPcs;
        public TextAsset JSONSolda;
        public TextAsset JSONFlip;
        public int id_fala;
        public int esc;
        public int esc2;
        public bool dom;
        public int ajuesc;
        public char select;
        
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
        public ListaFalas lista_de_falas = new ListaFalas();


        // Start is called before the first frame update
        void Start()
        {
            ds = DialogueSystem.instance;
            lista_de_falas = JsonUtility.FromJson<ListaFalas>(JSONMesa.text);
            architect = new TextArchitect(ds.dialogueContainer.dialogueText);
            architectPlayer = new TextArchitectPlayer(ds.dialogueContainer.nameText);
            architect.buildMethod = TextArchitect.BuildMethod.fade;
            architectPlayer.speed = 1f;
            architect.speed = 0.5f;
            id_fala = 1;
            esc = 21;
            esc2 = 21;
            filas = ds.dialogueContainer.root;
            escolha2 = ds.dialogueContainer.escolha2;
            escolha3 = ds.dialogueContainer.escolha3;
            
        }

        // Update is called once per frame
        void Update()
        {
            select = SelecaoLugar.selec;
            dom = Buttons_2.doma;
            ajuesc = Buttons_2.ajuesc;
            string longLine = lista_de_falas.fala[id_fala].msg;
            string name = lista_de_falas.fala[id_fala].character;

            switch (select)
            {
                case 'M':
                    esc = 22;
                    esc2 = 5;
                    lista_de_falas = JsonUtility.FromJson<ListaFalas>(JSONMesa.text);
                    break;
                case 'F':
                    esc = 18;
                    esc2 = 27;
                    lista_de_falas = JsonUtility.FromJson<ListaFalas>(JSONFlip.text);
                    break;
                case 'S':
                    esc = 5;
                    lista_de_falas = JsonUtility.FromJson<ListaFalas>(JSONSolda.text);
                    break;
                case 'P':
                    esc = 5;
                    lista_de_falas = JsonUtility.FromJson<ListaFalas>(JSONPcs.text);
                    break;
            }

            if (bm != architect.buildMethod)
            {
                architect.buildMethod = bm;
                architect.Stop();
                architectPlayer.buildMethod = bmp;
                architectPlayer.Stop();
            }
            
            if (id_fala == esc && dom == false)
            {
                escolha2.SetActive(true);
            }
            else if (dom == true)
            {
                id_fala = id_fala + ajuesc;
                escolha2.SetActive(false);
                longLine = lista_de_falas.fala[id_fala].msg;
                name = lista_de_falas.fala[id_fala].character;
                architect.Build(longLine);
                architectPlayer.Build(name);
                Buttons_2.doma = false;
            }

            if (Input.GetKeyDown(KeyCode.Space) && id_fala != esc && select != 'N')
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
                    id_fala ++;
                    architect.Build(longLine);
                    architectPlayer.Build(name);
                    }
                //architect.Build(lines[Random.Range(0, lines.Length)]);
            }            
            else if (Input.GetKeyDown(KeyCode.A))
            {    
                architect.Append(longLine);
                architectPlayer.Append(name);
                //architect.Append(lines[Random.Range(0, lines.Length)]);
            }
        }
    }