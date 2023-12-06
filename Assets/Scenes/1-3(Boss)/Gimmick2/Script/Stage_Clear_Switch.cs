﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_Clear_Switch : MonoBehaviour
{
    private bool _isClear;
    private bool _isPushSwich  = false;
    private int _waitTimer = 45;
    // クリア画像.
    [SerializeField]private GenerateImg _img;
    // エフェクト
    [SerializeField] private GameObject _effect;
    private GameObject _particleSystem;
    // サウンド.
    [SerializeField] private SoundManager _sound;
    private void Start()
    {
        _isClear = false;
    }

    void OnCollisionStay(Collision collision)
    {
        //プレイヤーが触れたとき.
        //if (collision.gameObject.name == "3DPlayer")
        //{
        //    if(Input.GetKeyDown("joystick button 2"))
        //    {
        //        //ステージクリアの関数を呼ぶ
        //        _isClear= true;
        //    }                            
        //}
    }

    private void OnTriggerStay(Collider other)
    {
        //プレイヤーが触れたとき.
        if (other.gameObject.name == "3DPlayer")
        {
            if (Input.GetKeyDown("joystick button 1"))
            {
                _sound.PlaySE("1_3_3_InBox");
                _particleSystem = Instantiate(_effect, this.transform.position, this.transform.rotation);
                _isPushSwich = true;
            }
        }
    }
    private void ClearWaitTime()
    {
        _img.GenerateImage();
        _waitTimer--;
        if (_waitTimer <= 0)
        {
            // ステージクリアの関数を呼ぶ
            _isClear = true;
        }
    }
    //ステージクリアの関数
    public bool GetResult()
    {
        if (_isPushSwich)
        {
            ClearWaitTime();
        }
        return _isClear;
    }
}
