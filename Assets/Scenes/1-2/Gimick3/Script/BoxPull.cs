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
        if ((Input.GetKeyDown("joystick button 1") || Input.GetKeyDown(KeyCode.F)) && _isPullRange)
        {
            Debug.Log("引っ張り始めた");

            // 引っ張り始めたの位置を保存
            _startPos = this._player.position;

            _isPull = true;
        }

        if ((Input.GetKeyDown("joystick button 1") || Input.GetKeyUp(KeyCode.F)))
        {
            Debug.Log("引っ張り終わり");

            _isPull = false;

            // ここで離した時色が同じならできた処理をする
            // 現在は元の位置に戻るだけとする
            this.transform.localScale = Vector3.one;
        }
    }

    void FixedUpdate()
    {
        if (_isPull)
        {
            _delPos = _startPos - this._player.position;

            // 縦、奥行きの大きさを固定
            _delPos.y = 1f;
            _delPos.z = 1f;

            // 右に行かないと長くならないようにする
            if (-1f < _delPos.x)
            {
                _delPos.x = 1;
            }

            this.transform.localScale = _delPos;
            Debug.Log("[PullBox]" + this.transform.localScale);
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
