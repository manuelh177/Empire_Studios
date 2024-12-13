using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemyScript : MonoBehaviour
{
    public GameObject childEnemy;
    public float speed;
    public float distToChase;
    public float turnAroundTime;
    private Transform playerTransform;
    private Rigidbody2D rb;
    private bool facingRight = false;
    private bool flip = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if(speed < 0)
        {
            speed *= -1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(childEnemy == null)
        {
            Destroy(gameObject);
        }
        float distance = transform.position.x - playerTransform.position.x;
        if(distance < distToChase)
        {
            if(distance > 0)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                if (facingRight && !flip)
                {
                    flip = true;
                    StartCoroutine(Flip());
                }
            }
            else
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                if (!facingRight && !flip)
                {
                    flip = true;
                    StartCoroutine(Flip());
                }
            }

        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    private void LateUpdate()
    {
        if(transform.position.x < playerTransform.position.x && !facingRight)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if(transform.position.x > playerTransform.position.x && facingRight)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    

    private IEnumerator Flip()
    {
        yield return new WaitForSeconds(turnAroundTime);
        facingRight = !facingRight;
        Vector3 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;
        flip = false;
    }
}
