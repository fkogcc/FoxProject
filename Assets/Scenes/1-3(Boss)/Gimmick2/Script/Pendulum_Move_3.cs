using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum_Move_3 : MonoBehaviour
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
    //処理を開始する時間.
    int _time = 75;

    private void Start()
    {
        //回転の軸を名前指定で取得する.
        _Cube = GameObject.Find("CubeRotate3");
    }

    void FixedUpdate()
    {
        //カウントを追加する.
        _count++;
        //カウントに対して処理を変える.
        if (_count < _time)
        {
            // X,Y,Z軸に対してそれぞれ、指定した角度ずつ回転させている.
            // deltaTimeをかけることで、フレームごとではなく、1秒ごとに回転するようにしている.
            _Cube.transform.Rotate(new Vector3(_rotateX, _rotateY, _rotateZ) * -Mathf.Deg2Rad * 2);
        }
        else if (_count < _time * 3)
        {
            // X,Y,Z軸に対してそれぞれ、指定した角度ずつ回転させている.
            // deltaTimeをかけることで、フレームごとではなく、1秒ごとに回転するようにしている.
            _Cube.transform.Rotate(new Vector3(_rotateX, _rotateY, _rotateZ) * Mathf.Deg2Rad * 2);
        }
        else if (_count < _time * 4)
        {
            // X,Y,Z軸に対してそれぞれ、指定した角度ずつ回転させている.
            // deltaTimeをかけることで、フレームごとではなく、1秒ごとに回転するようにしている.
            _Cube.transform.Rotate(new Vector3(_rotateX, _rotateY, _rotateZ) * -Mathf.Deg2Rad * 2);
        }
        else
        {
            _count = 0;
        }

    }
}
