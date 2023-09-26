using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asibaMove : MonoBehaviour
{
    // 秒数を数えるカウント.
    private int _count;
    //Transformを取得.
    private Transform _myTransform;
    // 座標を取得.
    private Vector3 _pos;
    // 5秒の時間.
    private int _time;
    // ギミックの移動量
    private float _moveZ;
    void Start()
    {
        _count = 0;
        _myTransform = this.transform;
        _pos = _myTransform.position;
        _time = 250;
        _moveZ = 0.04f;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        _count++;

        //5秒経ったら.
        if (_count < _time)
        {
            // z座標へ0.04減算.
            _pos.z -= _moveZ;
            // 座標を設定.
            _myTransform.position = _pos;  
        }
        //10秒経ったら.
        else if (_count < _time * 2)
        {
            // z座標へ0.04加算.
            _pos.z += _moveZ;
            // 座標を設定.
            _myTransform.position = _pos;  
        }
        //それ以上になったら.
        else
        {
            //カウントを初期化する.
            _count = 0;
        }
    }
}
