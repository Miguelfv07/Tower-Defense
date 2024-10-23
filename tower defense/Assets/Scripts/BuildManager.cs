using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // Singleton: Permite que a classe BuildManager seja acessível globalmente por meio da variável 'instance'
    public static BuildManager instance;

    // Array de torres, definido no Inspector do Unity 
    [SerializeField] private Tower[] towers;


    // Índice da torre atualmente selecionada
    private int selectedTower = 0;

    // Awake: Inicializa a instância Singleton quando o objeto é ativado
    private void Awake()
    {
        instance = this;
    }


    // Retorna a torre atualmente selecionada com base no índice armazenado
    public Tower GetSelectedTower()
    {
        return towers[selectedTower];
    }

    // Define a torre selecionada, alterando o valor do índice de 'selectedTower'
    public void SetSelectedTower(int _selectedTower)
    {
        selectedTower = _selectedTower;
    }
}
