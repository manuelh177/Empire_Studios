using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Health zyrko;
    private SpriteRenderer sp;
    public float flashDuration;
    private Transform transf;
    //public Health player;
    // Start is called before the first frame update
    void Start()
    {
        zyrko = GetComponent<Health>();
        sp = GetComponent<SpriteRenderer>();
        transf = GetComponent<Transform>();
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.CompareTag("Projectile"))
        {
            zyrko.TakeDamage(collision.GetComponent<bulletScript>().damage);
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
            StartCoroutine(PlayerKnockback(collision));
        }
    }

    private IEnumerator DamageFlash()
    {
            sp.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(flashDuration);
            sp.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(flashDuration);
    }

    private IEnumerator PlayerKnockback(Collision2D collision)
    {
        PlayerMovement playerMove = collision.collider.GetComponent<PlayerMovement>();
        if(playerMove != null && playerMove.enabled == true)
        {
        playerMove.enabled = false;
        if (transf.position.x > collision.collider.transform.position.x)
        {
            collision.collider.attachedRigidbody.velocity = new Vector2(-1f, 1f);
        }
        else
        {
            collision.collider.attachedRigidbody.velocity = new Vector2(1f, 1f);
        }
        yield return new WaitForSeconds(0.2f);
        playerMove.enabled = true;
        }

    }
}
