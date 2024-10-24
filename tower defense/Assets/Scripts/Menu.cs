using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;


//Gerencia a interface do menu relacionada à exibição da moeda do jogador.
public class Menu : MonoBehaviour
{
    // Exibe o valor atual da moeda do jogador na interface
    [SerializeField] TextMeshProUGUI currencyUI;

    // Atualiza o texto da moeda na interface a cada quadro renderizado
    private void OnGUI()
    {
        currencyUI.text = LevelManager.instance.currency.ToString();
    }

}
