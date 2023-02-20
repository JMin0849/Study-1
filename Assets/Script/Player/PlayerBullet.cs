using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 8f;
    public Rigidbody2D theRB;
    public GameObject impactEffect;

    public int damage = 50;
  
    void Start()
    {
        
    }

    void Update()
    {
        theRB.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        if(other.tag == "Enemy")
        {
            other.GetComponent<EnemyController>().DamageEnemy(damage);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
