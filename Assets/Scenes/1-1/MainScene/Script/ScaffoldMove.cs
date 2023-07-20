using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaffoldMove : MonoBehaviour
{
    float top;
    float bottom;
    float speed = 0.05f;
    float exchange = 0.05f;
    

    // Start is called before the first frame update
    void Start()
    {
        top = gameObject.transform.position.y + 3.0f;
        bottom = gameObject.transform.position.y - 3.0f;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(gameObject.transform.position.y > top)
        {
            exchange = -speed;
        }

        if(gameObject.transform.position.y < bottom)
        {
            exchange = speed;
        }

        gameObject.transform.Translate(0, exchange, 0);
    }

    
}
