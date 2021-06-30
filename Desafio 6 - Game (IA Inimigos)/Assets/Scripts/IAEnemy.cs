using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEnemy : MonoBehaviour
{
    public SpriteRenderer sr;

    // Seguir o jogador e campo de visão...
    float SpeedEnemy = 3f;
    float StopDistance = 3.5f; 
    private Transform TargetVision; // Campo de Visão.

    // Patrulha...
    public Transform currentTarget; // Ponto/pivô atual.
    public Transform targetA; // Pivô 1.
    public Transform targetB; // Pivô 2.
    
    void Start()
    {
        // Procura o GameObject com a Tag Player, acessando a sua posição.
        TargetVision = GameObject.FindGameObjectWithTag("Player").transform;

        currentTarget = targetA;
    }


    void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        // Só movimenta o inimigo se a distância entre os dois for menor que a escolhida no StopDistance. Basicamente um campo de visão.
        if (Vector2.Distance(transform.position, TargetVision.position) < StopDistance)
        {
            // Movimenta o gameObject até um ponto específico com uma velocidade.
            transform.position = Vector2.MoveTowards(transform.position, TargetVision.position, SpeedEnemy * Time.deltaTime);
            Debug.LogFormat("Está vendo o Player");
        }
        else
        {
            // movimentação do inimigo até os pivôs.
            transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, SpeedEnemy * Time.deltaTime);

            // movimentação do inimigo em patrulha, do pivô A ao pivô B, e vise versa.
            if (currentTarget == targetA && transform.position == targetA.position)
            {
                currentTarget = targetB;
            }
            if (currentTarget == targetB && transform.position == targetB.position)
            {
                currentTarget = targetA;
            }
        }
    }
}
