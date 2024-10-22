using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class TorreFraca : Turret
{
    public override void Atirar()
    {
        bps = 0.5f;
    }
}
