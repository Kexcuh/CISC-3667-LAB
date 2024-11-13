using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject projectilePrefab;  // Assign the projectile prefab in the Inspector
    public float projectileSpeed = 10f;  // Adjust the speed of the projectile
    public float movement;
    private float timer;
    public float spawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.01f;
        spawnInterval = 0.4f;
    }

    // Update is called once per frame
    void Update()
    {
        // Increment the timer by the time passed since last frame
        timer += Time.deltaTime;

        // Check if the timer has reached the spawn interval
        if (timer >= spawnInterval)
        {
            // Spawn the object
            ShootProjectile();

            // Reset the timer
            timer = 0.0f;
        }
    }

    void ShootProjectile()
    {
        Vector3 offset = new Vector3(-1f,0,0); //bullet offset from player model

        // Instantiate the projectile at the player's position
        GameObject projectile = Instantiate(projectilePrefab, transform.position + offset, Quaternion.identity);

        // Get the Rigidbody2D component from the projectile
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // Determine the direction: 1 for right, -1 for left
        float direction = -1f;

        // Set the projectile's velocity to shoot horizontally in the correct direction
        rb.velocity = new Vector2(direction * projectileSpeed, 0f);
    }

}
