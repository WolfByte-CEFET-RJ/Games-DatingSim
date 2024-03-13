using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TESTING
{

    public class Testing_Architect : MonoBehaviour
    {
        DialogueSystem ds;
        TextArchitect architect;

        public TextArchitect.BuildMethod bm = TextArchitect.BuildMethod.instant;

        string[] lines = new string[5]
        {
            "Ola, eu sou a botz!",
            "Muito bem vindo ao Ramo.",
            "Prazer em te conehecer.",
            "Heheheheheheheheeheh.\n Certo? ",
            "Arara"
        };

        // Start is called before the first frame update
        void Start()
        {
            ds = DialogueSystem.instance;
            architect = new TextArchitect(ds.dialogueContainer.dialogueText);
            architect.buildMethod = TextArchitect.BuildMethod.fade;
            architect.speed = 0.5f;
        }

        // Update is called once per frame
        void Update()
        {
            if (bm != architect.buildMethod)
            {
                architect.buildMethod = bm;
                architect.Stop();
            }

            if (Input.GetKeyDown(KeyCode.S))
                architect.Stop();

            string longLine = "Você é novo por aqui? Eu não conhecia você e nem me lembro de te ver por aqui. Por isso penso que você possa ser um novo membro do ramo, alguém que eu não conheça ainda, mas estou ansioso para conhecer. Sendo assim, prazer.";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (architect.isBuilding)
                {
                    if (!architect.hurryUp)
                        architect.hurryUp = true;
                    else
                        architect.ForceComplete();
                }
                else
                    architect.Build(longLine);
                //architect.Build(lines[Random.Range(0, lines.Length)]);
            }            
            else if (Input.GetKeyDown(KeyCode.A))
            {     
                architect.Append(longLine);
                //architect.Append(lines[Random.Range(0, lines.Length)]);
            }
        }
    }
}