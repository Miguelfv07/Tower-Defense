using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


// Classe "TorreFraca" herda de "Turret" e representa uma torre especializada com comportamento personalizado.
public class TorreFraca : Turret
{

    //Verifica se há um alvo.Caso contrário, tenta encontrar um novo.Se já há alvo, continua com o comportamento herdado da classe pai.
    public override void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }

        base.Update();
    }


    //Realiza um CircleCastAll para encontrar inimigos próximos e define o primeiro inimigo encontrado como alvo.
    public override void FindTarget()
    {

        base.FindTarget();
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, enemyMask);
        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }
}
