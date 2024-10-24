using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// A classe "TorreTop" é uma especialização da torre que busca sempre o inimigo mais distante dentro de seu alcance.
public class TorreTop : Turret
{

    // A cada quadro, busca um alvo e executa o comportamento herdado da classe "Turret".
    public override void Update()
    {
        FindTarget();

        base.Update();
    }

    // Implementa a lógica para encontrar o inimigo mais distante.
    public override void FindTarget()
    {
        if (target == null)
        {
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, enemyMask);

            if (hits.Length > 0)
            {

                float maiorDistancia = Vector2.Distance(transform.position, hits[0].transform.position);
                int inimigoEscolhido = 0;


                for (int i = 0; i < hits.Length; i++)
                {
                    float distancia = Vector2.Distance(transform.position, hits[i].transform.position);

                    if (distancia > maiorDistancia)
                    {
                        maiorDistancia = distancia;
                        inimigoEscolhido = i;
                    }


                }

                target = hits[inimigoEscolhido].transform;

            }
        }
       
    }
}
