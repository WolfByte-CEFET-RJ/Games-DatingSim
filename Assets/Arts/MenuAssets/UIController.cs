using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;

    private void OnEnable()
    {
        // Atualiza os sliders para os valores atuais do AudioManager ao ativar
        UpdateSliders();
    }


    private void UpdateSliders()
    {
        // Atualiza os sliders com os valores atuais do AudioManager
        if (_musicSlider != null)
        {
            _musicSlider.value = AudioManager.Instance.musicSource.volume;
        }

        if (_sfxSlider != null)
        {
            _sfxSlider.value = AudioManager.Instance.sfxSource.volume;
        }
    }

    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
    }

    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
    }

    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(_musicSlider.value);
    }
    
    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(_sfxSlider.value);
    }
}
