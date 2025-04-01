using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestSceneChange : MonoBehaviour
{
    private int counter;

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
            SceneManager.LoadScene("WordSearch", LoadSceneMode.Additive);
        }
        if (counter == 6000) {
            SceneManager.UnloadSceneAsync("WordSearch");
        }

    }
}
