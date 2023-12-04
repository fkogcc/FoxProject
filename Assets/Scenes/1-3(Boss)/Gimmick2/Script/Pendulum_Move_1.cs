using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum_Move_1 : MonoBehaviour
{
    //回転の軸を取得.
    GameObject _Cube;
    //X座標の回転速度.
    private float _rotateX = 0;
    //Y座標の回転速度.
    private float _rotateY = 0;
    //Z座標の回転速度.
    private float _rotateZ = 30;
    Quaternion _rotation;
        

    private void Start()
    {
        //回転の軸を名前指定で取得する.
         _Cube = GameObject.Find("CubeRotate1");
        _rotation = _Cube.transform.rotation;
    }

    void FixedUpdate()
    {
        //カウントに対して処理を変える.
        if (_rotation.z > -0.5)
        {
            // X,Y,Z軸に対してそれぞれ、指定した角度ずつ回転させている。
            // deltaTimeをかけることで、フレームごとではなく、1秒ごとに回転するようにしている。
            _Cube.transform.Rotate(new Vector3(_rotateX, _rotateY, _rotateZ) * -Mathf.Deg2Rad * 2);       
        }
        else if (_rotation.z < -0.5)
        {
            // X,Y,Z軸に対してそれぞれ、指定した角度ずつ回転させている。
            // deltaTimeをかけることで、フレームごとではなく、1秒ごとに回転するようにしている。
            _Cube.transform.Rotate(new Vector3(_rotateX, _rotateY, _rotateZ) * Mathf.Deg2Rad * 2);
        }
        else if (_rotation.z > 0.5)
        {
            // X,Y,Z軸に対してそれぞれ、指定した角度ずつ回転させている。
            // deltaTimeをかけることで、フレームごとではなく、1秒ごとに回転するようにしている。
            _Cube.transform.Rotate(new Vector3(_rotateX, _rotateY, _rotateZ) * Mathf.Deg2Rad * 2);
        }
        //角度の更新
        _rotation = _Cube.transform.rotation;
        Debug.Log(_rotation.z);
    }
}
