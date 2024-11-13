using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public LogicScript logic;
    private Camera cam;
    [SerializeField] float movement;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] const int SPEED = 5;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] float jumpForce;
    [SerializeField] bool isGrounded = true;

    //[SerializeField] Animator animator;

    const int IDLE = 0;
    const int RUN = 1;
    const int JUMP = 2;
    // Start is called before the first frame update
    void Start()
    {
        jumpForce =  6.5f;
        cam = Camera.main;
        if (rigid == null){
            rigid = GetComponent<Rigidbody2D>();
        }

        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        /*
        if (animator == null)
            animator = GetComponent<Animator>();
        animator.SetInteger("motion", IDLE);
        */
    }

    // Update is called once per frame --used for user input
    //do NOT use for physics & movement
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            jumpPressed = true;
        }

        Vector3 spritePos = cam.WorldToViewportPoint(transform.position);
        if (spritePos.y <= 0)
        {
            GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
            Destroy(gameObject);         // Bounce vertically
            logic.restartLevel();
        }
    }

    //called potentially many times per frame
    //use for physics & movement
    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(SPEED * movement, rigid.velocity.y);
        if (movement < 0 && isFacingRight || movement > 0 && !isFacingRight)
            Flip();
        if (jumpPressed && isGrounded)
        {
            //rigid.velocity = new Vector2(rigid.velocity.x, jumpForce);
            //isGrounded = false;
            //jumpPressed = false;
            Jump();
        }
        else
        { 
            jumpPressed = false;
            /*
            if (isGrounded)
            {
                if (movement > 0 || movement < 0)
                {
                    animator.SetInteger("motion", RUN);
                }
                else
                {
                    animator.SetInteger("motion", IDLE);
                }
            }
            */
        }

        
    }

    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    private void Jump()
    {
        //animator.SetInteger("motion", JUMP);
        rigid.velocity = new Vector2(rigid.velocity.x, jumpForce);
        rigid.AddForce(new Vector2(0, jumpForce));
        //Debug.Log("jumped");
        jumpPressed = false;
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
        // else
        //   Debug.Log(collision.gameObject.tag);
        //animator.SetInteger("motion", IDLE);

        if (collision.gameObject.tag == "EnemyProjectile")
        {   
            GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
            Destroy(gameObject);
            logic.restartLevel();
        }
    }
}