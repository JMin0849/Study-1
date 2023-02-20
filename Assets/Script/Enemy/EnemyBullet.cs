using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 8f;
    public Vector3 direction;
    
    void Start()
    {
        direction = (PlayerController.instance.transform.position - transform.position).normalized;
    }

    
    void FixedUpdate()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerHealthController.instance.DamagePlayer();
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
