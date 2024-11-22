using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 10;
    public bool isPlayer;

    [Header("iFrames")]
    public float iFramesDuration;
    public int numberOfFlashes;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        sprite = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int amt)
    {
        currentHealth -= amt;
        if(currentHealth <= 0)
        {
            if (isPlayer)
            {
                PlayerDeath();
            }
            else
            {
                EnemyDeath();
            }
        }
        else if (isPlayer)
        {
            //StartCoroutine(Invulnerability());
        }
    }

    public void PlayerDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void EnemyDeath()
    {
        Destroy(gameObject);
    }


}