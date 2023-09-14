using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorCollider : MonoBehaviour
{
    // プレイヤーが範囲内にいるかどうか.
    private bool _isPlayerCollider;
    // ボタンを押されたかどうか.
    public bool _isPushButton;

    // ボタンの状態を渡すためにオブジェクトを取得.
    private GameObject _gameObject;
    // scriptを取得.
    MonitorCamera _monitor;

    // Start is called before the first frame update
    void Start()
    {
        _isPlayerCollider = false;
        _isPushButton = false;

        // オブジェクトを取得.
        _gameObject = GameObject.Find("GameManager");
        // オブジェクトの中にあるscriptを取得.
        _monitor = _gameObject.GetComponent<MonitorCamera>();

    }

    // Update is called once per frame
    void Update()
    {
        if (_isPlayerCollider)
        {
            if (Input.GetKeyDown("joystick button 1"))
            {
                Debug.Log("ボタンをおした");
                _isPushButton = true;
            }
            else if (Input.GetKeyDown("joystick button 3"))
            {
                _isPushButton = false;
            }
        }
        else
        {
            _isPushButton = false;

        }

        // ボタンを押したかのフラグを渡す.
        _monitor._isPushFlag = _isPushButton;
    }

    void FixedUpdate()
    {

    }

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
