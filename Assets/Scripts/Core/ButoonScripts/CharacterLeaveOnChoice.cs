using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLeaveOnChoice : MonoBehaviour
{
    // Array para armazenar os personagens (pode ter qualquer número de personagens)
    public GameObject[] characters;

    private int screenWidth;
    private float moveSpeed = 10f;
    private float borderOffset = 70f;

    private void Awake() {

        leftPos = characters[0].transform.position.x;
        rightPos = characters[1].transform.position.x;
        screenWidth = Camera.main.pixelWidth;
        gameObject.SetActive(false);  // Garante que o objeto comece desativado
    }

    // Move um personagem específico para fora da tela
    public void Move(int characterIndex, int direction) {
        // Reativa o GameObject para garantir que o movimento possa começar
        gameObject.SetActive(true);

        // Verifica se o índice é válido
        if (characterIndex < 0 || characterIndex >= characters.Length || characters[characterIndex] == null) {
            return; // Não faz nada se o índice estiver fora dos limites ou o personagem for nulo
        }

        // Pega o personagem e sua posição inicial
        GameObject character = characters[characterIndex];
        Vector3 targetPosition = character.transform.position;

        // Define a posição alvo com base na direção
        if (direction == 0) {
            // Move para a esquerda
            targetPosition.x -= 1;
        }
        else if (direction == 1) {
            // Move para a direita
            targetPosition.x += 1;
        }

        // Move o personagem gradualmente na direção apropriada
        StartCoroutine(MoveCharacterOut(character, targetPosition, direction));
    }

    // Coroutine para mover o personagem até que ele saia da tela
    private IEnumerator MoveCharacterOut(GameObject character, Vector3 targetPosition, int direction) {
        // Calcula a direção do movimento
        float moveDirection = (direction == 0) ? -1f : 1f;

        // Move o personagem gradualmente para fora da tela
        while (direction == 0 ? character.transform.position.x > -borderOffset : character.transform.position.x < screenWidth + borderOffset) {
            character.transform.position += new Vector3(moveDirection * Time.deltaTime * moveSpeed, 0f, 0f);
            yield return null; // Espera até o próximo frame
        }

        // Depois que o personagem sair da tela, destrói ele
        Destroy(character);

        // Desativa o GameObject depois que o movimento for concluído
        gameObject.SetActive(false);
    }
}