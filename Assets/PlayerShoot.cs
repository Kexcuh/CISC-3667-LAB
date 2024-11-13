using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerShoot : MonoBehaviour
{
   
    public GameObject projectilePrefab;  // Assign the projectile prefab in the Inspector
    public float projectileSpeed = 10f;  // Adjust the speed of the projectile
    private bool facingRight;     // Track the player's facing direction
    public float movement;

    void Start()
    {   
        
        facingRight = true;
    }

    void Update()
    {
        

        movement = Input.GetAxis("Horizontal"); //player input a/d

        // Check for shooting input (e.g., pressing the space bar)
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            ShootProjectile();
            UpdateBullet(); 
        }

        // Example for changing facing direction (if your character flips)
        if (movement < 0 && facingRight || movement > 0 && !facingRight)
            Flip(); 

              
    }

    void ShootProjectile()
    {
        Vector3 offset; //bullet offset from player model

        if(facingRight){
            offset = new Vector3(1f,0,0);
        }
        else{
            offset = new Vector3(-1f,0,0);
        }

        // Instantiate the projectile at the player's position
        GameObject projectile = Instantiate(projectilePrefab, transform.position + offset, Quaternion.identity);

        // Get the Rigidbody2D component from the projectile
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // Determine the direction: 1 for right, -1 for left
        float direction = facingRight ? 1f : -1f;

        // Set the projectile's velocity to shoot horizontally in the correct direction
        rb.velocity = new Vector2(direction * projectileSpeed, 0f);
    }


    void UpdateBullet()
    {
        if(projectilePrefab.transform.position.x < -9 || projectilePrefab.transform.position.x > 9 )
        {
            Destroy(projectilePrefab);
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
    }


}

