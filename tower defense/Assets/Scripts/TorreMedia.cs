using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreMedia : Turret
{

    public override void Update()
    {
        FindTarget();

        base.Update();
    }

    public override void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, enemyMask);

        if (hits.Length > 0)
        {

            float menorDistancia = Vector2.Distance(transform.position, hits[0].transform.position);
            int inimigoEscolhido = 0;


            for (int i = 0; i < hits.Length; i++)
            {
                float distancia = Vector2.Distance(transform.position, hits[i].transform.position);

                if (distancia < menorDistancia)
                {
                    menorDistancia = distancia;
                    inimigoEscolhido = i;
                }


            }

            target = hits[inimigoEscolhido].transform;

        }


    }
}
