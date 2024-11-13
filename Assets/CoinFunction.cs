using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFunction : MonoBehaviour
{

    public LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        logic.addScore();
        if (collision.gameObject.tag == "Player")
            Destroy(gameObject);
        // else
        //   Debug.Log(collision.gameObject.tag);
        //animator.SetInteger("motion", IDLE);
    }
}
