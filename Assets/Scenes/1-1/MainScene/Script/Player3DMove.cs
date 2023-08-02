using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player3DMove : MonoBehaviour
{
    CharacterController _playerController;
    GameObject _camera;

    private Rigidbody _Rigid;// プレイヤーのリジットボディ
    float _speed = 1.0f;// 移動スピード
    float _jumpPower = 8.0f;// ジャンプ力
    float gravity = 10.0f;// 重力

    Vector3 _moveDirection = Vector3.zero;
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {

        // マウスカーソルを非表示にし、位置を固定
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        _playerController = GetComponent<CharacterController>();
        _camera = GameObject.Find("Camera");
        //_camera = GameObject.Find("testCamera");
        _Rigid = GetComponent<Rigidbody>();

        startPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        // カメラの向きを基準にした正面方向のベクトル
        Vector3 cameraForward = Vector3.Scale(_camera.transform.forward, new Vector3(1.0f, 0.0f, 1.0f)).normalized;

        // (カメラ基準)
        Vector3 moveZ = cameraForward * Input.GetAxis("Vertical") * _speed;// 前後
        Vector3 moveX = _camera.transform.right * Input.GetAxis("Horizontal") * _speed;// 左右

        Debug.Log(_playerController.isGrounded);
        if (_playerController.isGrounded)
        {
            // Aボタン押したらジャンプ
            //if (Input.GetKeyDown("joystick button 0"))
            //{
            //    Jump();
            //}
            _moveDirection = moveZ + moveX;
            if (Input.GetKeyDown("joystick button 0"))
            {
                _moveDirection.y = _jumpPower;
            }
            
        }
        else
        {
            _moveDirection = moveZ + moveX + new Vector3(0.0f, _moveDirection.y, 0.0f);
            _moveDirection.y -= gravity * Time.deltaTime;
        }

        // プレイヤーの向きを入力の向きに変更
        transform.LookAt(transform.position + moveZ + moveX);

        // Moveは指定したベクトルだけ移動させる命令
        _playerController.Move(_moveDirection * Time.deltaTime);
    }

    // ジャンプ処理
    void Jump()
    {
        _Rigid.AddForce(transform.up * _jumpPower, ForceMode.Impulse);
    }
}
