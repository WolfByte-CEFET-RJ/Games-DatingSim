using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Instancia singular
    public static GameManager Instance;

    // Informações do jogador
    public string playerName;
    public int affectionPoints;

    // Gênero selecionado
    public string selectedGender;

    // Caixa de diálogo selecionada
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

    // Método para salvar informações do jogador
    public void SavePlayerData(string name, int points)
    {
        playerName = name;
        affectionPoints = points;
        // Você pode adicionar aqui outros códigos para salvar essas informações
    }

    // Método para carregar informações do jogador
    public void LoadPlayerData()
    {
        // Você pode adicionar aqui o código para carregar as informações salvas, como de PlayerPrefs ou um arquivo JSON
        // E atribuir os valores carregados às variáveis playerName e affectionPoints
        
        // Carregar o nome do jogador de PlayerPrefs, se existir
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            playerName = PlayerPrefs.GetString("PlayerName");
        }

        // Carregar os pontos de afetividade de PlayerPrefs, se existirem
        if (PlayerPrefs.HasKey("AffectionPoints"))
        {
            affectionPoints = PlayerPrefs.GetInt("AffectionPoints");
        }
    }
}
