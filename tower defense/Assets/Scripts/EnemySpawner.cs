using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Events;

//Responsável por gerenciar a criação e controle dos inimigos que aparecem no jogo, escalonando a dificuldade a cada onda.
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;// Array de prefabs de inimigos a serem instanciados
    [SerializeField] private int baseEnemies = 8;// Número base de inimigos que aparecem em cada onda
    [SerializeField] private float enemiesPerSecond = 0.5f;// Taxa de spawn de inimigos por segundo
    [SerializeField] private float timeBetweenWaves = 5;  // Tempo entre cada onda de inimigos
    [SerializeField] private float difficultyscalingFactor = 0.75f;// Fator de escalonamento da dificuldade com base nas ondas

    public static UnityEvent onEnemyDestroy = new UnityEvent();  // Evento que é acionado quando um inimigo é destruído

    private int currenteWave = 1;// Onda atual de inimigos
    private float timeSinceLastSpawn;// Tempo desde o último inimigo gerado
    public int enemiesAlive;// Número de inimigos atualmente vivos
    private int enemiesLeftToSpawn;// Número de inimigos restantes para spawnar
    private bool isSpawning = false;// Indica se os inimigos estão sendo gerados]

    public static EnemySpawner instance;

    

    //Configura o evento para monitorar a destruição de inimigos.
    private void Awake()
    {
        onEnemyDestroy.AddListener(EnemyDestroyed);
        instance = this;
    }

    //Inicia a primeira onda de inimigos.
    private void Start()
    {
        StartCoroutine(StartWave());
    }

    //Controla a lógica de tempo entre ondas de inimigos.
    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
    }


    //Calcula quantos inimigos devem aparecer na onda atual com base na dificuldade.
    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currenteWave, difficultyscalingFactor));
    }


    //Atualiza o número de inimigos vivos quando um inimigo é destruído.
    private void EnemyDestroyed()
    {
        enemiesAlive--;
    }


    // Gerencia o spawn contínuo de inimigos e a verificação do estado atual.
    private void Update()
    {
        if(!isSpawning) return;

        timeSinceLastSpawn += Time.deltaTime; 

        if(timeSinceLastSpawn >= (1 / enemiesPerSecond) && enemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0;
        }

        if(enemiesAlive == 0 && enemiesLeftToSpawn== 0)
        {
            EndWave();
        }

    
    }

    //Finaliza a onda atual e prepara para a próxima.
    private void EndWave()
    {
        isSpawning = false;
        timeSinceLastSpawn = 0;
        currenteWave++;
        StartCoroutine(StartWave());
    }

    //Cria um novo inimigo a partir de um prefab aleatório na posição de spawn.
    private void SpawnEnemy()
    {
        GameObject prefabToSpawn = enemyPrefabs[Random.RandomRange(0,enemyPrefabs.Length)];
        Instantiate(prefabToSpawn,LevelManager.instance.startPoint.position, Quaternion.identity);
    }
}
