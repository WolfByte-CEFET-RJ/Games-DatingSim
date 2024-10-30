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
        claridade(personagem);
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
                        //IBotzF.sprite = Resources.Load<Sprite>("Personagens/Power");
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

    void claridade(string mud)
    {
        switch (mud)
        {
            case "":
                BotzF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                BotzM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                WieF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                WieM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                PowerF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                PowerM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                ByteF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                ByteM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                RocketF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                RocketM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                SocialF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                SocialM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                GestaoF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                GestaoM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                MarketingF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                MarketingM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                break;
            case "Narrador":
                BotzF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                BotzM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                WieF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                WieM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                PowerF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                PowerM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                ByteF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                ByteM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                RocketF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                RocketM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                SocialF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                SocialM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                GestaoF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                GestaoM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                MarketingF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                MarketingM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);                    
                break;
            case "Botz(F)":
                BotzF.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                BotzM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                WieF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                WieM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                PowerF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                PowerM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                ByteF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                ByteM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                RocketF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                RocketM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                SocialF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                SocialM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                GestaoF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                GestaoM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                MarketingF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                MarketingM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);                    
                break;
            case "Botz(M)":
                BotzF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                BotzM.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                WieF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                WieM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                PowerF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                PowerM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                ByteF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                ByteM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                RocketF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                RocketM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                SocialF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                SocialM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                GestaoF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                GestaoM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                MarketingF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                MarketingM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);                    
                break;
            case "Byte(F)":
                BotzF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                BotzM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                WieF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                WieM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                PowerF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                PowerM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                ByteF.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                ByteM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                RocketF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                RocketM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                SocialF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                SocialM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                GestaoF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                GestaoM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                MarketingF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                MarketingM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);                    
                break;
            case "Byte(M)":
                BotzF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                BotzM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                WieF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                WieM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                PowerF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                PowerM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                ByteF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                ByteM.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                RocketF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                RocketM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                SocialF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                SocialM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                GestaoF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                GestaoM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                MarketingF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                MarketingM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);                    
                break;
            case "Power(F)":
                BotzF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                BotzM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                WieF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                WieM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                PowerF.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                PowerM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                ByteF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                ByteM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                RocketF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                RocketM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                SocialF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                SocialM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                GestaoF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                GestaoM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                MarketingF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                MarketingM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);                    
                break;
            case "Power(M)":
                BotzF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                BotzM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                WieF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                WieM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                PowerF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                PowerM.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                ByteF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                ByteM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                RocketF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                RocketM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                SocialF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                SocialM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                GestaoF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                GestaoM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                MarketingF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                MarketingM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);                    
                break;
            case "Rocket(F)":
                BotzF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                BotzM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                WieF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                WieM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                PowerF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                PowerM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                ByteF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                ByteM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                RocketF.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                RocketM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                SocialF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                SocialM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                GestaoF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                GestaoM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                MarketingF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                MarketingM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);                    
                break;
            case "Rocket(M)":
                BotzF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                BotzM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                WieF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                WieM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                PowerF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                PowerM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                ByteF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                ByteM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                RocketF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                RocketM.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                SocialF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                SocialM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                GestaoF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                GestaoM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                MarketingF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                MarketingM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);                    
                break;
            case "Social(F)":
                BotzF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                BotzM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                WieF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                WieM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                PowerF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                PowerM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                ByteF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                ByteM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                RocketF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                RocketM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                SocialF.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                SocialM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                GestaoF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                GestaoM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                MarketingF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                MarketingM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);                    
                break;
            case "Social(M)":
                BotzF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                BotzM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                WieF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                WieM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                PowerF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                PowerM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                ByteF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                ByteM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                RocketF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                RocketM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                SocialF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                SocialM.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                GestaoF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                GestaoM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                MarketingF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                MarketingM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);                    
                break;
            case "Wie(F)":
                BotzF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                BotzM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                WieF.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                WieM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                PowerF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                PowerM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                ByteF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                ByteM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                RocketF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                RocketM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                SocialF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                SocialM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                GestaoF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                GestaoM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                MarketingF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                MarketingM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);                    
                break;
            case "Wie(M)":
                BotzF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                BotzM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                WieF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                WieM.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                PowerF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                PowerM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                ByteF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                ByteM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                RocketF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                RocketM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                SocialF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                SocialM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                GestaoF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                GestaoM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                MarketingF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                MarketingM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);                    
                break;
            case "Gestão(F)":
                BotzF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                BotzM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                WieF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                WieM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                PowerF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                PowerM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                ByteF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                ByteM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                RocketF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                RocketM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                SocialF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                SocialM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                GestaoF.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                GestaoM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                MarketingF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                MarketingM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);                    
                break;
            case "Gestão(M)":
                BotzF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                BotzM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                WieF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                WieM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                PowerF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                PowerM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                ByteF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                ByteM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                RocketF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                RocketM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                SocialF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                SocialM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                GestaoF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                GestaoM.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                MarketingF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                MarketingM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);                    
                break;
            case "Marketing(F)":
                BotzF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                BotzM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                WieF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                WieM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                PowerF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                PowerM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                ByteF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                ByteM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                RocketF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                RocketM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                SocialF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                SocialM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                GestaoF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                GestaoM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                MarketingF.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                MarketingM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);                    
                break;
            case "Marketing(M)":
                BotzF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                BotzM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                WieF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                WieM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                PowerF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                PowerM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                ByteF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                ByteM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                RocketF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                RocketM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                SocialF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                SocialM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                GestaoF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                GestaoM.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                MarketingF.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                MarketingM.GetComponent<Image>().color = new Color32(255, 255, 255, 255);                    
                break;
        }
    }


}
