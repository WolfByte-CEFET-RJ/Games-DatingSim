using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;
    public Slider musicSlider, sfxSlider;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.Log("Já tinha um audio manager então me destruí");
            Destroy(gameObject);
        }

        Debug.Log("SFX Volume loaded: " + PlayerPrefs.GetFloat("SFXVolume", 1f));
        LoadVolumeSettings();
    }

    private void Start()
    {
        PlayMusic("Theme");
    }

    private void OnEnable()
    {
        // Atualizar UI sempre que a cena for carregada
        UpdateVolumeSliders();
    }

    private void LoadVolumeSettings()
    {
        sfxSource.volume = PlayerPrefs.GetFloat("SFXVolume", 1f);
        Debug.Log("SFX Volume loaded: " + PlayerPrefs.GetFloat("SFXVolume", 1f));
        musicSource.volume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        musicSlider.value = musicSource.volume;
        Debug.Log("SFX Volume loaded: " + PlayerPrefs.GetFloat("SFXVolume", 1f));

        Debug.Log("SFX Volume loaded: " + PlayerPrefs.GetFloat("SFXVolume", 1f));
        sfxSlider.value = sfxSource.volume;
        Debug.Log("SFX Volume loaded: " + PlayerPrefs.GetFloat("SFXVolume", 1f));
        musicSource.mute = PlayerPrefs.GetInt("MusicMuted", 0) == 1;
        sfxSource.mute = PlayerPrefs.GetInt("SFXMuted", 0) == 1;
        Debug.Log("SFX Volume loaded: " + PlayerPrefs.GetFloat("SFXVolume", 1f));
    }

    private void SaveVolumeSettings()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicSource.volume);
        PlayerPrefs.SetFloat("SFXVolume", sfxSource.volume);
        PlayerPrefs.SetInt("MusicMuted", musicSource.mute ? 1 : 0);
        PlayerPrefs.SetInt("SFXMuted", sfxSource.mute ? 1 : 0);
        PlayerPrefs.Save();
        Debug.Log("SFX Volume saved: " + PlayerPrefs.GetFloat("SFXVolume", 1f));
    }

    public void UpdateVolumeSliders()
    {
        if (musicSlider != null) musicSlider.value = musicSource.volume;
        if (sfxSlider != null) sfxSlider.value = sfxSource.volume;
    }

    private void OnApplicationQuit()
    {
        SaveVolumeSettings();
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Áudio não encontrado");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Áudio não encontrado");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
        SaveVolumeSettings(); // Salvar o estado de mutação ao alterar
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
        SaveVolumeSettings(); // Salvar o estado de mutação ao alterar
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
        SaveVolumeSettings(); // Salvar o volume ao alterar
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
        SaveVolumeSettings(); // Salvar o volume ao alterar
    }
}
