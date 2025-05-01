using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlteraPose : MonoBehaviour
{
    DialogueSystem ds;
    private Image IWieF, IWieM, IGestaoF, IGestaoM, IBotzF, IBotzM, IByteF, IByteM, IRocketF, IRocketM, ISocialF, ISocialM, IPowerF, IPowerM, IMarketingF, IMarketingM;
    private GameObject WieF, WieM, GestaoF, GestaoM, BotzF, BotzM, ByteF, ByteM, RocketF, RocketM, SocialF, SocialM, PowerF, PowerM, MarketingF, MarketingM;

    public string personagem, pose;
    public string personagem1, pose1;

    public CharacterItem currentCharacter;

    private Image currentSprite;
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


    }

    // Update is called once per frame
    void Update()
    {
        personagem = GeradorDialogos.personagem;
        pose = GeradorDialogos.pose;
        currentCharacter = CharacterImageContr.instance.selectCharByName(personagem);
        currentSprite = getCurrentSprite(personagem);
        if(pose != "" && currentSprite != null)
        {
            Personagempose(pose, personagem);
        }
    }

    void Personagempose(string pose1, string personagem1)
    {
        currentSprite.sprite = currentCharacter.getPoseByName(pose1);
    }
    Image getCurrentSprite(string nam)
    {
        switch (nam)
        {
            case "":
                return null;
            
            case "Narrador":
        
                return null;
            case "???":
                return null;

            case "Botz(F)":
                return IBotzF;

            case "Botz(M)":
                return IBotzM;

            case "Byte(F)":
                return IByteF;

            case "Byte(M)":
                return IByteM;

            case "Power(F)":
                return IPowerF;

            case "Power(M)":
                return IPowerM;

            case "Rocket(F)":
                return IRocketF;

            case "Rocket(M)":
                return IRocketM;

            case "Social(F)":
                return ISocialF;

            case "Social(M)":
                return ISocialM;

            case "Wie(F)":
                return IWieF;

            case "Wie(M)":
                return IWieM;

            case "Gestão(F)":
                return IGestaoF;

            case "Gestão(M)":
                return IGestaoM;

            case "Marketing(F)":
                return IMarketingF;

            case "Marketing(M)":
                return IMarketingM;

            default:
                return null;
        }
    }
}
