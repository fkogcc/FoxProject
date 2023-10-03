// 2Dプレイヤーの処理.
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
    private float _jumpPower = 25.0f;
    // ジャンプしているかどうか.
    private bool _isJumpNow;
    // どの向きを向いているか.
    public bool _isDirection;

    private void Awake()
    {
        if( _instance == null )
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
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
        if(_hp > 0)
        {
            // プレイヤーの移動処理.
            Move();
        }

        //TestSceneSwitcher._instance.SwitchToNextScene(3);
    }

    private void FixedUpdate()
    {
        FallDebug();

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

    private void OnCollisionEnter(Collision collision)
    {
        // 地面から離れたら.
        if (collision.gameObject.tag == "Stage")
        {
            if (_isJumpNow)
            {
                _isJumpNow = false;
            }
        }
        // 敵に当たったら体力を1減らす.
        if (collision.gameObject.name == "Enemy")
        {
            _hp -= 1;
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
        float speed = hori * 25.0f;// 速さ
        Vector3 vec = new Vector3(speed, 0, 0);

        _animator.SetInteger("MotionNum", _motionNum);

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

    /// <summary>
    /// シーンを
    /// </summary>
    /// <param name="hp"></param>
    private void SetHp(int hp)
    {
        hp = _hp;
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
}
