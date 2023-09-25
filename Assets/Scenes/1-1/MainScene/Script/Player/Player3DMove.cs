using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player3DMove : MonoBehaviour
{
    // Component.
    // キャラクターコントローラー.
    private CharacterController _playerController;
    // カメラ.
    private GameObject _camera;
    // アニメーター.
    private Animator _animator;

    // int.
    // モーション番号.
    // 0.Idle.
    // 1.Run.
    // 2.Jump.
    // 3.GameOver.
    private int _motionNum;

    // float.
    // 移動スピード.
    [SerializeField] public static float _speed = 5.0f;
    // ジャンプ力.
    [SerializeField] private float _jumpPower = 8.0f;
    // 重力.
    [SerializeField] private float _gravity = 10.0f;

    // bool
    // 地面に当たっているか.
    private bool _isGround;

    // Vector3
    // 動く方向.
    Vector3 _moveDirection = Vector3.zero;

    enum MotionNum
    {
        Idle,
        Run,
        Jump,
        GameOver
    }


    // Start is called before the first frame update
    void Start()
    {
        // マウスカーソルを非表示にし、位置を固定.
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        //---------------------------------------
        // 以下オブジェクト取得.
        //---------------------------------------
        // キャラクターコントローラー.
        _playerController = GetComponent<CharacterController>();
        // Cameraオブジェクト.
        _camera = GameObject.Find("Camera");
        // アニメーター.
        _animator = GetComponent<Animator>();
        // モーション番号初期化.
        _motionNum = (int)MotionNum.Idle;
        _isGround = false;
    }

    // Update is called once per frame
    void Update()
    {
        // 接地しているかを代入.
        _isGround = IsGroundedCheck._instance._isGround;

        // アニメーション番号.
        _animator.SetInteger("MotionNum", _motionNum);

        // 垂直方向.
        float vertical = Input.GetAxis("Vertical");
        // 水平方向.
        float horizontal = Input.GetAxis("Horizontal");

        // カメラの向きを基準にした正面方向のベクトル.
        Vector3 cameraForward = Vector3.Scale(_camera.transform.forward, new Vector3(1.0f, 0.0f, 1.0f)).normalized;

        // カメラ基準.
        Vector3 moveZ = cameraForward * vertical * _speed;// 前後
        Vector3 moveX = _camera.transform.right * horizontal * _speed;// 左右

        // 着地判定.
        if (_isGround)
        {
            // Aボタン押したらジャンプ.
            _moveDirection = moveZ + moveX;
            if (Input.GetKeyDown("joystick button 0"))
            {
                _moveDirection.y = _jumpPower;
            }

            // 移動状態.
            if (vertical != 0 || horizontal != 0)
            {
                _motionNum = (int)MotionNum.Run;
            }
            else
            {
                _motionNum = (int)MotionNum.Idle;
            }
        }
        else
        {
            _motionNum = (int)MotionNum.Jump;
        }
        _moveDirection = moveZ + moveX + new Vector3(0.0f, _moveDirection.y, 0.0f);
        _moveDirection.y -= _gravity * Time.deltaTime;

        // プレイヤーの向きを入力の向きに変更.
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
}
