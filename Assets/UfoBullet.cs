using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoBullet : MonoBehaviour
{
    //private Vector3 mousePos;
    private Rigidbody2D rb;
    private Transform playerPos;
    public float force;


    // Start is called before the first frame update

    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        //Transform curPos = GetComponent<Transform>();
        Vector2 direction = playerPos.position - transform.position;
        rb.velocity = direction;
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            var health = collision.collider.GetComponent<Health>();
            if(health != null)
            {
                health.TakeDamage(1);
            }
        }
    }*/


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var health = collision.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(1);
            }
        }
        Destroy(gameObject);
    }
}