using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private GameObject _player;
    private Rigidbody _rigid;// プレイヤーのリジットボディ
    private BoxCollider _pMaterial;
    int _hp;
    float _jumpPower = 25.0f;// ジャンプ力
    bool _isJumpNow;// ジャンプしているかどうか


    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Fox0726lam");
        _rigid = GetComponent<Rigidbody>();
        _pMaterial = GetComponent<BoxCollider>();
        _hp = 5;
    }
    
    // Update is called once per frame
    void Update()
    {
        float hori = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        float speed = hori * 25.0f;// 速さ
        Vector3 vec = new Vector3(speed, 0, 0);
        // 移動しているかどうかでプレイヤーの摩擦力を変更
        if ((hori != 0))
        {
            _pMaterial.material.dynamicFriction = 0.0f;
        }
        else if(hori == 0)
        {
            _pMaterial.material.dynamicFriction = 1.0f;
        }

        //Debug.Log(_pMaterial.material.dynamicFriction);

        if (hori != 0)
        {
            // 速度が10以下ならば力を加える
            if(_rigid.velocity.x < 10.0f && _rigid.velocity.x > -10.0f)
            {
                _rigid.AddForce(vec);
            }
            
        }

        //Debug.Log(speed);
        
        if (Input.GetKeyDown("joystick button 0"))
        {
            Jump();
        }
            

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

        if(_hp <= 0)
        {
            //_player.active = false;

            this.gameObject.SetActive(false);
        }
        Debug.Log(_hp);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 地面から離れたら
        if (collision.gameObject.tag == "Untagged")
        {
            if (_isJumpNow)
            {
                _isJumpNow = false;
            }
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        // 地面についたら
        if(collision.gameObject.tag == "Untagged")
        {
            if (!_isJumpNow)
            {
                _isJumpNow = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 敵に当たったら
        if(collision.gameObject.name == "Cylinder")
        {
            _hp -= 1;
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
