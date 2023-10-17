using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorCollider : MonoBehaviour
{
    // プレイヤーが範囲内にいるかどうか.
    private bool _isPlayerCollider;
    // ボタンを押されたかどうか.
    private bool _isPushButton;
    // ボタンの状態を渡すためにオブジェクトを取得.
    private GameObject _gameObject;

    // Start is called before the first frame update
    void Start()
    {
        // 初期化処理.
        _isPlayerCollider = false;
        _isPushButton = false;

        // オブジェクトを取得.
        _gameObject = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーが判定内にいるとき.
        if (_isPlayerCollider)
        {
            // Aボタンを押したら
            if (Input.GetKeyDown("joystick button 1"))
            {
                // ボタンのフラグをオンにする(カメラON).
                _isPushButton = true;
            }
            // Xボタンを押したら
            else if (Input.GetKeyDown("joystick button 3"))
            {
                // ボタンのフラグをオフにする(カメラOFF).
                _isPushButton = false;
            }
        }
        // ボタンを押したかのフラグを渡す.
        _gameObject.GetComponent<MonitorCamera>().SetPushFlag(_isPushButton);
    }

    void FixedUpdate()
    {

    }

    // 当たり判定の処理
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // プレイヤーがコライダーに入ったとき.
            _isPlayerCollider = true;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            // プレイヤーがコライダーから出たとき.
            _isPlayerCollider = false;
        }
    }
}
