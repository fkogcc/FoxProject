﻿/*1-2のボスの挙動*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_2 : MonoBehaviour
{
    // ゴールフラグ.
    private GateFlag _goalFlag;
    // イベント開始
    private bool _isEvent = false;
    // アニメーター
    private Animator _animator;


    void Start()
    {
        _goalFlag = GameObject.FindWithTag("Player").GetComponent<GateFlag>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(_goalFlag._isGoal1_2 && Input.GetKeyDown("joystick button 3"))
        {
            _isEvent = true;
        }
    }

    private void FixedUpdate()
    {
        if(_isEvent)
        {
            transform.position += new Vector3(-0.7f,0.0f,0.0f);
            _animator.SetFloat("Eat", 0.35f);
        }

        

    }
}