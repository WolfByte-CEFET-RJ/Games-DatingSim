using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeChildren : MonoBehaviour
{
    private bool GameIsOver = false;
    // Randomiza a posição dos fios na esquerda
    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            int newSpot = Random.Range(0, transform.childCount);
            Vector3 temp = transform.GetChild(i).position;
            transform.GetChild(i).position = transform.GetChild(newSpot).position;
            transform.GetChild(newSpot).position = temp;
        }
    }

    private void Update()
    {
        if(Counter.Instance.EndGame == true && GameIsOver == false)
        {
            DisableCollidersRecursive(transform);
        }
    }

    private void DisableCollidersRecursive(Transform parent)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);

            // Desabilita o collider 2D se existir
            Collider2D collider2D = child.GetComponent<Collider2D>();
            if (collider2D != null)
            {
                collider2D.enabled = false;
            }
            // Chamada recursiva para filhos deste objeto
            DisableCollidersRecursive(child);
        }
    }

    private void EnableCollidersRecursive(Transform parent)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);

            // Desabilita o collider 2D se existir
            Collider2D collider2D = child.GetComponent<Collider2D>();
            if (collider2D != null)
            {
                collider2D.enabled = true;
            }
            // Chamada recursiva para filhos deste objeto
            EnableCollidersRecursive(child);
        }
    }

    public void DisableWires()
    {
        DisableCollidersRecursive(transform);
    }

    public void EnableWires()
    {
        EnableCollidersRecursive(transform);
    }
}
