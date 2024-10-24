using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A classe "TorreMedia" � uma especializa��o da classe "Turret".
// Ela busca constantemente o inimigo mais pr�ximo para atacar.
public class TorreMedia : Turret
{

    // Sobrescreve o m�todo Update para buscar um alvo em cada quadro antes de executar o comportamento padr�o.
    public override void Update()
    {
        FindTarget();

        base.Update();
    }


    // Implementa a l�gica para encontrar o inimigo mais pr�ximo da torre.
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
