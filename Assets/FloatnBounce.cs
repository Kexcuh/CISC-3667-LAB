using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloatAndBounce : MonoBehaviour
{
    public Vector2 speed = new Vector2(2f, 2f);  // Speed in x and y directions
    private Vector2 direction;                   // Direction of movement
    private Camera cam;                          // Reference to the main camera
    public LogicScript logic;

    void Start()
    {
        direction = GetRandomVector2();                      // Initial movement direction
        cam = Camera.main;                      // Reference the main camera
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        // Move the sprite based on speed and direction
        transform.Translate(direction * Time.deltaTime);

        // Get the sprite's position in screen space
        Vector3 spritePos = cam.WorldToViewportPoint(transform.position);

        // Check for collision with screen edges and reverse direction
        if (spritePos.x <= 0 || spritePos.x >= 1)
        {
            direction.x = -direction.x;         // Bounce horizontally
        }
        if (spritePos.y <= 0 || spritePos.y >= 1)
        {
            direction.y = -direction.y;         // Bounce vertically
        }
    }

        // Public method to generate a random Vector2
    public Vector2 GetRandomVector2()
    {
        float x = Random.Range(-9, 9);
        float y = Random.Range(-9, 9);
        return new Vector2(x, y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Projectile"){
            Destroy(gameObject);
            logic.addGoal();
            logic.addScore();
            logic.addScore();
        }

        if (collision.gameObject.tag == "Ground"){
                direction.y *= -1;         // Bounce vertically
        }

        // else
        //   Debug.Log(collision.gameObject.tag);
        //animator.SetInteger("motion", IDLE);
    }
    
}
