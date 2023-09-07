using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPull : MonoBehaviour
{
    // プレイヤーの位置情報
    Transform _player;

    // 引っ張り始めた位置
    Vector3 _startPos;
    // 距離引っ張り始めた位置から現在までの距離
    Vector3 _delPos;

    // 引っ張れる範囲にいるかの判定
    bool _isPullRange;

    // 引っ張っているか
    bool _isPull;

    void Start()
    {
        _player = GameObject.Find("3DPlayer").GetComponent<Transform>();

        _isPullRange = false;
        _isPull = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 1") && _isPullRange)
        {
            Debug.Log("引っ張り始めた");
            // 引っ張り始めた時の位置を保存
            _startPos = this._player.position;

            _isPull = true;
        }

        if (Input.GetKeyUp("joystick button 1"))
        {
            Debug.Log("引っ張り終わり");

            _isPull = false;

            // ここで離した時色が同じならできた処理をする
            // 現在は元の位置に戻るだけとする
            this.transform.position = _startPos;
        }
    }

    void FixedUpdate()
    {
        if (_isPull)
        {
            _delPos = this._player.position;
            _delPos.x -= 10f;

            this.transform.position = _delPos;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // 範囲内に入った場合引っ張れるようにする
        Debug.Log("引っ張れる");
        _isPullRange = true;
    }

    void OnTriggerExit(Collider other)
    {
        // 範囲外に出たら引っ張れないようにする
        Debug.Log("引っ張れない");
        _isPullRange = false;
    }
}
