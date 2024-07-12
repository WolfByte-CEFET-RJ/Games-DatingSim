using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    public TextAsset textJSON;

    [System.Serializable]
    public class Fala
    {
        public int id;
        public string personagem;
        public string dialogo;
    }

    [System.Serializable]
    public class ListaFalas
    {
        public Fala[] fala;

    }
    public ListaFalas lista_de_falas = new ListaFalas();
    // Start is called before the first frame update

    void Start()
    {
        lista_de_falas = JsonUtility.FromJson<ListaFalas>(textJSON.text);
        string playerName = GameManager.Instance.playerName;
        string pronome = ObterPronome(GameManager.Instance.selectedGender);

         foreach (Fala fala in lista_de_falas.fala)
        {
            // Substitui o nome do jogador
            fala.dialogo = fala.dialogo.Replace("[NOME]", playerName);

            // Substitui o pronome baseado no gênero selecionado
            fala.dialogo = fala.dialogo.Replace("[PRONOME]", pronome);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private string ObterPronome(string pronome)
    {
        switch(pronome)
        {
            case "Male":
                return "o";
            case "Female":
                return "a";
            default:
                return "o/a"; // Pronome genérico, você pode ajustar conforme necessário
        }
    }
}
