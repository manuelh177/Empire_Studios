using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    public float duration;
    public GameObject shieldBubble;
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
        if (collision.collider.CompareTag("ShieldPowerUp"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(Invincibility());
        }
    }


    private IEnumerator Invincibility()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        shieldBubble.SetActive(true);
        yield return new WaitForSeconds(duration * 0.7f);
        for(int i = 0; i < 3; i++)
        {
            shieldBubble.SetActive(false);
            yield return new WaitForSeconds(duration * 0.05f);
            shieldBubble.SetActive(true);
            yield return new WaitForSeconds(duration * 0.05f);
        }
        shieldBubble.SetActive(false);
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }
}
