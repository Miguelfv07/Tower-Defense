using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // Singleton: Permite que a classe BuildManager seja acess�vel globalmente por meio da vari�vel 'instance'
    public static BuildManager instance;

    // Array de torres, definido no Inspector do Unity 
    [SerializeField] private Tower[] towers;


    // �ndice da torre atualmente selecionada
    private int selectedTower = 0;

    // Awake: Inicializa a inst�ncia Singleton quando o objeto � ativado
    private void Awake()
    {
        instance = this;
    }


    // Retorna a torre atualmente selecionada com base no �ndice armazenado
    public Tower GetSelectedTower()
    {
        return towers[selectedTower];
    }

    // Define a torre selecionada, alterando o valor do �ndice de 'selectedTower'
    public void SetSelectedTower(int _selectedTower)
    {
        selectedTower = _selectedTower;
    }
}
