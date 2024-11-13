using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe LevelManager gerencia uma parte do caminho dos inimigos, ponto de spawn inicial e a moeda do jogador.

public class LevelManager : MonoBehaviour
{
    // Singleton: Permite acesso global à única instância de LevelManager
    public static LevelManager instance;

    // Array de pontos que compõem o caminho (path) que os inimigos seguirão
    public Transform[] path;

    // Ponto inicial de onde os inimigos começam no nível
    public Transform startPoint;

    // Moeda do jogador, utilizada para realizar compras ou ações no jogo
    public int currency;

    public int contagemMorte = 0;

    [SerializeField]
    public GameObject gameOverPanel;

    // Awake: Inicializa a instância Singleton quando o objeto é ativado
    private void Awake()
    {
        instance = this;
    }

    // Start: Define a quantidade inicial de moeda para o jogador
    private void Start()
    {
        currency = 250;
    }

    // Aumenta a quantidade de moeda do jogador
    public void IncreaseCurrency(int amount)
    {
        currency += amount;
    }

    // Tenta gastar moeda. Retorna true se houver saldo suficiente, caso contrário, retorna false
    public bool SpendCurrency(int amount)
    {
        if (amount <= currency)
        {
            currency -= amount;
            return true;
        }
        else
        {
            Debug.Log("Não tem dinheiro");
            return false;
        {

            }
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        Propaganda.instance.relogio = 0;
        Propaganda.instance.relogio2 = 0;
        gameOverPanel.SetActive(true);
        contagemMorte = 0;
    }

    public void Adicionar() 
    {
        contagemMorte++;
    }
}
