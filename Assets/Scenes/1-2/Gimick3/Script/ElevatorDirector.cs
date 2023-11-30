﻿using UnityEngine;
// エレベーターの移動するクリプト.
public class ElevatorDirector : MonoBehaviour
{
    // 何フレームで動き出すようにするか.
    private readonly static int kChangeFrame = 50;
    // どの高さまで上がる処理をするか.
    private readonly static float kUpHeight = 13.0f;
    // どの高さまで下がる処理をするか.
    private readonly static float kDownHeight = 6.8f;
    // 上がるときにプレイヤーも一緒に上げるよう.
    private GameObject _player;
    // サウンド用.
    [SerializeField] private SoundManager _sound;
    // 前鳴らした情報用.
    private bool _isPlaySound;
    // 移動量.
    private Vector3 _vec;
    // カウント用.
    private int _frameCount;
    // プレイヤーが動作範囲内にいるか.
    private bool _isStay;
    // 上がる処理判定.
    private bool _isUp;
    // 下がる処理判定.
    private bool _isDown;
    // 初期化処理.
    private void Start()
    {
        _player = GameObject.Find("3DPlayer");
        _vec = new Vector3(0f, 0.125f, 0f);
        _frameCount = 0;
        _isStay = false;
        _isUp = false;
        _isDown = false;
        // 初めはならないように鳴らしたということにしておく
        _isPlaySound = true;
    }

    private void FixedUpdate()
    {
        if (_isStay)
        {
            // 一定時間たったら下がるようにする.
            FrameUpdate(true,false);
        }
        else
        {
            // 一定時間たったら下がるようにする.
            FrameUpdate(false,true);
        }

        // 上がる処理.
        if (_isUp)
        {
            if (this.transform.position.y < kUpHeight)
            {
                // ここでプレイヤーも一緒に上げることでかくかくした動き(振動するような)
                // をなくすようにする.
                _player.transform.position += _vec;
                // エレベーターを移動させる.
                ElevatorUpdate(_vec);
            }
        }
        // 降りる処理.
        if (_isDown)
        {
            if (kDownHeight < this.transform.position.y)
            {
                // エレベーターを移動させる.
                ElevatorUpdate(-_vec);
            }
        }
    }
    // フレーム処理.
    private void FrameUpdate(bool up, bool down)
    {
        _frameCount++;
        // 一定時間たったら下がるようにする.
        if (kChangeFrame <= _frameCount)
        {
            _isUp = up;
            _isDown = down;
        }
    }

    // エレベーターの更新処理.
    private void ElevatorUpdate(Vector3 vec)
    {
        // エレベーターの位置更新.
        this.transform.position += vec;
        // エレベーターの効果音を鳴らす.
        ElevatorSEPlay();
    }
    // エレベーター作動SEを鳴らす処理.
    private void ElevatorSEPlay()
    {
        if (!_isPlaySound)
        {
            _sound.PlaySE("1_2_3_Elevator");
            _isPlaySound = true;
        }
    }

    // 範囲内に入った時の処理.
    private void OnTriggerEnter(Collider other)
    {
        _isStay = true;
        _isPlaySound = false;
        _frameCount = 0;
    }

    // 範囲外に出た時の処理.
    private void OnTriggerExit(Collider other)
    {
        _isStay = false;
        _isPlaySound = false;
        _frameCount = 0;
    }
}
