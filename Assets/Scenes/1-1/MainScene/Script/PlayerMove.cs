using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody _rigid;// プレイヤーのリジットボディ
    private BoxCollider _pMaterial;
    private Animator _animator;// プレイヤーのアニメーション
    int _hp;
    private int _RotateTime;// 回転する時間
    private int _motionNum;// モーション番号
    float _jumpPower = 25.0f;// ジャンプ力
    private bool _isJumpNow;// ジャンプしているかどうか
    private bool _isDirection;// どの向きを向いているか

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
        _pMaterial = GetComponent<BoxCollider>();
        _animator = GetComponent<Animator>();
        _hp = 5;
        _RotateTime = 120;
        _motionNum = 0;

        _isDirection = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        float hori = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        float speed = hori * 25.0f;// 速さ
        Vector3 vec = new Vector3(speed, 0, 0);

        _animator.SetInteger("MotionNum", _motionNum);

        //Debug.Log(_isJumpNow);

        //Debug.Log(_motionNum);
        if (Input.GetKey("joystick button 0"))
        {
            _motionNum = 2;
            Jump();

        }

        // 移動しているかどうかでプレイヤーの摩擦力を変更
        if (hori != 0)
        {
            _pMaterial.material.dynamicFriction = 0.0f;

            if(!_isJumpNow)
            {
                _motionNum = 1;
            }
            
            // 速度が10以下ならば力を加える
            if (_rigid.velocity.x < 10.0f && _rigid.velocity.x > -10.0f)
            {
                _rigid.AddForce(vec);
            }
        }
        else if(hori == 0&& !_isJumpNow)
        {
            _pMaterial.material.dynamicFriction = 1.0f;
            _motionNum = 0;
        }

        if(hori < 0)
        {
            if (hori == 0) return;
            if (_isJumpNow) return;
            _isDirection = true;
            _RotateTime = 0;
        }
        else
        {
            if (hori == 0) return;
            if (_isJumpNow) return;
            _isDirection = false;
            _RotateTime = 0;
        }

        //Debug.Log(speed);

        
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
            this.gameObject.SetActive(false);
        }
        //Debug.Log(_hp);

        // 右を向く
        if(!_isDirection)
        {
            if(transform.localEulerAngles.y > 120.0f)
            {
                transform.Rotate(0f, -10f, 0f);
            }
        }
        // 左を向く
        if(_isDirection)
        {
            if (transform.localEulerAngles.y < 240.0f)
            {
                transform.Rotate(0f, 10f, 0f);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 地面から離れたら
        if (collision.gameObject.tag == "Stage")
        {
            if (_isJumpNow)
            {
                _isJumpNow = false;
            }
        }
        // 敵に当たったら体力を1減らす
        if (collision.gameObject.name == "Enemy")
        {
            _hp -= 1;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // 地面についたら
        if(collision.gameObject.tag == "Stage")
        {
            if (!_isJumpNow)
            {
                _isJumpNow = true;
            }
        }
    }

    // ジャンプ処理
    void Jump()
    {
        if(_isJumpNow) return;

        _rigid.AddForce(transform.up* _jumpPower, ForceMode.Impulse);
        _isJumpNow = true;
    }

}
