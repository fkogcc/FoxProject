using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    bool jumpNow;
    public Rigidbody rigid;
    float jumpPower = 25.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float hori = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        if ((hori != 0) || (vert != 0))
        {
            //Debug.Log("stick:" + hori + "," + vert);
        }

        if (hori != 0)
        {
            //transform.position += new Vector3(hori / 10.0f, 0.0f, 0.0f);
            rigid.transform.position += new Vector3(hori / 10.0f, 0.0f, 0.0f);
        }
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.position -= new Vector3(0.01f, 0.0f, 0.0f);
        //}
        if (Input.GetKeyDown("joystick button 0"))
        {
            //transform.position += new Vector3(0.0f, 1.0f, 0.0f);
            Jump();
        }
        Debug.Log(jumpNow);
            

        //if (Input.GetKeyDown("joystick button 0"))
        //{
        //    Debug.Log("A");
        //}
        //if (Input.GetKeyDown("joystick button 1"))
        //{
        //    Debug.Log("B");
        //}
        //if (Input.GetKeyDown("joystick button 2"))
        //{
        //    Debug.Log("X");
        //}
        //if (Input.GetKeyDown("joystick button 3"))
        //{
        //    Debug.Log("Y");
        //}
        //if (Input.GetKeyDown("joystick button 4"))
        //{
        //    Debug.Log("LB");
        //}
        //if (Input.GetKeyDown("joystick button 5"))
        //{
        //    Debug.Log("RB");
        //}
        //if (Input.GetKeyDown("joystick button 6"))
        //{
        //    Debug.Log("View");
        //}
        //if (Input.GetKeyDown("joystick button 7"))
        //{
        //    Debug.Log("Menu");
        //}
        //if (Input.GetKeyDown("joystick button 8"))
        //{
        //    Debug.Log("LS");
        //}
        //if (Input.GetKeyDown("joystick button 9"))
        //{
        //    Debug.Log("RS");
        //}

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (jumpNow)
        {
            //if (collision.gameObject.CompareTag("field"))
            //{
            //    jumpNow = false;
            //}
            jumpNow = false;
        }
    }

    // ÉWÉÉÉìÉvèàóù
    void Jump()
    {
        if(jumpNow)
        {
            return;
        }
        rigid.AddForce(transform.up* jumpPower, ForceMode.Impulse);
        jumpNow = true;
    }

}
