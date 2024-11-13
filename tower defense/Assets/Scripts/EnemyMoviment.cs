using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gerencia o comportamento de movimentação dos inimigos, permitindo que eles sigam um caminho pré-definido em direção ao objetivo do jogo 
public class EnemyMoviment : MonoBehaviour
{
    [Header("References")]
    // Referência ao componente Rigidbody2D para movimentação
    [SerializeField] private Rigidbody2D rb;
    [Header("Attributres")]
    // Velocidade de movimento do inimigo
    [SerializeField] private float moveSpeed = 2;

    int contagemMorte = 0;

    // Transform do próximo alvo que o inimigo deve seguir
    private Transform target;

    // Índice para rastrear a posição atual no caminho
    private int pathIndex = 0;


    //Inicializa o movimento do inimigo definindo seu primeiro alvo, garantindo que ele tenha um ponto de partida.
    private void Start()
    {
        target = LevelManager.instance.path[pathIndex];
    }

    // Controla a lógica de movimentação, detectando quando o inimigo chega a um ponto do caminho e decide se deve avançar para o próximo ponto ou se deve ser destruído ao atingir o final do caminho.
    private void Update()
    {
        if(Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            pathIndex++;

            if (pathIndex == LevelManager.instance.path.Length)
            {
             
                EnemySpawner.onEnemyDestroy.Invoke();
                Destroy(gameObject);
                

                return;
            }
            else
            {
                target = LevelManager.instance.path[pathIndex];
            }
        }

        if(LevelManager.instance.contagemMorte >= 10)
        {
           LevelManager.instance.GameOver();
        }
    }

    //Aplica a física ao inimigo, movendo-o de forma suave e controlada em direção ao próximo alvo, utilizando a velocidade definida para simular um movimento realista.
    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("PontoFinal"))
        {
            LevelManager.instance.Adicionar();
        }
    }
}
