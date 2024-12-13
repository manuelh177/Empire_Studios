using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float horizontal;
    public float speed;
    public float speedUp;
    public float duration;
    public GameObject speedBubble;
    float speedMultiplier = 1f;
    public float jumpingPower;
    private int jumpCount;
    private bool isFacingRigt = true;
    private Transform gun;

    private Rigidbody2D rb;
    private float runSpeed;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gun = GameObject.FindGameObjectWithTag("Gun").transform;
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
            Vector3 gunScale = gun.localScale;
            gunScale *= -1f;
            gun.localScale = gunScale;
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("SpeedPowerUp"))
        {
            Destroy(collision.gameObject);
            speed = 20000f;
            StartCoroutine(speedBoost());
            speed = 3f;
        }
    }

    private IEnumerator speedBoost()
    {

        speedBubble.SetActive(true);
        yield return new WaitForSeconds(duration * 0.7f);
        for(int i = 0; i < 3; i++)
        {
            speedBubble.SetActive(false);
            yield return new WaitForSeconds(duration * 0.05f);
            speedBubble.SetActive(true);
            yield return new WaitForSeconds(duration * 0.05f);
        }
        speedBubble.SetActive(false);
        speed = 3f;
    }

}

