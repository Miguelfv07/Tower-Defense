using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Turret : MonoBehaviour
{
    [SerializeField] private Transform turretRotationPoint;

    [SerializeField] private float targetingRange = 5f; //tamanho do espa�o onde a torreta alcan�a

    private Transform target;

    private void Update()
    {
        if (target == null)
        {
            FindTarget();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }
}
