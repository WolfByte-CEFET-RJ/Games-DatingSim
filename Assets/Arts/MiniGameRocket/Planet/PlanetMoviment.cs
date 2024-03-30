using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMoviment : MonoBehaviour
{
    public float speed = 5f;


    void Update()
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
