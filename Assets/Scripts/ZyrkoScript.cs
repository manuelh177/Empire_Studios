using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZyrkoScript : MonoBehaviour
{
    private Health zyrko;
    //public Health player;
    // Start is called before the first frame update
    void Start()
    {
        zyrko = GetComponent<Health>();
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.CompareTag("Projectile"))
        {
            zyrko.TakeDamage(1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            var healthComponent = collision.collider.GetComponent<Health>();
            if(healthComponent != null)
            {
                healthComponent.TakeDamage(1);
            }
            
        }
    }
}
