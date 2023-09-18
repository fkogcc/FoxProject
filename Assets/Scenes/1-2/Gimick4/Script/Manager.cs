using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    GameObject _botton;
    GameObject _rota;
    GameObject _coll;
    // Start is called before the first frame update
    void Start()
    {

        _botton = GameObject.Find("GameManager");
        _rota   = GameObject.Find("cordRota");
        _coll   = GameObject.Find("cordRota");
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
                _coll.GetComponent<MyCollsion3D>().SetHit(false);
            }
        }
        // ボタンを押していない
        _coll.GetComponent<MyCollsion3D>().SetHit(false);
    }
}
