using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
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
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(0.01f, 0.0f, 0.0f);
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(0.01f, 0.0f, 0.0f);
        }
        if(Input.GetKey(KeyCode.UpArrow))
        {
            //transform.position += new Vector3(0.0f, 0.01f, 0.0f);
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
