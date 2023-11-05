using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MonitorCollider : MonoBehaviour
{
    // プレイヤーが範囲内にいるかどうか.
    private bool _isPlayerCollider;
    // ボタンを押されたかどうか.
    private bool _isPushButton;
    // ボタンの状態を渡すためにオブジェクトを取得.
    private GameObject _gameObject;

    private GameObject _monitorObject;
    // どこのモニターを見ているかを保存する変数.
    private string _name;

    // Start is called before the first frame update
    void Start()
    {
        // 初期化処理.
        _isPlayerCollider = false;
        _isPushButton = false;

        // オブジェクトを取得.
        _gameObject = GameObject.Find("GameManager");
        _monitorObject = GameObject.Find("MonitorCamera");
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
                _name = this.transform.name;
                //_gameObject.GetComponent<MonitorCamera>().SetPushFlag(_isPushButton);

            }
            // Xボタンを押したら
            else if (Input.GetKeyDown("joystick button 3"))
            {
                // ボタンのフラグをオフにする(カメラOFF).
                _isPushButton = false;
                //_gameObject.GetComponent<MonitorCamera>().SetPushFlag(_isPushButton);

            }
            _monitorObject.GetComponent<Test>().SetCameraName(_name);
            _gameObject.GetComponent<MonitorCamera>().SetPushFlag(_isPushButton);
        }
        // ボタンを押したかのフラグを渡す.
        //_gameObject.GetComponent<MonitorCamera>().SetPushFlag(_isPushButton);
        //Debug.Log("いま入っているのは" + _name);
        //_monitorObject.GetComponent<Test>().SetCameraName(_name);
        // 推された場所のモニターがどこかを保存する.
        //_name = null;
    }

    void FixedUpdate()
    {
        
    }

    // 当たり判定の処理
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(this.transform.name);
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
            // 推された場所のモニターがどこかを保存する.
            _name = null;

        }
    }
}
