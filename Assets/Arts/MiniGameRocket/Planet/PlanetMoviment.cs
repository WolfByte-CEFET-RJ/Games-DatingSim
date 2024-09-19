using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMoviment : MonoBehaviour
{
    public float speed = 5f;
    private bool endOfTheGame = false;
    // Start is called before the first frame update
    void Start()
    {
        endOfTheGame = false;
    }

    public void setEndOfTheGame()
    {
        endOfTheGame = true;
    }


    void Update()
    {
        if (!endOfTheGame)
        {
            // Move o objeto para a direita com base na velocidade
            transform.Translate(Vector3.left * speed * Time.deltaTime);

            // Se o objeto passar do limite da tela, destrua-o
            if (transform.position.x > Screen.width)
            {
                Destroy(gameObject);
            }
        }
    }
}
