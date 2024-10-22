using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRed : EnemyBase
{
    public override void Saude()
    {
        Health.instance.hitPoints = 1;
        base.Saude();
    }
}
