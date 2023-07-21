using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove1 : MonoBehaviour
{
    bool jumpNow;
    public Rigidbody rigid;
    float jumpPower = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        const float speed = 0.01f;
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(speed, 0.0f, 0.0f);
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(speed, 0.0f, 0.0f);
        }
        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0.0f, 0.0f, speed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= new Vector3(0.0f, 0.0f, speed);
        }
    }

    void Jump()
    {
        if (jumpNow)
        {
            return;
        }

        //rigid.AddForce(transform.up * jumpPower, )

        
    }
}
