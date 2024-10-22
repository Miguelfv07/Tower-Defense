using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public int hitPoints = 2 ;
    [SerializeField] private int currencyWorth = 50;
    private bool isDestroyed = false;
    public static Health instance;

    private void Awake()
    {
        instance = this;
    }



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
