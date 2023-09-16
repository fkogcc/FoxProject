using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPull : MonoBehaviour
{
    // プレイヤーの位置情報
    Transform _player;
    // 子オブジェクト(ギミックのやつ)
    GameObject _gimmick;

    // 初期の位置
    Vector3 _startPos;

    // 引っ張り始めた位置
    Vector3 _pullPos;
    // 距離引っ張り始めた位置から現在までの距離
    Vector3 _delPos;

    // 角度
    float _angle;
    Vector3 _arrow;
    Vector3 _tempPos;

    // 引っ張れる範囲にいるかの判定
    bool _isPullRange;

    // 引っ張っているか
    bool _isPull;

    void Start()
    {
        _player = GameObject.Find("3DPlayer").GetComponent<Transform>();

        _gimmick = transform.GetChild(0).gameObject;

        _startPos = _gimmick.transform.position;

        _angle = 0f;
        _arrow = new Vector3(0.0f, 1.0f, 0.0f);
        _tempPos = new Vector3();

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
            _pullPos = this._player.position;

            _isPull = true;
        }

        if ((Input.GetKeyDown("joystick button 1") || Input.GetKeyUp(KeyCode.F)))
        {
            Debug.Log("引っ張り終わり");

            _isPull = false;

            // 元の位置、角度、サイズに戻す
            _gimmick.transform.position = _startPos;
            _gimmick.transform.rotation = Quaternion.identity;
            _gimmick.transform.localScale = Vector3.one;
        }
    }

    void FixedUpdate()
    {
        if (_isPull)
        {
            //ChangeCenter();

            //ChangeSize();

            _tempPos = _player.position;
            _tempPos.z = _pullPos.z;

            _angle = Vector3.Angle(_tempPos, _player.position);

            if (0 < _player.position.z - _tempPos.z)
            {
                _angle *= -1;
            }

            //Debug.Log("[PullBox] pull" + _pullPos);
            //Debug.Log("[PullBox] player" + _player.position);
            Debug.Log("[PullBox] angle" + _angle);

            this.transform.rotation = Quaternion.AngleAxis(_angle, _arrow);
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

    /// 　中心を変更する関数(多分これ消す)
    void ChangeCenter()
    {
        // 初めの位置を保存
        _delPos = _startPos;
        // 移動している場合中心を右に移動させる
        _delPos.x = _delPos.x - (_pullPos.x - _player.position.x) / 2.0f;

        // 中心を移動させた物を実装
        _gimmick.transform.position = _delPos;
    }

    // サイズを変更する関数(多分これも消す)
    void ChangeSize()
    {
        // 引き始めた位置から現在のX座標の距離を確認
        _delPos.x = _pullPos.x - this._player.position.x;

        // 右に行かないと長くならないようにする
        if (-1f < _delPos.x)
        {
            _delPos.x = 1;
        }

        // 縦、奥行きの大きさを固定
        _delPos.y = 1f;
        _delPos.z = 1f;

        // サイズの変更
        _gimmick.transform.localScale = _delPos;
    }
}
