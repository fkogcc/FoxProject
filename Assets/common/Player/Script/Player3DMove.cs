using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player3DMove : MonoBehaviour
{
    // カメラ.
    private GameObject _camera;
    // アニメーター.
    private Animator _animator;
    // リジットボディ
    private Rigidbody _rigidbody;

    private IsGroundedCheck _isGroundedCheck;

    // 移動スピード.
    [SerializeField] private float _speed = 5.0f;
    // ジャンプ力.
    [SerializeField] private float _jumpPower = 8.0f;
    // 重力.
    [SerializeField] private float _gravity = 10.0f;

    // 着地中にかけられ続ける重力/
    private float _groundGravity = -10.0f;

    // 地面に当たっているか.
    private bool _isGround = false;

    // 操作可能かどうか.
    public bool _isController = true;

    // 動く方向.
    Vector3 _moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _camera = GameObject.Find("Camera");
        _animator = GetComponent<Animator>();
        _isGroundedCheck = GetComponent<IsGroundedCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isController) return;
        Anim();
        Move();
        Jump();
    }

    private void FixedUpdate()
    {
        FallDebug();
        //Debug.Log();
    }

    // 地面から落ちたら初期位置のスポーン.
    private void FallDebug()
    {
        if (this.transform.position.y <= -5.0f)
        {
            this.transform.position = new Vector3(0.0f, 1.0f, 0.0f);
        }
    }

    // ジャンプ.
    private void Jump()
    {
        // 着地しているときの処理.
        if (_isGround)
        {
            // Aボタン押したらジャンプ.
            if (Input.GetKeyDown("joystick button 0"))
            {
                _moveDirection.y = _jumpPower;
            }
        }

        // プレイヤーにかかる重力処理.
        if (!_isGround)
        {
            _moveDirection.y -= _gravity * Time.deltaTime;
        }
        else
        {
            if (!Input.GetKey("joystick button 0"))
            {
                _moveDirection.y = _groundGravity;
            }
        }
    }

    // 移動.
    private void Move()
    {
        // 接地しているかを代入.
        _isGround = IsGroundedCheck._instance._isGround;

        // 垂直方向.
        float vertical = Input.GetAxis("Vertical");
        // 水平方向.
        float horizontal = Input.GetAxis("Horizontal");

        // カメラの向きを基準にした正面方向のベクトル.
        Vector3 cameraForward = Vector3.Scale(_camera.transform.forward, new Vector3(1.0f, 0.0f, 1.0f)).normalized;

        // カメラ基準.
        Vector3 moveZ = cameraForward * vertical * _speed;// 前後.
        Vector3 moveX = _camera.transform.right * horizontal * _speed;// 左右.

        _moveDirection = moveZ + moveX + new Vector3(0.0f, _moveDirection.y, 0.0f);

        // プレイヤーの進む方向に回転.
        //transform.LookAt(transform.position + moveZ + moveX);

        transform.forward = Vector3.Slerp(transform.forward, moveZ + moveX, Time.deltaTime * 10.0f);

        const float power = 25;

        _rigidbody.AddForce(_moveDirection * power, ForceMode.Acceleration);

    }

    // 落下ダメージ.
    //private void FallDamage()
    //{

    //}

    // アニメーション.
    private void Anim()
    {
        _animator.SetBool("Run", PlayerAnim3D._instance.Run());
        _animator.SetBool("Jump", PlayerAnim3D._instance.Jump());
        _animator.SetBool("isDead", PlayerAnim3D._instance.GameOver());
    }

}
