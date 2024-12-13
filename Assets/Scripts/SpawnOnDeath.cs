using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnDeath : MonoBehaviour
{
    // Reference to the prefab of the smaller enemy
    public GameObject smallerEnemyPrefab;

    // Called when the enemy's health reaches 0
    public void Die()
    {
        // Check if the prefab is assigned
        if (smallerEnemyPrefab != null)
        {
            // Spawn two smaller enemies at slightly offset positions
            Instantiate(smallerEnemyPrefab, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
            Instantiate(smallerEnemyPrefab, transform.position + new Vector3(-1, 0, 0), Quaternion.identity);
        }

        // Destroy the current enemy GameObject
        Destroy(gameObject);
    }
}