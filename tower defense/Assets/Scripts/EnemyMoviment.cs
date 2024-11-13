using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gerencia o comportamento de movimenta��o dos inimigos, permitindo que eles sigam um caminho pr�-definido em dire��o ao objetivo do jogo 
public class EnemyMoviment : MonoBehaviour
{
    [Header("References")]
    // Refer�ncia ao componente Rigidbody2D para movimenta��o
    [SerializeField] private Rigidbody2D rb;
    [Header("Attributres")]
    // Velocidade de movimento do inimigo
    [SerializeField] private float moveSpeed = 2;

    int contagemMorte = 0;

    // Transform do pr�ximo alvo que o inimigo deve seguir
    private Transform target;

    // �ndice para rastrear a posi��o atual no caminho
    private int pathIndex = 0;


    //Inicializa o movimento do inimigo definindo seu primeiro alvo, garantindo que ele tenha um ponto de partida.
    private void Start()
    {
        target = LevelManager.instance.path[pathIndex];
    }

    // Controla a l�gica de movimenta��o, detectando quando o inimigo chega a um ponto do caminho e decide se deve avan�ar para o pr�ximo ponto ou se deve ser destru�do ao atingir o final do caminho.
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

    //Aplica a f�sica ao inimigo, movendo-o de forma suave e controlada em dire��o ao pr�ximo alvo, utilizando a velocidade definida para simular um movimento realista.
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
