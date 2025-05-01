using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisibilidadeEPose : MonoBehaviour
{
    DialogueSystem ds;
    private Image IWieF, IWieM, IGestaoF, IGestaoM, IBotzF, IBotzM, IByteF, IByteM, IRocketF, IRocketM, ISocialF, ISocialM, IPowerF, IPowerM, IMarketingF, IMarketingM;
    private GameObject WieF, WieM, GestaoF, GestaoM, BotzF, BotzM, ByteF, ByteM, RocketF, RocketM, SocialF, SocialM, PowerF, PowerM, MarketingF, MarketingM;
    private List<GameObject> personagensList;

    public string personagem;

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
        claridade(personagem);
    }

    void claridade(string mud)
    {
        // Cores para default e cores para Destaque
        Color32 defaultColor = new Color32(120, 120, 120, 255);
        Color32 highlightColor = new Color32(255, 255, 255, 255);

        // Ligando strings em GameObject
        var elements = new Dictionary<string, GameObject>
    {
        { "Botz(F)", BotzF },
        { "Botz(M)", BotzM },
        { "Wie(F)", WieF },
        { "Wie(M)", WieM },
        { "Power(F)", PowerF },
        { "Power(M)", PowerM },
        { "Byte(F)", ByteF },
        { "Byte(M)", ByteM },
        { "Rocket(F)", RocketF },
        { "Rocket(M)", RocketM },
        { "Social(F)", SocialF },
        { "Social(M)", SocialM },
        { "Gest�o(F)", GestaoF },
        { "Gest�o(M)", GestaoM },
        { "Marketing(F)", MarketingF },
        { "Marketing(M)", MarketingM }
    };

        // Como princ�pio, altera todos para cores default (n�o destacados)
        foreach (var element in elements.Values)
        {
            element.GetComponent<Image>().color = defaultColor;
        }

        // Destaca o personagem conforme a string recebida, caso ele n�o encontre a chave do personagem, todos seguem em default.
        if (!string.IsNullOrEmpty(mud) && elements.ContainsKey(mud))
        {
            elements[mud].GetComponent<Image>().color = highlightColor;
        }

        // Limita��o atual: Somente um personagem � destacado por vez. 
    }


}
