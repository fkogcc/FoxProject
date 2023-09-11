using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            transform.position -= transform.up * speed * Time.deltaTime;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }


    }
}
