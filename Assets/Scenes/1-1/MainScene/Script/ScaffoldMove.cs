// 上下に動く足場.
// TODO:足場オブジェクトを一時的に消しているためアタッチしているオブジェクトはない.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaffoldMove : MonoBehaviour
{
    // 上の座標限界地.
    float _top;
    // 下の座標限界地.
    float _bottom;
    // 動くスピードの絶対値.
    private float _speed = 0.05f;
    // 動く向きの変更.
    private float _exchange = 0.05f;
    

    void Start()
    {
        // 初期化.
        _top = gameObject.transform.position.y + 3.0f;
        _bottom = gameObject.transform.position.y - 3.0f;
    }

    private void FixedUpdate()
    {
        // オブジェクト確認.
        //Debug.Log($"{name}");

        // スピードの変更.
        if (gameObject.transform.position.y > _top)
        {
            _exchange = -_speed;
        }

        if(gameObject.transform.position.y < _bottom)
        {
            _exchange = _speed;
        }

        gameObject.transform.Translate(0, _exchange, 0);
    }
}
