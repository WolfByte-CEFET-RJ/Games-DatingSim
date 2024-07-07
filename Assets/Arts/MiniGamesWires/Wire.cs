using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    public SpriteRenderer wireEnd;
    public GameObject lightOn;
    Vector3 startPoint;
    Vector3 startPosition;
    bool previousLight = false;
    bool previousConnected = false;
    
    void Start()
    {
        startPoint = transform.parent.position;
        startPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        // mouse position to world point
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;

        // Checa por pontos de conexão próximos
        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, .2f);
        foreach (Collider2D collider in colliders)
        {
            // Verifica se não é o próprio colisor
            if (collider.gameObject != gameObject)
            {
                // Atualiza o fio para o posição do ponto de conexão
                UpdateWire(collider.transform.position);

            }
        }

        // Atualiza posição do fio
        UpdateWire(newPosition);
    }

 
    private void OnMouseUp()
    {
        if (previousConnected)
        {
            Counter.Instance.wiresConnected(-1);
            previousConnected = false;
        }

        if (previousLight)
        {
            //o fio estava conectado na posição correta, o jogador move ela, então ela contar um fio certo a menos, se tiver na posição correta, volta na sequência
            Counter.Instance.CountActiveLights(-1);
            previousLight = false;
        }
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, .2f);
        bool hasCollision = false;
        bool hasMultipleCollisions = colliders.Length > 2;
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != gameObject && !hasMultipleCollisions)
            {
                hasCollision = true;
                Counter.Instance.wiresConnected(1);
                previousConnected = true;
                // checa de está na posição correta
                if (transform.parent.name.Equals(collider.transform.parent.name))
                {

                    // Conta a conexão correta
                    Counter.Instance.CountActiveLights(1);
                    previousLight = true;
                }
                break;
            }

        }
        // Reseta a posição do fio se não houver colisão
        if (!hasCollision)
        UpdateWire(startPosition);
    }

    void UpdateWire(Vector3 newPosition)
    {
        // update da posição
        transform.position = newPosition;

        // update da direção
        Vector3 direction = newPosition - startPoint;
        transform.right = direction * transform.lossyScale.x;

        // update da escala do fio
        float dist = Vector2.Distance(startPoint, newPosition);
        wireEnd.size = new Vector2(dist, wireEnd.size.y);

    }
 }
