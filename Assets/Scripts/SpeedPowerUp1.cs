using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public float duration;
    public GameObject speedBubble;
    public float newSpeed;
    public PlayerMovement pm;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("SpeedPowerUp"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(speedBoost());
        }
    }


    private IEnumerator speedBoost()
    {

        float ogSpeed = pm.speed;
        pm.speed = newSpeed;
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
        pm.speed = ogSpeed;
    }
}
