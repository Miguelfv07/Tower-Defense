using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Representa um espaço onde o jogador pode construir uma torre. Controla a interação visual e verifica se a torre pode ser construída com base na moeda disponível.
public class Square : MonoBehaviour
{
    // Controla a aparência visual do quadrado no qual uma torre pode ser construída
    [SerializeField] private SpriteRenderer sr;
    // Cor que o quadrado adota quando o mouse passa por cima
    [SerializeField] private Color hoverColor;
    // Referência à torre que pode ser construída neste quadrado
    private GameObject tower;

    // Armazena a cor inicial do quadrado para restaurá-la quando necessário
    private Color startColor;

    // Inicializa a cor do quadrado com a cor original definida no SpriteRenderer
    private void Start()
    {
        startColor = sr.color;
    }

    // Altera a cor do quadrado quando o mouse entra em sua área
    private void OnMouseEnter()
    {
        sr.color = hoverColor;
    }

    // Restaura a cor original do quadrado quando o mouse sai de sua área
    private void OnMouseExit()
    {
        sr.color = startColor;
    }


    // Executa a lógica de construção de uma torre ao clicar no quadrado
    private void OnMouseDown()
    {
        if (tower != null) return;

        Tower towerToBuild = BuildManager.instance.GetSelectedTower();

        if (towerToBuild.cost > LevelManager.instance.currency)
        {
            Debug.Log("Deu certo");
            return;
        }

        LevelManager.instance.SpendCurrency(towerToBuild.cost);
        tower = Instantiate(towerToBuild.prefab,transform.position, Quaternion.identity);
    }
}
