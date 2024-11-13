using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Vector2 speed = new Vector2(0f, 4f);  // Speed in x and y directions
    private Vector2 direction = new Vector2(0f, 5f); // Direction of movement
    private Camera cam;                          // Reference to the main camera
    public LogicScript logic;
    public int enemyPoints;
    public GameObject gameObject;


    // Start is called before the first frame update
    void Start()
    {
        gameObject = GameObject.FindGameObjectWithTag("Enemy");
        enemyPoints = 0;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // Move the sprite based on speed and direction
        transform.Translate(direction * Time.deltaTime);

        // Get the sprite's position in screen space
        Vector3 spritePos = cam.WorldToViewportPoint(transform.position);

        // Check for collision with screen edges and reverse direction
        if (spritePos.y <= 0 || spritePos.y >= 1)
        {
            direction.y *= -1;         // Bounce vertically
        }

        if (enemyPoints >= 10)
            {
                Destroy(gameObject);
                logic.addGoal();
                logic.addGoal();
                logic.addGoal();
            }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Projectile")
        {
            enemyPoints++;
            gameObject = GameObject.FindGameObjectWithTag("Projectile");
            Destroy(gameObject);

            gameObject = GameObject.FindGameObjectWithTag("Enemy");

            logic.addScore();
            logic.addScore();
            logic.addScore();
            logic.addScore();
            logic.addScore();
        }

        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            gameObject = GameObject.FindGameObjectWithTag("Player");
            Destroy(gameObject);
            logic.restartLevel();
            gameObject = GameObject.FindGameObjectWithTag("Enemy");
        }

        
        // else
        //   Debug.Log(collision.gameObject.tag);
        //animator.SetInteger("motion", IDLE);
    }

}
