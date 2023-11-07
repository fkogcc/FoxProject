using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimick1_2_4_Manager1Mk2 : MonoBehaviour
{
    // ボタン操作.
    GameObject _botton;
    // 回転用.
    [SerializeField] GameObject[] _rota;
    TurnGraph[] _rotaGraph = new TurnGraph[17];

    // 判定用.
    [SerializeField] GameObject[] _coll;
    // 回転するオブジェクトの最大数.
    public int _objRotaMaxNum;
    // 謎解きがとけたかどうか.
    private bool _isClear = false;
    // 回路が正しい場合のカウント.
    private int _ansCount = 0;

    void Start()
    {
        // ボタン用.
        _botton = GameObject.Find("GameManager2");

        for (int i = 0; i < _objRotaMaxNum; i++)
        {
            _rotaGraph[i] = _rota[i].GetComponent<TurnGraph>();
        }
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
        
        // 回路が正しく接続されている数を確認.
        for (int i = 0; i < _objRotaMaxNum; i++)
        {
            if (!_rotaGraph[i].IsGetAns())
            {
                _ansCount = 0;
                break;
            }
            else
            {
                _ansCount++;
            }
        }

        // 全ての回路が正しく接続されている場合.
        if (_ansCount == _objRotaMaxNum)
        {
            _isClear = true;
        }

    }
    // クリアしたかどうか.
    public bool GetResult()
    {
        return _isClear;
    }
}
