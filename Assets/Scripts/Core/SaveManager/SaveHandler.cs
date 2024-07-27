using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class SaveHandler
{
    private string directoryName = "";
    private string fileName = "";

    // Construtor para dar o diretório e nome do arquivo de save
    public SaveHandler(string directoryName, string fileName)
    {
        this.directoryName = directoryName;
        this.fileName = fileName;
    }

    // Método para carregar o jogo com os dados salvos
    public SaveData Load()
    {
        // Caminho do arquivo de save
        string path = Path.Combine(directoryName, fileName);

        SaveData loadedData = null;

        if (File.Exists(path))
        {
            try
            {
                string loadData = "";

                // Lê o arquivo de save e armazena os dados
                using (FileStream stream = new FileStream(path, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        loadData = reader.ReadToEnd();
                    }
                }

                // Traduz os dados salvos para o formato desejado
                loadedData = JsonUtility.FromJson<SaveData>(loadData);
            }
            catch (Exception e)
            {
                Debug.LogError("An error occurred while trying to load the game from the file " + path + "\n" + e);
            }
        }

        return loadedData;
    }

    // Método para atualizar o arquivo de save com novos dados
    public void Save(SaveData data)
    {
        // Caminho do arquivo de save
        string path = Path.Combine(directoryName, fileName);

        try
        {
            // Garante que o diretório desejado existe
            Directory.CreateDirectory(directoryName);

            // Traduz os dados do jogo para JSON
            string storeData = JsonUtility.ToJson(data, true);

            // Atualiza o arquivo de save com os novos dados
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(storeData);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("An error occurred while trying to save the game to the file " + path + "\n" + e);
        }
    }
}
