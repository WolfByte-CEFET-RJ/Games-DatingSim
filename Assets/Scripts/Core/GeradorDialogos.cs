using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


    public class GeradorDialogos : MonoBehaviour
    {
        DialogueSystem ds;
        TextArchitect architect;
        TextArchitectPlayer architectPlayer;
        private GameObject filas;
        private GameObject escolha2;
        private GameObject escolha3;
        private GameObject mesa, mesa1, mesa2, flip, flip1, flip2, solda, solda1, solda2, pc, pc1, pc2;
        public TextArchitect.BuildMethod bm = TextArchitect.BuildMethod.instant;
        public TextArchitectPlayer.BuildMethod bmp = TextArchitectPlayer.BuildMethod.instant;

        public TextAsset JSONMesa,JSONPcs,JSONSolda,JSONFlip, JSONEscolha;
        public int id_fala;
        public int esc,esc0,esc1,esc2,esc3,fim,fim1,fim2,fim3,fim4,fim5;
        public int elimn;
        public bool dom,dum;
        public int ajuesc,ajustesc, isi;
        public char select, elim;
        string longLine;
        string name;
        public int id_pose;
        public static string pose;
        public static string personagem;
        
        
        [System.Serializable]
        public class Fala
        {
            public int id;
            public string character;
            public string msg;
            public string pose;
        }

        [System.Serializable]
        public class ListaFalas
        {
            public Fala[] fala;
        }
        public ListaFalas lista_de_falas = new ListaFalas();

        [System.Serializable]
        public class escolhas
        {
            public int esci;
            public int fim;
        }

        [System.Serializable]
        public class ListaEscolhas
        {
            public escolhas[] escolhaFlip;
            public escolhas[] escolhaMesa;
            public escolhas[] escolhaPcs;
            public escolhas[] escolhaSolda;
        }
        public ListaEscolhas lista_de_escolhas = new ListaEscolhas();


        // Start is called before the first frame update
        void Start()
        {
            ds = DialogueSystem.instance;
            lista_de_escolhas = JsonUtility.FromJson<ListaEscolhas>(JSONEscolha.text);
            //lista_de_falas = JsonUtility.FromJson<ListaFalas>(JSONMesa.text);
            architect = new TextArchitect(ds.dialogueContainer.dialogueText);
            architectPlayer = new TextArchitectPlayer(ds.dialogueContainer.nameText);
            architect.buildMethod = TextArchitect.BuildMethod.fade;
            architectPlayer.speed = 1f;
            architect.speed = 0.5f;
            id_fala = 1;
            id_pose = id_fala-1; 
            esc = 50;
            esc0 = 50;
            esc1 = 50;
            esc2 = 50;
            esc3 = 50;
            elimn = 50;
            filas = ds.dialogueContainer.root;
            escolha2 = ds.dialogueContainer.escolha2;
            escolha3 = ds.dialogueContainer.escolha3;
            mesa = ds.dialogueContainer.mesa;
            mesa1 = ds.dialogueContainer.mesa1;
            mesa2 = ds.dialogueContainer.mesa2;
            flip = ds.dialogueContainer.flip;
            flip1 = ds.dialogueContainer.flip1;
            flip2 = ds.dialogueContainer.flip2;
            solda = ds.dialogueContainer.solda;
            solda1 = ds.dialogueContainer.solda1;
            solda2 = ds.dialogueContainer.solda2;
            pc = ds.dialogueContainer.pc;
            pc1 = ds.dialogueContainer.pc1;
            pc2 = ds.dialogueContainer.pc2;
            elim = 'C';
        }

        // Update is called once per frame
        void Update()
        {
            id_pose = id_fala-1;
            

            elim = Buttons_2.elim;
            elimn = Buttons_2.elimn;
            select = SelecaoLugar.selec;
            dom = Buttons_2.doma;
            dum = Buttons.doma;
            ajuesc = Buttons_2.ajuesc;
            ajustesc = Buttons.ajustesc;
            if(select == 'N')
            {
                return;
            }
            selet(select);
            longLine = lista_de_falas.fala[id_fala].msg;
            name = lista_de_falas.fala[id_fala].character;
            pose = lista_de_falas.fala[id_pose].pose;
            personagem = lista_de_falas.fala[id_pose].character;

            //Loudar nova cena.
            /*if(id_fala == fim || id_fala == fim1 || id_fala == fim2 || id_fala == fim3 || id_fala == fim4)
            {
                PlayGame();
            }*/



            if (bm != architect.buildMethod)
            {
                architect.buildMethod = bm;
                architect.Stop();
                architectPlayer.buildMethod = bmp;
                architectPlayer.Stop();
            }
            
            if (id_fala == esc && dom == false || id_fala == esc0 && dom == false || id_fala == esc1 && dom == false)
            {
                escolha2.SetActive(true);
            }
            else if (dom == true)
            {
                id_fala = id_fala + ajuesc;
                escolha2.SetActive(false);
                longLine = lista_de_falas.fala[id_fala].msg;
                name = lista_de_falas.fala[id_fala].character;
                Buttons_2.doma = false;
                architect.Build(longLine);
                architectPlayer.Build(name);
                id_fala++;
            }

            if (id_fala == esc2 && dum == false || id_fala == esc3 && dum == false)
            {
                escolha3.SetActive(true);
            }
            else if (dum == true)
            {
                
                id_fala = id_fala + ajustesc;
                escolha3.SetActive(false);
                longLine = lista_de_falas.fala[id_fala].msg;
                name = lista_de_falas.fala[id_fala].character;
                Buttons.doma = false;
                architect.Build(longLine);
                architectPlayer.Build(name);
                id_fala++;
            }

            if (elim == 'A' && id_fala == elimn)
            {
                mesa2.SetActive(false);
                flip2.SetActive(false);
                solda2.SetActive(false);
                pc2.SetActive(false);
            } else if (elim == 'B' && id_fala == elimn)
            {
                mesa1.SetActive(false);
                flip1.SetActive(false);
                solda1.SetActive(false);
                pc1.SetActive(false);
            }


       
            if (select != 'N' && ((id_fala == 1) ||(Input.GetKeyDown(KeyCode.Space) && id_fala != esc && id_fala != esc0 && id_fala != esc1 && id_fala != esc2 && id_fala != esc3)))
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
                    id_fala ++;
                    }
                //architect.Build(lines[Random.Range(0, lines.Length)]);
            }            
            
        }

        /*public void PlayGame()
        {
            SceneManager.LoadScene("Demo", LoadSceneMode.Single);
        }*/

        void selet(char elem)
        {
            switch (elem)
            {
                case 'M':
                    mesa.SetActive(true);
                    lista_de_falas = JsonUtility.FromJson<ListaFalas>(JSONMesa.text);
                    esc = lista_de_escolhas.escolhaMesa[0].esci;
                    esc0 = lista_de_escolhas.escolhaMesa[1].esci;
                    esc1 = lista_de_escolhas.escolhaMesa[2].esci;
                    esc2 = lista_de_escolhas.escolhaMesa[3].esci;
                    esc3 = lista_de_escolhas.escolhaMesa[4].esci;
                    fim = lista_de_escolhas.escolhaMesa[0].fim;
                    fim1 = lista_de_escolhas.escolhaMesa[1].fim;
                    fim2 = lista_de_escolhas.escolhaMesa[2].fim;
                    fim3 = lista_de_escolhas.escolhaMesa[3].fim;
                    fim4 = lista_de_escolhas.escolhaMesa[4].fim;
                    fim5 = lista_de_escolhas.escolhaMesa[5].fim;
                    break;
                case 'F':
                    flip.SetActive(true);
                    lista_de_falas = JsonUtility.FromJson<ListaFalas>(JSONFlip.text);
                    esc = lista_de_escolhas.escolhaFlip[0].esci;
                    esc0 = lista_de_escolhas.escolhaFlip[1].esci;
                    esc1 = lista_de_escolhas.escolhaFlip[2].esci;
                    esc2 = lista_de_escolhas.escolhaFlip[3].esci;
                    esc3 = lista_de_escolhas.escolhaFlip[4].esci;
                    fim = lista_de_escolhas.escolhaFlip[0].fim;
                    fim1 = lista_de_escolhas.escolhaFlip[1].fim;
                    fim2 = lista_de_escolhas.escolhaFlip[2].fim;
                    fim3 = lista_de_escolhas.escolhaFlip[3].fim;
                    fim4 = lista_de_escolhas.escolhaFlip[4].fim;
                    fim5 = lista_de_escolhas.escolhaFlip[5].fim;
                    break;
                case 'S':
                    solda.SetActive(true);
                    lista_de_falas = JsonUtility.FromJson<ListaFalas>(JSONSolda.text);
                    esc = lista_de_escolhas.escolhaSolda[0].esci;
                    esc0 = lista_de_escolhas.escolhaSolda[1].esci;
                    esc1 = lista_de_escolhas.escolhaSolda[2].esci;
                    esc2 = lista_de_escolhas.escolhaSolda[3].esci;
                    esc3 = lista_de_escolhas.escolhaSolda[4].esci;
                    fim = lista_de_escolhas.escolhaSolda[0].fim;
                    fim1 = lista_de_escolhas.escolhaSolda[1].fim;
                    fim2 = lista_de_escolhas.escolhaSolda[2].fim;
                    fim3 = lista_de_escolhas.escolhaSolda[3].fim;
                    fim4 = lista_de_escolhas.escolhaSolda[4].fim;
                    fim5 = lista_de_escolhas.escolhaSolda[5].fim;
                    break;
                case 'P':
                    pc.SetActive(true);
                    lista_de_falas = JsonUtility.FromJson<ListaFalas>(JSONPcs.text);
                    esc = lista_de_escolhas.escolhaPcs[0].esci;
                    esc0 = lista_de_escolhas.escolhaPcs[1].esci;
                    esc1 = lista_de_escolhas.escolhaPcs[2].esci;
                    esc2 = lista_de_escolhas.escolhaPcs[3].esci;
                    esc3 = lista_de_escolhas.escolhaPcs[4].esci;
                    fim = lista_de_escolhas.escolhaPcs[0].fim;
                    fim1 = lista_de_escolhas.escolhaPcs[1].fim;
                    fim2 = lista_de_escolhas.escolhaPcs[2].fim;
                    fim3 = lista_de_escolhas.escolhaPcs[3].fim;
                    fim4 = lista_de_escolhas.escolhaPcs[4].fim;
                    fim5 = lista_de_escolhas.escolhaPcs[5].fim;
                    break;
            }
        }
        
    }