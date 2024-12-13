using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_2_Movement : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public float speed;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;

    public GameObject bulletPrefab; // Reference to the bullet prefab
    public GameObject enemyPrefab; // Reference to enemy that drops
    public Transform firePoint; // Point from where the bullet will be fired
    public float minShootInterval = 2f; // Minimum time between shots
    public float maxShootInterval = 5f; // Maximum time between shots
    public float timeBetweenShots;

    private Transform player; // Player's transform
    private bool canShoot = true; // To control shooting

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = pointA.transform;
        anim.SetBool("isFlying", true);

        player = GameObject.FindGameObjectWithTag("Player").transform; // Assuming player has "Player" tag
        StartCoroutine(ShootAtRandomIntervals());
    }

    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            
            currentPoint = pointA.transform;
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            
            currentPoint = pointB.transform;
        }
    }



    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
    }

    private IEnumerator ShootAtRandomIntervals()
    {
        while (true)
        {
            float rng = Random.Range(0, 100);
            if(rng < 70)
            {
                if (canShoot && player != null)
                {
                    StartCoroutine(ShootAtPlayer());
                }
            }
            else
            {
                SpawnEnemy();
            }
            
            float waitTime = Random.Range(minShootInterval, maxShootInterval);
            yield return new WaitForSeconds(waitTime);
        }
    }

    private IEnumerator ShootAtPlayer()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            // Create the bullet
            //GameObject bullet =
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenShots);
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenShots);
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);


            /*// Set its direction toward the player
            Vector2 direction = (player.position - firePoint.position).normalized;
            bullet.GetComponent<Rigidbody2D>().velocity = direction * 5f; // Set bullet speed*/
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}