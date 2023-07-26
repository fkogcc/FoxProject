using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    bool _isJumpNow;// ジャンプしているかどうか
    private Rigidbody _rigid;// プレイヤーのリジットボディ
    float _jumpPower = 25.0f;// ジャンプ力

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update()
    {
        float hori = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        float speed = hori * 25.0f;// 速さ
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

            // 速度が10以下ならば力を加える
            if(_rigid.velocity.x < 10.0f && _rigid.velocity.x > -10.0f)
            {
                _rigid.AddForce(vec);

                //rigid.velocity = new Vector3(speed, 0.0f, 0.0f);
            }
            
        }

        //if(rigid.velocity.x >= 10)
        //{
        //    rigid.velocity = new Vector3(10.0f,0.0f,0.0f);
        //}

        //rigid.AddForce(new Vector3(10.0f,0.0f,0.0f));

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

    private void FixedUpdate()
    {
        // 落ちたら初期位置に戻す
        if(transform.position.y < -10)
        {
            transform.position = new Vector3(-6.0f,1.0f,0.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 地面から離れたら
        if (_isJumpNow)
        {
            _isJumpNow = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // 地面についたら
        if (!_isJumpNow)
        {
            _isJumpNow = true;
        }
    }

    // ジャンプ処理
    void Jump()
    {
        if(_isJumpNow)
        {
            return;
        }
        _rigid.AddForce(transform.up* _jumpPower, ForceMode.Impulse);
        _isJumpNow = true;
    }

}
