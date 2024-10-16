using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoviment : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [Header("Attributres")]
    [SerializeField] private float moveSpeed = 2;

    private Transform target;
    private int pathIndex = 0;

    private void Start()
    {
        target = LevelManager.instance.path[pathIndex];
    }

    private void Update()
    {
        
    }
}
