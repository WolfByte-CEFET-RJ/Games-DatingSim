using System.Collections;
using UnityEngine;


public class scene1 : MonoBehaviour
{
    public GameObject root;
    


    void Start()
    {
        root.SetActive(false);
    
    }


    IEnumerator EventStart()
    {
        yield return new WaitForSeconds(0);
        root.SetActive(true); 
        
        //personagem = GameObject.Find("NameText");
        //Debug.Log(personagem.GetComponent<UnityEngine.UI.Text>());
        }


    public void Button()
    {
        StartCoroutine(EventStart());   
    }
}