using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    // ボタン処理
    GameObject _botton;
    // オブジェクト回転処理
    GameObject _rota;
    // 当たり判定処理
    GameObject _coll;
    // Start is called before the first frame update
    void Start()
    {
        // ボタン処理
        _botton = GameObject.Find("GameManager");
        // オブジェクト回転処理
        _rota   = GameObject.Find("cordRota0");
        // 当たり判定処理
        _coll = GameObject.Find("cordRota0");
    }

    void Update()
    {
        // プレイヤーが当たっていたら
        if (_coll.GetComponent<MyCollsion3D>().IsGetHit())
        {
            // ボタンを押したら
            if (_botton.GetComponent<Botton>().GetButtonB())
            {
                // 回転
                _rota.GetComponent<TurnGraph>().Rota();
            }
        }
    }
}
