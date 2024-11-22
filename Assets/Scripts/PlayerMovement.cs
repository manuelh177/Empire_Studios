using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float horizontal;
    private float speed = 1.25f;
    private float jumpingPower = 5f;
    private int jumpCount;
    private bool isFacingRigt = true;

    private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && (IsGrounded() || jumpCount < 2))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            jumpCount++;
        }


        if (Input.GetButtonDown("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }


        Flip();

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        bool grounded = Physics2D.OverlapCircle(groundCheck.position, 0.05f, groundLayer);

        if(grounded)
        {
            jumpCount = 0;
        }

        return grounded;
    }




    private void Flip()
    {
        if (isFacingRigt && horizontal < 0f || !isFacingRigt && horizontal > 0f)
        {
            isFacingRigt = !isFacingRigt;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }


    }
}

