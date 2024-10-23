using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class Turret : MonoBehaviour, ITorre
{
    [SerializeField] protected Transform turretRotationPoint;
    [SerializeField] public LayerMask enemyMask;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;

    [SerializeField] public float targetingRange = 5f; //tamanho do espaço onde a torreta alcança
    [SerializeField] private float rotationSpeed = 5;
    [SerializeField] public float bps;// bullets por segundo

    protected Transform target;
    private float timeUntilFire;

    public virtual void Update()
    {
       
    
        
     

        RotateTowardsTarget();

       if( !CheckTargetIsInRange())
        {
            target = null;
        }
        else
        {
            timeUntilFire += Time.deltaTime;

            if(timeUntilFire >= 1/bps)
            {
                Shoot();
                timeUntilFire = 0;
            }
        }

    }

  

    private void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetTarget(target);
        
    }

     public virtual void FindTarget()
    {

    }

    private bool CheckTargetIsInRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }

    private void RotateTowardsTarget()
    {
        float angle = MathF.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));

        turretRotationPoint.rotation = Quaternion.RotateTowards(turretRotationPoint.rotation, targetRotation,rotationSpeed* Time.deltaTime);
    }



    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }
}
