using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player3DMove : MonoBehaviour
{
    private CharacterController _playerController;
    private GameObject _camera;
    private Animator _animator;

    private int _motionNum;

    public static float _speed = 5.0f;// 移動スピード
    float _jumpPower = 8.0f;// ジャンプ力
    float _gravity = 10.0f;// 重力

    // 動く方向
    Vector3 _moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        // マウスカーソルを非表示にし、位置を固定
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        _playerController = GetComponent<CharacterController>();
        _camera = GameObject.Find("Camera");
        _animator = GetComponent<Animator>();

        _motionNum = 0;

    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetInteger("MotionNum", _motionNum);

        // 垂直方向.
        float vertical = Input.GetAxis("Vertical");
        // 水平方向
        float horizontal = Input.GetAxis("Horizontal");

        // カメラの向きを基準にした正面方向のベクトル
        Vector3 cameraForward = Vector3.Scale(_camera.transform.forward, new Vector3(1.0f, 0.0f, 1.0f)).normalized;

        // (カメラ基準)
        Vector3 moveZ = cameraForward * vertical * _speed;// 前後
        Vector3 moveX = _camera.transform.right * horizontal * _speed;// 左右

        if(vertical != 0 || horizontal != 0)
        {
            _motionNum = 1;
        }
        else
        {
            _motionNum = 0;
        }

        // 着地判定
        if (_playerController.isGrounded)
        {
            // Aボタン押したらジャンプ.
            _moveDirection = moveZ + moveX;
            if (Input.GetKeyDown("joystick button 0"))
            {
                _moveDirection.y = _jumpPower;
            }
            
        }
        else
        {
            _moveDirection = moveZ + moveX + new Vector3(0.0f, _moveDirection.y, 0.0f);
            _moveDirection.y -= _gravity * Time.deltaTime;
        }

        // プレイヤーの向きを入力の向きに変更
        transform.LookAt(transform.position + moveZ + moveX);

        // Moveは指定したベクトルだけ移動させる命令
        _playerController.Move(_moveDirection * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        FallDebug();
    }


    private void FallDebug()
    {
        if (this.transform.position.y <= -5.0f)
        {
            this.transform.position = new Vector3(0.0f, 1.0f, 0.0f);
        }
    }
}
