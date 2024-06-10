using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Testing_Architect : MonoBehaviour
    {
        Buttons bs;
        DialogueSystem ds;
        TextArchitect architect;
        TextArchitectPlayer architectPlayer;
        private GameObject filas;
        private GameObject control;

        public TextArchitect.BuildMethod bm = TextArchitect.BuildMethod.instant;
        public TextArchitectPlayer.BuildMethod bmp = TextArchitectPlayer.BuildMethod.instant;

        public TextAsset JSONMesa;
        public TextAsset JSONPcs;
        public TextAsset JSONSolda;
        public TextAsset JSONFlip;
        public int id_fala;
        public int per;
        public bool dom;
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
            per = 18;
            lista_de_falas = JsonUtility.FromJson<ListaFalas>(JSONFlip.text);
            ds = DialogueSystem.instance;
            architect = new TextArchitect(ds.dialogueContainer.dialogueText);
            architectPlayer = new TextArchitectPlayer(ds.dialogueContainer.nameText);
            architect.buildMethod = TextArchitect.BuildMethod.fade;
            architectPlayer.speed = 1f;
            architect.speed = 0.5f;
            id_fala = 0;
            filas = ds.dialogueContainer.root;
            control = ds.dialogueContainer.buttonsControl;
        }

        // Update is called once per frame
        void Update()
        {
            select = SelecaoLugar.selec;
            dom = Buttons.doma;
            string longLine = lista_de_falas.fala[id_fala].msg;
            string name = lista_de_falas.fala[id_fala].character;

            switch (select)
            {
                case 'M':
                    per = 5;
                    lista_de_falas = JsonUtility.FromJson<ListaFalas>(JSONMesa.text);
                    break;
                case 'F':
                    per = 18;
                    lista_de_falas = JsonUtility.FromJson<ListaFalas>(JSONFlip.text);
                    break;
                case 'S':
                    per = 5;
                    lista_de_falas = JsonUtility.FromJson<ListaFalas>(JSONSolda.text);
                    break;
                case 'P':
                    per = 5;
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
            
            if (id_fala == per && dom == false)
            {
                control.SetActive(true);
            }
            else if (dom == true)
            {
                id_fala ++;
                control.SetActive(false);
                architect.Build(longLine);
                architectPlayer.Build(name);
                Buttons.doma = false;
            }

            if (Input.GetKeyDown(KeyCode.Space) && id_fala != per)
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