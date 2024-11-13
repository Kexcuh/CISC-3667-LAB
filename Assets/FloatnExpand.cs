using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloatAndExpand : MonoBehaviour
{
    public Vector2 speed = new Vector2(0f, 4f);  // Speed in x and y directions
    private Vector2 direction = new Vector2(0f, 7f);                   // Direction of movement
    private Camera cam;                          // Reference to the main camera
    public LogicScript logic;
    public float scaleSpeed = 1.0f;
    public float scaleAmount;
    private Vector3 originalScale;
    public float maxScale = 1.5f;  // Maximum scale factor
    public float minScale = 0.1f;  // Minimum scale factor

    void Start()
    {
        originalScale = transform.localScale;
        cam = Camera.main;                      // Reference the main camera
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        scaleAmount = 0.75f;
    }

    void Update()
    {
      // Move the sprite based on speed and direction
      transform.Translate(direction * Time.deltaTime);

      // Get the sprite's position in screen space
      Vector3 spritePos = cam.WorldToViewportPoint(transform.position);

      if (spritePos.y <= 0 || spritePos.y >= 1)
      {
          direction.y = -direction.y;         // Bounce vertically
      }

      // Calculate the scaling factor using a sine wave
      float scale = 1 + Mathf.Sin(Time.time * scaleSpeed) * scaleAmount;
      // Apply the scaling to the object's original scale
      transform.localScale = originalScale * scale;

      //Vector3 currentScale = transform.localScale;

/*
      if(currentScale.x > 50.0f && currentScale.y > 50.0)
      {
        scaleAmount *= -1;
      }
      if(currentScale.x < -50.0f && currentScale.y < -50.0)
      {
        scaleAmount *= -1;
      }
      */
    }

        // Public method to generate a random Vector2

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Projectile"){
            Destroy(gameObject);
            logic.addGoal();
            logic.addGoal();
            logic.addScore();
            logic.addScore();
        }
        // else
        //   Debug.Log(collision.gameObject.tag);
        //animator.SetInteger("motion", IDLE);
    }
    
}
