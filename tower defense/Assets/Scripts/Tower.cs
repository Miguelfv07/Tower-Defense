using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable] // Permite que a classe seja exibida e configurada no Inspector do Unity

//Representa uma torre que o jogador pode construir, armazenando informa��es como nome, custo e o prefab associado.
public class Tower 
{
    // Nome da torre, usado para identificar ou exibir no jogo
    public string name;
    // Custo da torre em moedas, necess�rio para verificar se o jogador pode compr�-la
    public int cost;
    // Prefab da torre, que define sua apar�ncia e comportamento no jogo
    public GameObject prefab;

    // Construtor da classe Tower, inicializa os valores de nome, custo e prefab
    public Tower (string _name, int _cost, GameObject _prefab)
    {
        name = _name;
        cost = _cost;
        prefab = _prefab;
    }
}
