using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Gerencia o comportamento das balas no jogo, incluindo movimentação e dano ao atingir um alvo.
public class Bullet : MonoBehaviour
{

    // Referência ao componente Rigidbody2D da bala, utilizado para movimentação física
    [SerializeField] private Rigidbody2D rb;

    // Velocidade da bala ao se mover
    [SerializeField] private float bulletSpeed = 5;

    // Dano causado pela bala ao colidir com um inimigo ou objeto
    [SerializeField] private int bulletDamage = 1;


    // Referência ao alvo que a bala deve atingir
    private Transform target;


    //Define qual objeto a bala deve perseguir.
    public void SetTarget(Transform _target)
    {
        target = _target;
    }


    //Move a bala em direção ao alvo a cada atualização fixa, utilizando a física do Rigidbody2D.
    private void FixedUpdate()
    {
        if (!target) return;
        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * bulletSpeed;
    }


    //Gerencia o que acontece quando a bala colide com outro objeto, aplicando dano e destruindo a bala.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Health>().TakeDamage(bulletDamage);
        Destroy(gameObject);
    }
}
