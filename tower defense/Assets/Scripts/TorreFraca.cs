using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TorreFraca : Turret
{
    public override void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }

        base.Update();
    }

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
