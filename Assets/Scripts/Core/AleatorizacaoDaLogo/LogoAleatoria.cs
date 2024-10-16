using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogoAleatoria : MonoBehaviour
{
    public Image Logo;
    public int log;

    // Start is called before the first frame update
    void Start()
    {

        log = Random.Range(1,8);
        

        
    }

    // Update is called once per frame
    void Update()
    {

    switch(log)
    {
        case 1:
            Logo.sprite = Resources.Load<Sprite>("UI/LogosDoNome/LBotz");
            break;
        case 2:
            Logo.sprite = Resources.Load<Sprite>("UI/LogosDoNome/LByte");
            break;
        case 3:
            Logo.sprite = Resources.Load<Sprite>("UI/LogosDoNome/LGestao");
            break;
        case 4:
            Logo.sprite = Resources.Load<Sprite>("UI/LogosDoNome/LMarketing");
            break;
        case 5:
            Logo.sprite = Resources.Load<Sprite>("UI/LogosDoNome/LPower");
            break;
        case 6:
            Logo.sprite = Resources.Load<Sprite>("UI/LogosDoNome/LRocket");
            break;
        case 7:
            Logo.sprite = Resources.Load<Sprite>("UI/LogosDoNome/LSocial");
            break;
        case 8:
            Logo.sprite = Resources.Load<Sprite>("UI/LogosDoNome/LWie");
            break;
        }

    }
}
