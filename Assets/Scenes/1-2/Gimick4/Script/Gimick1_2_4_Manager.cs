using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimick1_2_4_Manager : MonoBehaviour
{

    // ボタン操作.
    GameObject _botton;
    // 回転用.
    [SerializeField] GameObject[] _rota;
    // 判定用.
    [SerializeField] GameObject[] _coll;
    // 回転するオブジェクトの最大数.
    public int _objRotaMaxNum;
    // 謎解きがとけたかどうか.
    private bool _isClear = false;
    // クリア出来たかどうか.
    private bool _clear = false;

    void Start()
    {
        // ボタン用.
        _botton = GameObject.Find("GameManager");
    }

    void Update()
    {
        for(int i = 0; i < _objRotaMaxNum; i++)
        {
            // オブジェクトにあたっていたら.
            if (_coll[i].GetComponent<MyCollsion3D>().IsGetHit())
            {
                // ボタンをおしたら.
                if (_botton.GetComponent<Botton>().GetButtonB())
                {
                    // 回転したら.
                    _rota[i].GetComponent<TurnGraph>().Rota();
                }
            }
        }

        for (int i = 0; i < _objRotaMaxNum; i++)
        {
            if(_rota[i].GetComponent<TurnGraph>().IsGetAns())
            {
               // Debug.Log(i);
                Debug.Log(_rota[i].GetComponent<TurnGraph>().tempAngle());
            }
        }

        // すべての謎がとけたら.
        if (_rota[0].GetComponent<TurnGraph>().IsGetAns() &&
            _rota[1].GetComponent<TurnGraph>().IsGetAns() &&
            _rota[2].GetComponent<TurnGraph>().IsGetAns() &&
            _rota[3].GetComponent<TurnGraph>().IsGetAns() &&
            _rota[4].GetComponent<TurnGraph>().IsGetAns() &&
            _rota[5].GetComponent<TurnGraph>().IsGetAns() &&
            _rota[6].GetComponent<TurnGraph>().IsGetAns() &&
            _rota[7].GetComponent<TurnGraph>().IsGetAns() &&
            _rota[8].GetComponent<TurnGraph>().IsGetAns() &&
            _rota[9].GetComponent<TurnGraph>().IsGetAns())
        {
            // ここでシーンを切り替え.
            _clear = true;
            Debug.Log("クリア"); 
        }

    }
    // クリアしたかどうか
    public bool GetResult()
    {
        return _clear;
    }
}
