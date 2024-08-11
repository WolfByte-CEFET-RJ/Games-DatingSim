using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    // Inicializa as variáveis de dados e gerenciamento de save
    private SaveData saveData;
    private SaveHandler saveHandler;

    // Cria uma instância pública para leitura, mas privada para edição
    public static SaveManager Instance { get; private set; }

    private void Awake()
    {
        // Verifica se existe apenas uma instância ativa
        if (Instance != null)
            Debug.Log("More than one save manager active");
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Método chamado ao clicar no botão Jogar (O botão ainda deve ser implementado)
    public void OnPlay()
    {
        this.saveHandler = new SaveHandler(Application.persistentDataPath, "game_save_slot");
        LoadGame();
    } 

    // Método para criar um novo jogo
    public void NewGame()
    {
        this.saveData = new SaveData();
    }

    // Método para carregar as informações salvas para o jogo
    public void LoadGame()
    {
        this.saveData = saveHandler.Load();

        // Inicia um novo jogo caso não haja arquivo de save
        if (this.saveData == null)
        {
            Debug.Log("No save found. Starting a new game.");
            NewGame();
        }

        GameManager.Instance.LoadData(saveData);
    }

    // Método para salvar os dados referentes ao jogo
    public void SaveGame()
    {
        GameManager.Instance.SaveData(ref saveData);

        saveHandler.Save(saveData);
    }

    // Método para salvar as informações do jogador (nome e gênero)
    public void SavePlayerInfo()
    {
        GameManager.Instance.SavePlayerInfo(ref saveData);

        saveHandler.Save(saveData);
    }
}
