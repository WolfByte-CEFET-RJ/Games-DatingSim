using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

/*
Os metodos e variaveis dessa classe podem ser acessados de qualquer parte do codigo a qualquer momento
Para acessar, basta utilizar:

GameManager.Instance.variavel ou GameManager.Instance.metodo
*/

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

        //Verifica se o Loading foi instanciado
        if(GameObject.Find("Loading") == null) {
            GameObject loading = Instantiate(Resources.Load<GameObject>("Prefabs/Loading"));
            loading.name = "Loading";
        }

    }

    public void LoadNextScene(string NextScene)
    {
        // Carrega a próxima cena
        SceneManager.LoadScene(NextScene);
    }

    // Método que deve ser chamado no fim de cada dia para salvar o jogo (Pode ser substituído por "SaveManager.Instance.SaveGame();" diretamente)
    public void OnDayEnd()
    {
        SaveManager.Instance.SaveGame();
    }

    // Método para carregar as informações salvas
    public void LoadData(SaveData data)
    {
        this.playerName = data.playerName;
        this.affectionPoints = data.affectionPoints;
        this.selectedGender = data.selectedGender;
        this.selectedDialogueBox = data.selectedDialogueBox;
        this.playerSprite = data.playerSprite;
        // Carregar cena correspondente ao dia salvo (Ainda não implementado)
        // LoadNextScene("");
    }

    // Método para atualizar as informações salvas
    public void SaveData(ref SaveData data)
    {
        data.affectionPoints = this.affectionPoints;
        data.day = data.day + 1;
    }

    // Método para atualizar as informações do jogador (nome e gênero)
    public void SavePlayerInfo(ref SaveData data)
    {
        data.playerName = this.playerName;
        data.selectedGender = this.selectedGender;
        data.selectedDialogueBox = this.selectedDialogueBox;
        data.playerSprite = this.playerSprite;
    }
}