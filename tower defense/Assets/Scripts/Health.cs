using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gerencia a sa�de dos inimigos no jogo, controlando quando devem ser destru�dos e recompensando o jogador por elimin�-los.
public class Health : MonoBehaviour
{
    // Pontos de vida do inimigo. Se chegar a 0, ele � destru�do.
    [SerializeField] public int hitPoints = 2 ;
    // Valor em moeda que o jogador recebe ao destruir o inimigo
    [SerializeField] private int currencyWorth = 50;
    // Indica se o inimigo j� foi destru�do para evitar m�ltiplas destrui��es
    private bool isDestroyed = false;



    // Reduz os pontos de vida do inimigo e, se chegar a 0, invoca o evento de destrui��o, recompensa o jogador e remove o inimigo do jogo.
    public void TakeDamage(int dmg)
    {
        hitPoints -= dmg;

        if(hitPoints <= 0 && !isDestroyed)
        {
            EnemySpawner.onEnemyDestroy.Invoke();
            isDestroyed = true;
            LevelManager.instance.IncreaseCurrency(currencyWorth);
            Destroy(gameObject);
        }
    }
}
