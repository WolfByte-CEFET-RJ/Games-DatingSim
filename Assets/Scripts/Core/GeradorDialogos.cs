using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    public class GeradorDialogos : MonoBehaviour
    {
        DialogueSystem ds;
        TextArchitect architect;
        TextArchitectPlayer architectPlayer;
        private GameObject filas;
        private GameObject escolha2;
        private GameObject escolha3;
        private GameObject mesa, mesa1, mesa2, flip, flip1, flip2, solda, solda1, solda2, pc, pc1, pc2;
        private GameObject WieF, WieM, GestaoF, GestaoM, BotzF, BotzM, ByteF, ByteM, RocketF, RocketM, SocialF, SocialM, PowerF, PowerM, MarketingF, MarketingM;
        public TextArchitect.BuildMethod bm = TextArchitect.BuildMethod.instant;
        public TextArchitectPlayer.BuildMethod bmp = TextArchitectPlayer.BuildMethod.instant;

        public TextAsset JSONMesa,JSONPcs,JSONSolda,JSONFlip, JSONEscolha;
        public int id_fala;
        public int esc,esc0,esc1,esc2,esc3;
        public int elimn;
        public bool dom,dum;
        public int ajuesc,ajustesc, isi;
        public char select, elim;
        string longLine;
        string name;
        string BoF, BoM, ByM, ByF;
        
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

        [System.Serializable]
        public class escolhas
        {
            public int esci;
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
            WieF = ds.dialogueContainer.WieF;
            WieM = ds.dialogueContainer.WieM;
            GestaoF = ds.dialogueContainer.GestaoF;
            GestaoM = ds.dialogueContainer.GestaoM;
            BotzF = ds.dialogueContainer.BotzF;
            BotzM = ds.dialogueContainer.BotzM;
            ByteF = ds.dialogueContainer.ByteF;
            ByteM = ds.dialogueContainer.ByteM;
            RocketF = ds.dialogueContainer.RocketF;
            RocketM = ds.dialogueContainer.RocketM;
            SocialF = ds.dialogueContainer.SocialF;
            SocialM = ds.dialogueContainer.SocialM;
            PowerF = ds.dialogueContainer.PowerF;
            PowerM = ds.dialogueContainer.PowerM;
            MarketingF = ds.dialogueContainer.MarketingF;
            MarketingM = ds.dialogueContainer.MarketingM;
            elim = 'C';
        }

        // Update is called once per frame
        void Update()
        {
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


       
            if (select != 'N' && ((id_fala == 1) ||(Input.GetKeyDown(KeyCode.Space) && id_fala != esc && id_fala != esc2)))
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
                    claridade(name);
                    id_fala ++;
                    }
                //architect.Build(lines[Random.Range(0, lines.Length)]);
            }            
            
        }

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
                    break;
                case 'F':
                    flip.SetActive(true);
                    lista_de_falas = JsonUtility.FromJson<ListaFalas>(JSONFlip.text);
                    esc = lista_de_escolhas.escolhaFlip[0].esci;
                    esc0 = lista_de_escolhas.escolhaFlip[1].esci;
                    esc1 = lista_de_escolhas.escolhaFlip[2].esci;
                    esc2 = lista_de_escolhas.escolhaFlip[3].esci;
                    esc3 = lista_de_escolhas.escolhaFlip[4].esci;
                    break;
                case 'S':
                    solda.SetActive(true);
                    lista_de_falas = JsonUtility.FromJson<ListaFalas>(JSONSolda.text);
                    esc = lista_de_escolhas.escolhaSolda[0].esci;
                    esc0 = lista_de_escolhas.escolhaSolda[1].esci;
                    esc1 = lista_de_escolhas.escolhaSolda[2].esci;
                    esc2 = lista_de_escolhas.escolhaSolda[3].esci;
                    esc3 = lista_de_escolhas.escolhaSolda[4].esci;
                    break;
                case 'P':
                    pc.SetActive(true);
                    lista_de_falas = JsonUtility.FromJson<ListaFalas>(JSONPcs.text);
                    esc = lista_de_escolhas.escolhaPcs[0].esci;
                    esc0 = lista_de_escolhas.escolhaPcs[1].esci;
                    esc1 = lista_de_escolhas.escolhaPcs[2].esci;
                    esc2 = lista_de_escolhas.escolhaPcs[3].esci;
                    esc3 = lista_de_escolhas.escolhaPcs[4].esci;
                    break;
            }
        }
        void claridade(string mud)
        {
            switch (mud)
            {
                case "":
                    BotzF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    WieF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    PowerF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    ByteF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    RocketF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    SocialF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    GestaoF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    MarketingF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    break;
                case "Narrador":
                    BotzF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    WieF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    PowerF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    ByteF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    RocketF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    SocialF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    GestaoF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    MarketingF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    break;
                case "Botz(F)":
                    BotzF.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    WieF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    PowerF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    ByteF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    RocketF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    SocialF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    GestaoF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    MarketingF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    break;
                case "Botz(M)":
                    BotzF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    WieF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    PowerF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    ByteF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    RocketF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    SocialF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    GestaoF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    MarketingF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    break;
                case "Byte(F)":
                    BotzF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    WieF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    PowerF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    ByteF.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    RocketF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    SocialF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    GestaoF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    MarketingF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    break;
                case "Byte(M)":
                    BotzF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    WieF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    PowerF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    ByteF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    RocketF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    SocialF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    GestaoF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    MarketingF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    break;
                case "Power(F)":
                    BotzF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    WieF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    PowerF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    ByteF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    RocketF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    SocialF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    GestaoF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    MarketingF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    break;
                case "Power(M)":
                    BotzF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    WieF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    PowerF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    ByteF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    RocketF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    SocialF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    GestaoF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    MarketingF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    break;
                case "Rocket(F)":
                    BotzF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    WieF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    PowerF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    ByteF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    RocketF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    SocialF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    GestaoF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    MarketingF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    break;
                case "Rocket(M)":
                    BotzF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    WieF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    PowerF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    ByteF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    RocketF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    SocialF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    GestaoF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    MarketingF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    break;
                case "Social(F)":
                    BotzF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    WieF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    PowerF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    ByteF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    RocketF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    SocialF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    GestaoF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    MarketingF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    break;
                case "Social(M)":
                    BotzF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    WieF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    PowerF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    ByteF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    RocketF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    SocialF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    GestaoF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    MarketingF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    break;
                case "Wie(F)":
                    BotzF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    WieF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    PowerF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    ByteF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    RocketF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    SocialF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    GestaoF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    MarketingF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    break;
                case "Wie(M)":
                    BotzF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    WieF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    PowerF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    ByteF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    RocketF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    SocialF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    GestaoF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    MarketingF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    break;
                case "Gestão(F)":
                    BotzF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    WieF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    PowerF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    ByteF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    RocketF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    SocialF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    GestaoF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    MarketingF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    break;
                case "Gestão(M)":
                    BotzF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    WieF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    PowerF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    ByteF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    RocketF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    SocialF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    GestaoF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    MarketingF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    break;
                case "Marketing(F)":
                    BotzF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    WieF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    PowerF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    ByteF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    RocketF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    SocialF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    GestaoF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    MarketingF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    break;
                case "Marketing(M)":
                    BotzF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    WieF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    PowerF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    ByteF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    RocketF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    SocialF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    GestaoF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    MarketingF.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
                    break;
            }
        }

        void pose(string pose, string mud)
        {
            switch (mud)
            {
                case "":
                    break;
                case "Narrador":
                    break;
                case "Botz(F)":
                    switch (pose)
                    {
                        case "normal":
                            /*BotzF.GetComponent<Image>().sprite = BotzF;*/
                            break;
                    }
                    break;
                case "Botz(M)":
                    break;
                case "Byte(F)":
                    break;
                case "Byte(M)":
                    break;
                case "Power(F)":
                    break;
                case "Power(M)":
                    break;
                case "Rocket(F)":
                    break;
                case "Rocket(M)":
                    break;
                case "Social(F)":
                    break;
                case "Social(M)":
                    break;
                case "Wie(F)":
                    break;
                case "Wie(M)":
                    break;
                case "Gestão(F)":
                    break;
                case "Gestão(M)":
                    break;
                case "Marketing(F)":
                    break;
                case "Marketing(M)":
                    break;
            }
        }
        
    }