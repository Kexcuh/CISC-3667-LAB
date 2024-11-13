using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeFunction : MonoBehaviour
{
    public GameObject gameObject;
    public LogicScript logic;
    public Vector2 speed = new Vector2(2f, 0f);  // Speed in x and y directions
    private Vector2 direction = new Vector2(3f, 0f);                   // Direction of movement
    private Camera cam;                          // Reference to the main camera

    // Start is called before the first frame update
    void Start()
    {
        gameObject = GameObject.FindGameObjectWithTag("Player");
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
        if (spritePos.x <= 0 || spritePos.x >= 1)
        {
            direction.x *= -1;         // Bounce horizontally
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player"){
            Destroy(gameObject);
            logic.restartLevel();
        }

        if(collision.gameObject.tag == "Spike"){
            direction.x *= -1;
        }
        // else
        //   Debug.Log(collision.gameObject.tag);
        //animator.SetInteger("motion", IDLE);
    }
}
