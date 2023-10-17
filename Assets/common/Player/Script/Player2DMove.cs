﻿// 2Dプレイヤーの処理.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DMove : MonoBehaviour
{
    public static Player2DMove _instance;

    // プレイヤーのリジットボディ.
    private Rigidbody _rigid;
    // マテリアル.
    private BoxCollider _pMaterial;
    // プレイヤーのアニメーション.
    private Animator _animator;
    // プレイヤーの体力.
    public int _hp;
    // モーション番号.
    private int _motionNum;
    // ジャンプ力.
    private float _jumpPower = 15.0f;
    // ジャンプしているかどうか.
    // true :している
    // false:していない
    private bool _isJumpNow;
    // どの向きを向いているか.
    // true :右
    // false:左
    private bool _isDirection;
    // 動けるように処理を通すかどうか.
    // true :動ける
    // false;動けない
    private bool _isMoveActive = true;

    private void Awake()
    {
        if( _instance == null )
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // 初期化処理.
        _rigid = GetComponent<Rigidbody>();
        _pMaterial = GetComponent<BoxCollider>();
        _animator = GetComponent<Animator>();
        _hp = 5;
        _motionNum = 0;
        _isDirection = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        // ボタン押したら(ボタン配置は仮).
        if (Input.GetKeyDown("joystick button 3"))
        {
            // ゲートの前にいないときはスキップ.
            if (!SetGateFlag()) return;

            Debug.Log("通った");
            _isMoveActive = false;
        }

        if (_hp > 0 || !_isMoveActive)
        {
            // プレイヤーの移動処理.
            Move();
        }
    }

    private void FixedUpdate()
    {
        FallDebug();
        Anim();

        // HPが0になったら止める.
        if (_hp <= 0)
        {
            _motionNum = 3;
        }

        // 右を向く.
        if (!_isDirection)
        {
            if(transform.localEulerAngles.y > 120.0f)
            {
                transform.Rotate(0f, -10f, 0f);
            }
        }
        // 左を向く.
        if (_isDirection)
        {
            if (transform.localEulerAngles.y < 240.0f)
            {
                transform.Rotate(0f, 10f, 0f);
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        // 地面から離れたら.
        if (collision.gameObject.tag == "Stage")
        {
            if (_isJumpNow)
            {
                _isJumpNow = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 敵に当たったら体力を1減らす.
        if (collision.gameObject.tag == "Enemy")
        {
            _hp -= 1;
            if( _hp <= 0)
            {
                _hp = 0;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // 地面についたら.
        if (collision.gameObject.tag == "Stage")
        {
            if (!_isJumpNow)
            {
                _isJumpNow = true;
            }
        }
    }

    // アニメーション制御.
    private void Anim()
    {
        _animator.SetBool("Idle", PlayerAnim2D._instance.Idle());
        _animator.SetBool("Run", PlayerAnim2D._instance.Run());
        _animator.SetBool("Jump", PlayerAnim2D._instance.Jump());
        _animator.SetBool("GameOver", PlayerAnim2D._instance.GameOver());
    }

    // ジャンプ処理.
    void Jump()
    {
        if(_isJumpNow) return;

        _rigid.AddForce(transform.up* _jumpPower, ForceMode.Impulse);
        _isJumpNow = true;
    }
    // 移動処理.
    void Move()
    {
        float hori = Input.GetAxis("Horizontal");
        float speed = hori * 25.0f;// 速さ.
        Vector3 vec = new (speed, 0, 0);

        if (Input.GetKey("joystick button 0"))
        {
            _motionNum = 2;
            Jump();

        }

        // 移動しているかどうかでプレイヤーの摩擦力を変更.
        if (hori != 0)
        {
            _pMaterial.material.dynamicFriction = 0.0f;

            if (!_isJumpNow)
            {
                _motionNum = 1;
            }

            // 速度が10以下ならば力を加える.
            if (_rigid.velocity.x < 10.0f && _rigid.velocity.x > -10.0f)
            {
                _rigid.AddForce(vec);
            }
        }
        else if (hori == 0 && !_isJumpNow)
        {
            _pMaterial.material.dynamicFriction = 1.0f;
            _motionNum = 0;
        }

        if (hori < 0)
        {
            if (hori == 0) return;
            if (_isJumpNow) return;
            _isDirection = true;
        }
        else
        {
            if (hori == 0) return;
            if (_isJumpNow) return;
            _isDirection = false;
        }
    }

    // ゲートの前にいるかの状態.
    private bool SetGateFlag()
    {
        return testCol._instance.GetIsGateGimmick1() || testCol._instance.GetIsGateGimmick2();
    }

    // 落下デバッグ用
    private void FallDebug()
    {
        // 落ちたら初期位置に戻す.
        if (transform.position.y < -10)
        {
            transform.position = new Vector3(-6.0f, 1.0f, 0.0f);
        }
    }

    public int GetHp()              { return _hp; }
    public bool GetIsJumpNow()      { return _isJumpNow; }
    public bool GetIsDirection()    { return _isDirection; }
    public bool GetIsMoveActive()      { return _isMoveActive; }
}
