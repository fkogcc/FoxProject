
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalMove1_1 : MonoBehaviour
{
    // 球面線形補間
    [Header("始点")]
    [SerializeField] private GameObject _StartPos;

    [Header("終点")]
    [SerializeField] private GameObject _EndPos;

    [Header("移動時間")]
    [SerializeField] private float _moveTime = 1;

    [Header("円運動の中心点")]
    [SerializeField] private GameObject _sphereCenter;

    // ゴールが最初にいる場所の座標
    private Vector3 _start;
    // 最終的にたどり着く座標
    private Vector3 _end;

    // ゴールを動かすときの真偽
    public bool _eventFlag = false;

    // 補間位置の計算の値
    float _interpolationPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _start = _StartPos.transform.position;
        _end = _EndPos.transform.position;

        // 補間位置計算
        _interpolationPosition = Time.time / _moveTime;

        // 円運動の中心点取得
        var center = _sphereCenter.transform.position;

        // 円運動させる前に中心点が原点に来るように始点・終点を移動
        _start -= center;
        _end -= center;

        // 原点中心で円運動
        var slerpPos = Vector3.Slerp(_start, _end, _interpolationPosition);

        // 中心点だけずらした位置を戻す
        slerpPos += center;

        // 補間位置を反映
        transform.position = slerpPos;
    }

    private void FixedUpdate()
    {
        if (!_eventFlag) return;


    }

    private void SlerpMove()
    {

    }
}
