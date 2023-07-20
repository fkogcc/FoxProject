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
        float speed = hori / 10.0f;
        Vector3 vec = new Vector3(speed, 0, 0);
        if ((hori != 0) || (vert != 0))
        {
            //Debug.Log("stick:" + hori + "," + vert);
        }

        if (hori != 0)
        {
            //transform.position += new Vector3(hori / 10.0f, 0.0f, 0.0f);
            // スティックの方向け度合いで速度調整
            //rigid.transform.position += new Vector3(speed, 0.0f, 0.0f);
            //rigid.transform.position += new Vector3(0.1f, 0.0f, 0.0f);
            
        }

        rigid.AddForce(vec, ForceMode.Force);

        Debug.Log(speed);

        //Debug.Log(speed);
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.position -= new Vector3(0.01f, 0.0f, 0.0f);
        //}
        if (Input.GetKeyDown("joystick button 0"))
        {
            //transform.position += new Vector3(0.0f, 1.0f, 0.0f);
            Jump();
        }
        //Debug.Log(jumpNow);
            

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
            jumpNow = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!jumpNow)
        {
            jumpNow = true;
        }
    }

    // ジャンプ処理
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
