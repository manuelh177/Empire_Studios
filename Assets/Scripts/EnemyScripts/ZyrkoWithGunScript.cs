using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZyrkoWithGunScript : MonoBehaviour
{
    private Camera mainCam;
    private Transform transf;
    public GameObject bullet;
    private GameObject player;
    private Transform playerPos;
    public Transform gun;
    private float timer;
    public float timeBetweenShots;
    private bool isFacingLeft;
    private bool playerIsToTheLeft;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = player.GetComponent<Transform>();
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        transf = GetComponent<Transform>();
        timer = timeBetweenShots * 0.85f;
        isFacingLeft = true;
    }

    // Update is called once per frame
    void Update()
    {
        playerIsToTheLeft = playerPos.position.x < transf.position.x;
        if(isFacingLeft != playerIsToTheLeft)
        {
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            isFacingLeft = !isFacingLeft;
        }
        float enemyInCam = mainCam.WorldToViewportPoint(transf.position).x;
        if (0 <= enemyInCam && enemyInCam <= 1)
        {
            if(timer > timeBetweenShots)
            {
                Shoot();
                timer = 0;
            }
            timer += Time.deltaTime;
        }
    }

    private void Shoot()
    {
        Instantiate(bullet, gun.position, Quaternion.identity);
    }
}
