using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenery : MonoBehaviour
{
    /* Para os arrays: P = 0, F = 1, S = 3, M = 4 */

    // Atualizar com o conjunto de strings para cada local
    private string[][] strings = new string[][]
    {
        new string[]{"String PC 1", "String PC 2", "String PC 3", "String PC 4"},
        new string[]{"String Flip 1", "String Flip 2", "String Flip 3", "String Flip 4"},
        new string[]{"String Solda 1", "String Solda 2", "String Solda 3", "String Solda 4"},
        new string[]{"String Mesa 1", "String Mesa 2", "String Mesa 3", "String Mesa 4"}
    };

    // Colocar o sprite do objeto da cena a mudar de imagem baseado no cenário
    public SpriteRenderer spriteRenderer;

    // Colocar as imagens a serem usadas para cada local
    public Sprite[] images = new Sprite[4];

    // Colocar os sets de dialogo para cada local
    public GameObject[] dialogueSets = new GameObject[4];

    // Conjunto ativo de falas
    private GameObject currentDialogueSet;

    private void Awake() {
        foreach (GameObject dialogueSet in dialogueSets) {
            dialogueSet.SetActive(false);
        }
    }

    // Script é adicionado aos 4 botões, cada um envia seus parâmetros
    public void OnClick(char scenery, int character) {
        // Descomentar quando o script conversa for adicionado
        // GeradorDialogos.scenery = scenery;

        // Descomentar quando o script selectCharacter for adicionado
        // selectCharacter.character = strings[character];

        // Coloca a imagem do novo cenário
        spriteRenderer.sprite = images[character];

        currentDialogueSet.SetActive(false);
        dialogueSets[character].SetActive(true);
    }
}
