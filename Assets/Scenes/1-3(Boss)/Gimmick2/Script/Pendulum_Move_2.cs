﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum_Move_2 : MonoBehaviour
{
    //回転の軸を取得.
    GameObject _Cube;
    //X座標の回転速度.
    private float _rotateX = 0;
    //Y座標の回転速度.
    private float _rotateY = 0;
    //Z座標の回転速度.
    private float _rotateZ = 30;
    //秒数のカウント.
    int _count = 0;

    private void Start()
    {
        _Cube = GameObject.Find("CubeRotate2");
    }

    void FixedUpdate()
    {
        //カウントを追加する.
        _count++;
        //カウントに対して処理を変える.
        if (_count < 75)
        {
            // X,Y,Z軸に対してそれぞれ、指定した角度ずつ回転させている。
            // deltaTimeをかけることで、フレームごとではなく、1秒ごとに回転するようにしている。
            _Cube.transform.Rotate(new Vector3(_rotateX, _rotateY, _rotateZ) * Mathf.Deg2Rad * 2);
        }
        else if (_count < 225)
        {
            // X,Y,Z軸に対してそれぞれ、指定した角度ずつ回転させている。
            // deltaTimeをかけることで、フレームごとではなく、1秒ごとに回転するようにしている。
            _Cube.transform.Rotate(new Vector3(_rotateX, _rotateY, _rotateZ) * -Mathf.Deg2Rad * 2);
        }
        else if (_count < 300)
        {
            // X,Y,Z軸に対してそれぞれ、指定した角度ずつ回転させている。
            // deltaTimeをかけることで、フレームごとではなく、1秒ごとに回転するようにしている。
            _Cube.transform.Rotate(new Vector3(_rotateX, _rotateY, _rotateZ) * Mathf.Deg2Rad * 2);
        }
        else
        {
            _count = 0;
        }

    }
}