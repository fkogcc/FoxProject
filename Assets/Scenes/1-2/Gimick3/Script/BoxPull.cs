using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPull : MonoBehaviour
{
    const int kNum = 16;

    // プレイヤーの位置情報
    Transform _player;

    // ギミックオブジェ
    GameObject _gimmick;
    GameObject[] _gimmicks = new GameObject[kNum];


    // 引っ張れる範囲にいるかの
    bool _isPullRange;

    // 引っ張っているか
    bool _isPull;


    // 引っ張り始めた位置
    Vector3 _startPos;

    // 移動ベクトル
    Vector3 _moveVec;

    void Start()
    {
        _player = GameObject.Find("3DPlayer").GetComponent<Transform>();

        _gimmick = (GameObject)Resources.Load("Cube");

        for (int i = 0; i < kNum; i++)
        {
            _gimmicks[i] = Instantiate(_gimmick, this.transform.position, Quaternion.identity);
        }

        _isPullRange = false;
        _isPull = false;

        _startPos = new Vector3();
        _moveVec = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown("joystick button 1") || Input.GetKeyDown(KeyCode.F)) && _isPullRange)
        {
            Debug.Log("引っ張り始めた");

            // 引っ張り始めた位置の保存
            _startPos = _player.position;

            _isPull = true;
        }

        if ((Input.GetKeyDown("joystick button 1") || Input.GetKeyUp(KeyCode.F)))
        {
            Debug.Log("引っ張り終わり");

            // 元の位置に戻す
            for (int i = 0; i < kNum; i++)
            {
                _gimmicks[i].transform.position = this.transform.position;
            }

            _isPull = false;
        }
    }

    void FixedUpdate()
    {
        if (_isPull)
        {
            // 現在までのベクトルを計算
            _moveVec = _player.position - _startPos;

            // 出すオブジェクトの量で割る
            _moveVec /= kNum;

            // 少しずつずらして位置を置く
            for (int i = 0; i < kNum; i++)
            {
                _gimmicks[i].transform.position = this.transform.position + _moveVec * i;
            }
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
