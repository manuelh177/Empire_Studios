using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 10;
    public bool isPlayer;
    [SerializeField] private bool isSpawner;

    [Header("UI")]
    [SerializeField] private HealthBar healthBar;

    [Header("iFrames")]
    public float iFramesDuration;
    public int numberOfFlashes;
    private SpriteRenderer sprite;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        sprite = GetComponent<SpriteRenderer>();

        if(healthBar != null)
        {
            healthBar.setMaxHealth(maxHealth);
        }
        
    }

    public void TakeDamage(int amt)
    {
        currentHealth -= amt;
        if(currentHealth <= 0)
        {
            if (isPlayer)
            {
                PlayerDeath();
                healthBar.setHealth(currentHealth);
            }
            else
            {
                EnemyDeath();
            }

        }
        else if (isPlayer)
        {
            StartCoroutine(Invulnerability());
        }
        if(healthBar != null)
        {
            healthBar.setHealth(currentHealth);
        }
            
    }

    public void PlayerDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void EnemyDeath()
    {
        if(isSpawner){
            GetComponent<SpawnOnDeath>().Die();
        }
        Destroy(gameObject);

    }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            sprite.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            sprite.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(6, 7, false);
        if (isPlayer)
        {
            var playerMove = GetComponent<PlayerMovement>();
            playerMove.enabled = true;
        }
    }
}
