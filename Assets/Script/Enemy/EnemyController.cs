using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 3f;
    private Vector3 moveDirection;
    public float rangeToChasePlayer;
    
    [Header("Health")]
    public int health = 150;

    [Header("shooting")]
    public bool shouldShoot;
    public float fireRate = 1f;
    private float fireCounter = 1f;
    public float rangeToShootPlayer = 5f;
    public GameObject bullet;
    public Transform firePoint;

    [Header("References")]
    public Rigidbody2D theRB;
    public Animator anim;
    public GameObject hitEffect;
    public GameObject[] deathEffect;
    void Start()
    {
        
    }

    void Update()
    {
        if (Vector3.Distance(PlayerController.instance.transform.position, transform.position) < rangeToChasePlayer)
        {
            moveDirection = PlayerController.instance.transform.position - transform.position;
            moveDirection.Normalize();
            theRB.velocity = moveDirection * moveSpeed;
            anim.SetBool("isMoving", true);
        }
        else
        {
            theRB.velocity = Vector2.zero;
            anim.SetBool("isMoving", false);
        }

        if (shouldShoot && Vector3.Distance(PlayerController.instance.transform.position, transform.position) < rangeToShootPlayer)
        {
            fireCounter -= Time.deltaTime;
            if(fireCounter <= 0)
            {
                fireCounter = fireRate;
                Instantiate(bullet, firePoint.position, firePoint.rotation);
            }
        }
    }

    public void DamageEnemy(int damage)
    {
        health -= damage;
        Instantiate(hitEffect, transform.position, transform.rotation);
        if(health <= 0)
        {
            int selectionEffect = Random.Range(0, deathEffect.Length);
            int _rotation = Random.Range(0, 4);
            Instantiate(deathEffect[selectionEffect], transform.position,Quaternion.Euler(0f, 0f, _rotation * 90f));
            Destroy(gameObject);
        }
    }
}
