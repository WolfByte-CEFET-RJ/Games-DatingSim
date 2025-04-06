using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestSceneChange : MonoBehaviour
{
    public int counter;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        counter += 1;

        if (counter == 600) {
            //Debug.Log("Word Seacher is on");
            SceneManager.LoadSceneAsync("WordSearch", LoadSceneMode.Additive);
        }
        if (counter == 6000) {
            //Debug.Log("Word Seacher is off");
            SceneManager.UnloadSceneAsync("WordSearch");
        }

    }
}
