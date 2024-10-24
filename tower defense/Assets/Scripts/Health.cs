using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gerencia a saúde dos inimigos no jogo, controlando quando devem ser destruídos e recompensando o jogador por eliminá-los.
public class Health : MonoBehaviour
{
    // Pontos de vida do inimigo. Se chegar a 0, ele é destruído.
    [SerializeField] public int hitPoints = 2 ;
    // Valor em moeda que o jogador recebe ao destruir o inimigo
    [SerializeField] private int currencyWorth = 50;
    // Indica se o inimigo já foi destruído para evitar múltiplas destruições
    private bool isDestroyed = false;



    // Reduz os pontos de vida do inimigo e, se chegar a 0, invoca o evento de destruição, recompensa o jogador e remove o inimigo do jogo.
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
