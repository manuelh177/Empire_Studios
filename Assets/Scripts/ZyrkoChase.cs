using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZyrkoChase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float distToChase;


    private float distance;
    private bool facingRight = false;
    private Rigidbody2D rb;
    private Transform playerTransform;


    // Start is called before the first frame update
    void Start()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }



    // Update is called once per frame
    void Update()
    {
        /*distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 180;


        if(distance < distToChase)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }*/

        float distance = transform.position.x - playerTransform.position.x;
        if (Mathf.Abs(distance) < distToChase && Mathf.Abs(distance) > 0.1)
        {
            if (distance > 0)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                if (facingRight)
                {
                    Vector3 temp = transform.localScale;
                    temp.x *= -1;
                    transform.localScale = temp;
                    facingRight = false;
                }
            }
            else
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                if (!facingRight)
                {
                    Vector3 temp = transform.localScale;
                    temp.x *= -1;
                    transform.localScale = temp;
                    facingRight = true;
                }
            }

        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
}
