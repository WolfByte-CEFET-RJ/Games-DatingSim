using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    static public Main Instance;
    public GameObject winText;

    private void Awake()
    {
        Instance = this;
    }
    public void ShowWinText()
    {
        if (Counter.Instance.activeLightsCount == 4)
        {
            winText.SetActive(true);
        }
    }
    private void Update()
    {
        //reinicia cena
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
