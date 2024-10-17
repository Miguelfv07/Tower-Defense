using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSecond = 0.5f;
    [SerializeField] private float timeBetweenWaves = 5;
    [SerializeField] private float difficultyscalingFactor = 0.75f;

    private int currenteWave = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private bool isSpawning = false;

    private void StartWave()
    {
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
    }

    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currenteWave, difficultyscalingFactor));
    }

    private void Update()
    {
        if(!isSpawning) return;

        timeSinceLastSpawn += Time.deltaTime; 

        if(timeSinceLastSpawn >= (1 / enemiesPerSecond))
        {
            Debug.Log("Spawn Enemy");
        }
    
    }
}
