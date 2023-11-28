using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    // 何フレームで動き出すようにするか.
    private const int kChangeFrame = 50;
    // どの高さまで上がる処理をするか.
    private const float kUpHeight = 13.0f;
    // どの高さまで下がる処理をするか.
    private const float kDownHeight = 13.0f;

    // 上がるときにプレイヤーも一緒に上げるよう.
    private GameObject _player;
    // サウンド用
    public SoundManager Sound;
    // 前鳴らした情報用
    private bool _isPlaySound;

    // 移動量.
    private Vector3 _vec;

    // カウント用.
    private int _count;

    // プレイヤーが動作範囲内にいるか.
    private bool _isStay;

    // 上がる処理判定.
    private bool _isUp;
    // 下がる処理判定.
    private bool _isDown;

    private void Start()
    {
        _player = GameObject.Find("3DPlayer");
        _vec = new Vector3(0f, 0.125f, 0f);

        _count = 0;

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
            _count++;
            // 一定時間たったら上がるようにする.
            if (kChangeFrame <= _count)
            {
                _isUp = true;
                _isDown = false;
            }
        }
        else
        {
            _count++;
            // 一定時間たったら下がるようにする.
            if (kChangeFrame <= _count)
            {
                _isDown = true;
                _isUp = false;
            }
        }

        // 上がる処理.
        if (_isUp)
        {
            if (this.transform.position.y < kUpHeight)
            {
                // ここでプレイヤーも一緒に上げることでかくかくした動き(振動するような)
                // をなくすようにする.
                _player.transform.position += _vec;
                this.transform.position += _vec;

                if (!_isPlaySound)
                {
                    Sound.PlaySE("1_2_3_Elevator");
                    _isPlaySound = true;
                }
            }
        }
        // 降りる処理.
        if (_isDown)
        {
            if (kDownHeight < this.transform.position.y)
            {
                this.transform.position -= _vec;

                if (!_isPlaySound)
                {
                    Sound.PlaySE("1_2_3_Elevator");
                    _isPlaySound = true;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _isStay = true;
        _isPlaySound = false;
        _count = 0;
    }

    private void OnTriggerExit(Collider other)
    {
        _isStay = false;
        _isPlaySound = false;
        _count = 0;
    }
}
