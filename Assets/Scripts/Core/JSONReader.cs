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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
