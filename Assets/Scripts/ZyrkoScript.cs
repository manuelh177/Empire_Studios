using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZyrkoScript : MonoBehaviour
{
    private Health zyrko;
    private SpriteRenderer sp;
    public float flashDuration;
    //public Health player;
    // Start is called before the first frame update
    void Start()
    {
        zyrko = GetComponent<Health>();
        sp = GetComponent<SpriteRenderer>();
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
            StartCoroutine(DamageFlash());
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

    private IEnumerator DamageFlash()
    {
            sp.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(flashDuration);
            sp.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(flashDuration);
    }
}
