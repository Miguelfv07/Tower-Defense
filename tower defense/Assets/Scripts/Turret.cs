using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


// Controla o comportamento de uma torreta no jogo, incluindo mira, disparo e rota��o em dire��o aos inimigos.Serve como Classe Base das torretas.
public class Turret : MonoBehaviour, ITorre
{
    // Ponto de rota��o da torreta (para girar em dire��o ao inimigo)
    [SerializeField] protected Transform turretRotationPoint;
    // M�scara de detec��o de inimigos (define quais objetos s�o reconhecidos como inimigos)
    [SerializeField] public LayerMask enemyMask;
    // Prefab do proj�til que a torreta dispara
    [SerializeField] private GameObject bulletPrefab;
    // Ponto de disparo de onde os proj�teis s�o criados
    [SerializeField] private Transform firingPoint;

    [SerializeField] public float targetingRange = 5f; //Alcance da torreta para detectar alvos
    [SerializeField] private float rotationSpeed = 5;  // Velocidade de rota��o da torreta ao seguir um alvo
    [SerializeField] public float bps; // Taxa de disparo (balas por segundo)

    // Refer�ncia ao inimigo que est� sendo mirado
    protected Transform target;
    // Tempo at� a torreta disparar novamente
    private float timeUntilFire;


    // Atualiza a cada frame e controla a rota��o, mira e disparo da torreta
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

    // Metodo que � sobrescrito para personalizar a l�gica de busca de alvos
    public virtual void FindTarget()
    {

    }


    // Verifica se o alvo atual est� dentro do alcance da torreta
    private bool CheckTargetIsInRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }


    // Gira a torreta para apontar na dire��o do inimigo
    private void RotateTowardsTarget()
    {
        float angle = MathF.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));

        turretRotationPoint.rotation = Quaternion.RotateTowards(turretRotationPoint.rotation, targetRotation,rotationSpeed* Time.deltaTime);
    }





}
