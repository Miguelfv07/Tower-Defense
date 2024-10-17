using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Turret : MonoBehaviour
{
    [SerializeField] private Transform turretRotationPoint;

    [SerializeField] private float targetingRange = 5f; //tamanho do espaço onde a torreta alcança

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
