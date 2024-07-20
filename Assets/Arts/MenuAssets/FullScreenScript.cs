using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FullScreenScript : MonoBehaviour
{
    public Toggle toggle;
    // Start is called before the first frame update

    public TMP_Dropdown resolutionDropDown;
    Resolution[] resolutions;
    void Start()
    {
        if(Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }

        RevisarResolution();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtivarTelaCheia(bool telaCheia)
    {
        Screen.fullScreen = telaCheia;
    }

    public void RevisarResolution()
    {
        resolutions = Screen.resolutions;
        resolutionDropDown.ClearOptions();
        List<string> options = new List<string>();
        options.Add("1280x720");
        options.Add("1600x900");
        options.Add("1920x1080");
        int actualResolution = 0;

        if (Screen.fullScreen && 1280 == Screen.currentResolution.width && 720 == Screen.currentResolution.height)
            actualResolution = 0;

        if (Screen.fullScreen && 1600 == Screen.currentResolution.width && 900 == Screen.currentResolution.height)
            actualResolution = 1;

        if (Screen.fullScreen && 1920 == Screen.currentResolution.width && 1080 == Screen.currentResolution.height)
            actualResolution = 2;



        /*for(int i = 0; i < resolutions.Length; i++)
         {
             string option = resolutions[i].width + "x" + resolutions[i].height;
             if(option == "1280x720" || option == "1920x1080" || option == "1600x900" && !options.Contains(option))
             options.Add(option);

             if (Screen.fullScreen && resolutions[i].width == Screen.currentResolution.width &&
                 resolutions[i].height == Screen.currentResolution.height)
             {
                 actualResolution = i;
             }

         }*/
        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = actualResolution;
        resolutionDropDown.RefreshShownValue();

        resolutionDropDown.value = PlayerPrefs.GetInt("numeroResolution", 0);
    }

    public void ChangeResolution(int indiceResolution)
    {
        switch (indiceResolution)
        {
            case 0:
                PlayerPrefs.SetInt("numeroResolution", 0);
                Screen.SetResolution(1280, 720, Screen.fullScreen);
                Debug.Log("Resolution set to 1280x720");
                break;
            case 1:
                PlayerPrefs.SetInt("numeroResolution", 1);
                Screen.SetResolution(1600, 900, Screen.fullScreen);
                Debug.Log("Resolution set to 1600x900");
                break;
            case 2:
                PlayerPrefs.SetInt("numeroResolution", 2);
                Screen.SetResolution(1920, 1080, Screen.fullScreen);
                Debug.Log("Resolution set to 1920x1080");
                break;
            default:
                Debug.LogError("Índice de resolução inválido: " + indiceResolution);
                break;
        }
    }

}
