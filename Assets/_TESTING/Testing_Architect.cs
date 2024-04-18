using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Testing_Architect : MonoBehaviour
    {
        DialogueSystem ds;
        TextArchitect architect;
        TextArchitectPlayer architectPlayer;
        private GameObject filas;
        private GameObject control;

        public TextArchitect.BuildMethod bm = TextArchitect.BuildMethod.instant;
        public TextArchitectPlayer.BuildMethod bmp = TextArchitectPlayer.BuildMethod.instant;

        public TextAsset textJSON;
        public int id_fala;
        public static Buttons boInstance = new Buttons();
        public bool dom = boInstance.doma;
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
            lista_de_falas = JsonUtility.FromJson<ListaFalas>(textJSON.text);
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
            string longLine = lista_de_falas.fala[id_fala].msg;
            string name = lista_de_falas.fala[id_fala].character;
            if (bm != architect.buildMethod)
            {
                architect.buildMethod = bm;
                architect.Stop();
                architectPlayer.buildMethod = bmp;
                architectPlayer.Stop();
            }

            if (Input.GetKeyDown(KeyCode.S))
                {
                architect.Stop();
                architectPlayer.Stop();
                }
            
            if (id_fala == 5 && dom == false)
            {
                filas.SetActive(false);
                control.SetActive(true);
            }
            else if (id_fala == 5 && dom == true)
            {
                id_fala ++;
                filas.SetActive(true);
                control.SetActive(false);
                dom = false;
            }

            if (Input.GetKeyDown(KeyCode.Space))
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