using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


// Controla o comportamento de uma torreta no jogo, incluindo mira, disparo e rotação em direção aos inimigos.Serve como Classe Base das torretas.
public class Turret : MonoBehaviour, ITorre
{
    // Ponto de rotação da torreta (para girar em direção ao inimigo)
    [SerializeField] protected Transform turretRotationPoint;
    // Máscara de detecção de inimigos (define quais objetos são reconhecidos como inimigos)
    [SerializeField] public LayerMask enemyMask;
    // Prefab do projétil que a torreta dispara
    [SerializeField] private GameObject bulletPrefab;
    // Ponto de disparo de onde os projéteis são criados
    [SerializeField] private Transform firingPoint;

    [SerializeField] public float targetingRange = 5f; //Alcance da torreta para detectar alvos
    [SerializeField] private float rotationSpeed = 5;  // Velocidade de rotação da torreta ao seguir um alvo
    [SerializeField] public float bps; // Taxa de disparo (balas por segundo)

    // Referência ao inimigo que está sendo mirado
    protected Transform target;
    // Tempo até a torreta disparar novamente
    private float timeUntilFire;


    // Atualiza a cada frame e controla a rotação, mira e disparo da torreta
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


    // Instancia uma bala e define seu alvo
    private void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetTarget(target);
        
    }

    // Metodo que é sobrescrito para personalizar a lógica de busca de alvos
    public virtual void FindTarget()
    {

    }


    // Verifica se o alvo atual está dentro do alcance da torreta
    private bool CheckTargetIsInRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }


    // Gira a torreta para apontar na direção do inimigo
    private void RotateTowardsTarget()
    {
        float angle = MathF.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));

        turretRotationPoint.rotation = Quaternion.RotateTowards(turretRotationPoint.rotation, targetRotation,rotationSpeed* Time.deltaTime);
    }





}
