using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlteraPose : MonoBehaviour
{
    DialogueSystem ds;
    private Image IWieF, IWieM, IGestaoF, IGestaoM, IBotzF, IBotzM, IByteF, IByteM, IRocketF, IRocketM, ISocialF, ISocialM, IPowerF, IPowerM, IMarketingF, IMarketingM;
    public string personagem, pose;
    public string personagem1, pose1;

    void Start()
    {
        ds = DialogueSystem.instance;
        IWieF = ds.dialogueContainer.IWieF;
        IWieM = ds.dialogueContainer.IWieM;
        IGestaoF = ds.dialogueContainer.IGestaoF;
        IGestaoM = ds.dialogueContainer.IGestaoM;
        IBotzF = ds.dialogueContainer.IBotzF;
        IBotzM = ds.dialogueContainer.IBotzM;
        IByteF = ds.dialogueContainer.IByteF;
        IByteM = ds.dialogueContainer.IByteM;
        IRocketF = ds.dialogueContainer.IRocketF;
        IRocketM = ds.dialogueContainer.IRocketM;
        ISocialF = ds.dialogueContainer.ISocialF;
        ISocialM = ds.dialogueContainer.ISocialM;
        IPowerF = ds.dialogueContainer.IPowerF;
        IPowerM = ds.dialogueContainer.IPowerM;
        IMarketingF = ds.dialogueContainer.IMarketingF;
        IMarketingM = ds.dialogueContainer.IMarketingM;

    }

    // Update is called once per frame
    void Update()
    {
        personagem = GeradorDialogos.personagem;
        pose = GeradorDialogos.pose;
    
        Personagempose(pose,personagem);
    }

    void Personagempose(string pose1, string personagem1)
    {
        switch (personagem1)
        {
            case "":
                break;
            case "Narrador":
                break;
            case "Botz(F)":
                switch (pose1)
                {
                    case "Power":
                        IBotzF.sprite = Resources.Load<Sprite>("Personagens/Power");
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
                switch (pose1)
                {
                    case "SocialFnormal":
                        ISocialF.sprite = Resources.Load<Sprite>("Personagens/Social/SocialFnormal");
                        break;
                    case "SocialFfeliz":
                        ISocialF.sprite = Resources.Load<Sprite>("Personagens/Social/SocialFfeliz");
                        break;
                }
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
