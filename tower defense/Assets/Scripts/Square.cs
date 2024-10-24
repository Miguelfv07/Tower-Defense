using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Representa um espa�o onde o jogador pode construir uma torre. Controla a intera��o visual e verifica se a torre pode ser constru�da com base na moeda dispon�vel.
public class Square : MonoBehaviour
{
    // Controla a apar�ncia visual do quadrado no qual uma torre pode ser constru�da
    [SerializeField] private SpriteRenderer sr;
    // Cor que o quadrado adota quando o mouse passa por cima
    [SerializeField] private Color hoverColor;
    // Refer�ncia � torre que pode ser constru�da neste quadrado
    private GameObject tower;

    // Armazena a cor inicial do quadrado para restaur�-la quando necess�rio
    private Color startColor;

    // Inicializa a cor do quadrado com a cor original definida no SpriteRenderer
    private void Start()
    {
        startColor = sr.color;
    }

    // Altera a cor do quadrado quando o mouse entra em sua �rea
    private void OnMouseEnter()
    {
        sr.color = hoverColor;
    }

    // Restaura a cor original do quadrado quando o mouse sai de sua �rea
    private void OnMouseExit()
    {
        sr.color = startColor;
    }


    // Executa a l�gica de constru��o de uma torre ao clicar no quadrado
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
