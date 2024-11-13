using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFunction : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkBulletLocation();
    }


    void checkBulletLocation()
    {

        GameObject gameObject = GameObject.FindWithTag("Projectile");
        if(gameObject.transform.position.x < -9 || gameObject.transform.position.x > 9 )
        {
            Destroy(gameObject);
        }

        gameObject = GameObject.FindWithTag("EnemyProjectile");
        if(gameObject.transform.position.x < -9 || gameObject.transform.position.x > 9 )
        {
            Destroy(gameObject);
        }
    }
    
}
