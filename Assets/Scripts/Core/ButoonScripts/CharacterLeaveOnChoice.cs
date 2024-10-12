using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterLeaveOnChoice : MonoBehaviour
{
    private const int characterCount = 2;
    public GameObject[] characters = new GameObject[characterCount];

    private int screenWidth, track;

    // Velocidade da animação dos personagens saindo
    private float speed = 400f;

    // Valor para garantir que os objetos saíram completamente da tela antes de excluí-los
    private float borderOffset = 70f;

    private void Awake()
    {
        screenWidth = Camera.main.pixelWidth;
        gameObject.SetActive(false);
    }

    public void OnClick()
    {
        gameObject.SetActive(true);
    }

    void Update()
    {
        track = 0;
        for (int i = 0; i < characterCount; i++)
        {
            if (characters[i] == null)
            {
                track++;

                if (track == characterCount)
                {
                    Destroy(gameObject);
                    break;
                }
                else continue;
            }

            if (characters[i].transform.position.x < screenWidth / 2)
            {
                characters[i].transform.position += Vector3.left * Time.deltaTime * speed;

                if (characters[i].transform.position.x < -borderOffset)
                    Destroy(characters[i]);
            } else
            {
                characters[i].transform.position += Vector3.right * Time.deltaTime * speed;

                if (characters[i].transform.position.x > screenWidth + borderOffset)
                    Destroy(characters[i]);
            }
        }
    }
}