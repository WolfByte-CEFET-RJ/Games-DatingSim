using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterLeaveOnChoice : MonoBehaviour
{
    // Quantidade de personagens por tela
    private const int characterCount = 4;

    // Array com os personagens (0 é o mais à esquerda, 3 é o mais à direita)
    public GameObject[] characters = new GameObject[characterCount];

    private int screenWidth, track;
    private float leftPos, rightPos;

    private float moveSpeed = 400f;
    private float borderOffset = 70f;

    // Quais personagens vão sair da tela (0 - Personagens da esquerda)
    private int flag = 0;

    private void Awake() {
        leftPos = characters[0].transform.position.x;
        rightPos = characters[1].transform.position.x;
        screenWidth = Camera.main.pixelWidth;
        gameObject.SetActive(false);
    }

    void Update() {
        track = 0;

        if (flag == 0) {
            for (int i = 0; i < 2; i++) {
                if (characters[i] != null) {
                    characters[i].transform.position += Vector3.left * Time.deltaTime * moveSpeed;
                    
                    if (characters[i].transform.position.x < -borderOffset)
                        Destroy(characters[i]);
                } else
                    track++;
            }

            if (characters[2].transform.position.x <= leftPos)
                track++;
            else
                characters[2].transform.position += Vector3.left * Time.deltaTime * moveSpeed;
        }
        else {
            for (int i = 2; i < characterCount; i++) {
                if (characters[i] != null) {
                    characters[i].transform.position += Vector3.right * Time.deltaTime * moveSpeed;

                    if (characters[i].transform.position.x > screenWidth + borderOffset)
                        Destroy(characters[i]);
                } else
                    track++;
            }

            if (characters[1].transform.position.x >= rightPos)
                track++;
            else
                characters[1].transform.position += Vector3.right * Time.deltaTime * moveSpeed;
        }

        if (track == 3)
            gameObject.SetActive(false);
    }

    public void Move(int flag) {
        this.flag = flag;
        gameObject.SetActive(true);
    }
}