// 2Dプレイヤーの処理.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DMove : MonoBehaviour
{
    public static Player2DMove _instance;
    private PlayerAnim2D _anim;
    private GateFlag _transitionScene;

    // プレイヤーのリジットボディ.
    private Rigidbody _rigid;
    // マテリアル.
    private BoxCollider _boxCollider;
    // プレイヤーのアニメーション.
    private Animator _animator;
    // プレイヤーの体力.
    private int _hp = 5;
    // ジャンプ力.
    private float _jumpPower = 30.0f;
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
        _anim = GetComponent<PlayerAnim2D>();
        _transitionScene = GameObject.Find("Foxidle").GetComponent<GateFlag>();
        _rigid = GetComponent<Rigidbody>();
        _boxCollider = GetComponent<BoxCollider>();
        _animator = GetComponent<Animator>();
        _hp = 5;
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
        _animator.SetBool("Idle", _anim.Idle());
        _animator.SetBool("Run", _anim.Run());
        _animator.SetBool("Jump", _anim.Jump());
        _animator.SetBool("GameOver", _anim.GameOver());
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

        if (Input.GetKeyDown("joystick button 0"))
        {
            Jump();
        }

        // 移動しているかどうかでプレイヤーの摩擦力を変更.
        if (hori != 0)
        {
            _boxCollider.material.dynamicFriction = 0.0f;

            // 速度が10以下ならば力を加える.
            if (_rigid.velocity.x < 10.0f && _rigid.velocity.x > -10.0f)
            {
                _rigid.AddForce(vec);
            }
        }
        else if (hori == 0 && !_isJumpNow)
        {
            _boxCollider.material.dynamicFriction = 1.0f;
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
        return _transitionScene._isGateGimmick1_1 ||
            _transitionScene._isGateGimmick1_2 ||
            _transitionScene._isGateGimmick2_1 ||
            _transitionScene._isGateGimmick2_2 ||
            _transitionScene._isGateGimmick2_3 ||
            _transitionScene._isGateGimmick2_4 ||
            _transitionScene._isGateGimmick3_1 ||
            _transitionScene._isGateGimmick3_2 ||
            _transitionScene._isGateGimmick3_3 ||
            _transitionScene._isGateGimmick3_4 ||
            _transitionScene._isGoal1_1 ||
            _transitionScene._isGoal1_2 ||
            _transitionScene._isGoal1_3;
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
