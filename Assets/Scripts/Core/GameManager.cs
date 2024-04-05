using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Instancia singular
    public static GameManager Instance;

    // Gênero selecionado
    public string selectedGender;

    // Caixa de dialogo selecionada
    public GameObject selectedDialogueBox;

    // Sprite para personagem que deve receber um gênero 
    public Sprite playerSprite;

    private void Awake()
    {
        // Afirma que apenas uma instancia do GameManager pode existir
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

     public void LoadNextScene(string NextScene)
    {
        // Carrega a próxima cena
        SceneManager.LoadScene(NextScene);
    }
}

