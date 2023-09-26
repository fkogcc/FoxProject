using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player3DMove : MonoBehaviour
{
    // キャラクターコントローラー.
    private CharacterController _playerController;
    // カメラ.
    private GameObject _camera;
    // アニメーター
    private Animator _animator;

    // float.
    // 移動スピード.
    [SerializeField] public static float _speed = 5.0f;
    // ジャンプ力.
    [SerializeField] private float _jumpPower = 8.0f;
    // 重力.
    [SerializeField] private float _gravity = 10.0f;

    // 地面に当たっているか.
    private bool _isGround = false;

    // 動く方向.
    Vector3 _moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        // マウスカーソルを非表示にし、位置を固定.
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        _playerController = GetComponent<CharacterController>();
        _camera = GameObject.Find("Camera");
        _animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Anim();

        // 接地しているかを代入.
        _isGround = IsGroundedCheck._instance._isGround;

        // 垂直方向.
        float vertical = Input.GetAxis("Vertical");
        // 水平方向.
        float horizontal = Input.GetAxis("Horizontal");

        // カメラの向きを基準にした正面方向のベクトル.
        Vector3 cameraForward = Vector3.Scale(_camera.transform.forward, new Vector3(1.0f, 0.0f, 1.0f)).normalized;

        // カメラ基準.
        Vector3 moveZ = cameraForward * vertical * _speed;// 前後
        Vector3 moveX = _camera.transform.right * horizontal * _speed;// 左右

        _moveDirection = moveZ + moveX + new Vector3(0.0f, _moveDirection.y, 0.0f);
        

        Jump();

        // プレイヤーの進む方向に回転.
        transform.LookAt(transform.position + moveZ + moveX);

        // Moveは指定したベクトルだけ移動させる命令.
        _playerController.Move(_moveDirection * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        FallDebug();
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
        // 着地しているときの処理
        if (_isGround)
        {
            // Aボタン押したらジャンプ.
            if (Input.GetKeyDown("joystick button 0"))
            {
                _moveDirection.y = _jumpPower;
            }
        }

        // プレイヤーにかかる重力処理
        if (!_isGround)
        {
            _moveDirection.y -= _gravity * Time.deltaTime;
        }
        else
        {
            if (!Input.GetKey("joystick button 0"))
            {
                _moveDirection.y = 0.0f;
            }
        }
    }

    // 移動
    private void Move()
    {
        
    }

    // アニメーション
    private void Anim()
    {
        _animator.SetBool("Run", PlayerAnim._instance.Run());
        _animator.SetBool("Jump", PlayerAnim._instance.Jump());
        _animator.SetBool("isDead", PlayerAnim._instance.GameOver());
    }

}
