using System.Collections;
using UnityEngine;


public class scene1 : MonoBehaviour
{
    public GameObject root;
    public GameObject background, nome, textbox,personagem;
    


    void Start()
    {
        root.SetActive(false);
    
    }


    IEnumerator EventStart()
    {
        yield return new WaitForSeconds(0);
        root.SetActive(true); 
        background.SetActive(true);
        //personagem1.SetActive(true); 
        //personagem2.SetActive(true);
        nome.SetActive(true);
        personagem = GameObject.Find("NameText");
        Debug.Log(personagem.GetComponent<UnityEngine.UI.Text>());
        }


    public void Button()
    {
        StartCoroutine(EventStart());   
    }
}