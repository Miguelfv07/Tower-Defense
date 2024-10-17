using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    [SerializeField] private float bulletSpeed = 5;

    private Transform target;
}
