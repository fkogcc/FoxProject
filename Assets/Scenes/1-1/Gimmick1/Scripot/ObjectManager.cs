using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    GameObject _handle;
    GameObject _playerColl;
    public string _name;
    // 壁にセットできるかどうか
    private bool _isWallNowSet;
    // 壁にセットした後どうするか
    private bool _isWallSetRota;

    // ハンドルナンバー
    public int _handleNo;
    // Start is called before the first frame update
    void Start()
    {
        _handle = GameObject.Find(_name);
        _playerColl = GameObject.Find("fox");
        _isWallSetRota = false;
        _isWallNowSet = false;
    }

    // Update is called once per frame
    void Update()
    {
        // ハンドルを差し込んだかどうか
        if(!_isWallSetRota)
        {
            bool isHit = false;
            bool isHitWall = false;
            if (_handleNo == 1)
            {
                // ハンドルの近くにいるかどうか
                isHit = _playerColl.GetComponent<Coll>().HitHandle();
                // ハンドル差し込み用の壁近くにいるかどうか
                isHitWall = _playerColl.GetComponent<Coll>().HitHandleWall();
            }
            else if (_handleNo == 2)
            {
                // ハンドルの近くにいるかどうか
                isHit = _playerColl.GetComponent<Coll>().HitHandle2();
                //// ハンドル差し込み用の壁近くにいるかどうかSSSsSssssSSS
                isHitWall = _playerColl.GetComponent<Coll>().HitHandleWall2();
            }

            // ハンドルの近くにいるかどうか
            // いなかったら回転しない
            if (isHit && !isHitWall)
            {
                // ボタンを押したら回転
                // ハンドルの回転を有効化する
                if (Input.GetKeyDown("a"))
                {
                    _handle.GetComponent<Rota>().enabled = true;
                    _handle.GetComponent<HandlePos>().HandlePosIsPlayer();
                    _isWallNowSet = true;
                }
            }
            else
            {
                _handle.GetComponent<Rota>().enabled = false;
            }

            // 回転がおわったかどうか
            // 終わったらプレイヤーの位置にハンドルが移動
            bool isRotaEnd = _handle.GetComponent<Rota>().RotaEnd();
            if (_isWallNowSet)
            {
                _handle.GetComponent<Rota>().enabled = false;
                _handle.GetComponent<HandlePos>().HandlePosIsPlayer();
                isHit = true;
            }

            // ハンドルを持っていてハンドル差し込み口にいたら
            // 差し込める
            if (isHitWall && isHit)
            {
                if (Input.GetKeyDown("a"))
                {
                    Debug.Log("差し込みます");
                    _handle.GetComponent<HandlePos>().HandlePosIsHandleWall();
                    _handle.GetComponent<Rota>().RotaReset();
                    _isWallSetRota = true;
                    _isWallNowSet = false;
                }
            }
        }
        else
        {
            bool isHitWall = false;
            if (_handleNo == 1)
            {
                // ハンドル差し込み用の壁近くにいるかどうか
                isHitWall = _playerColl.GetComponent<Coll>().HitHandleWall();
            }
            else if(_handleNo == 2)
            {
                // ハンドル差し込み用の壁近くにいるかどうか
                isHitWall = _playerColl.GetComponent<Coll>().HitHandleWall2();
            }
            if(isHitWall)
            {
                // 回転させる
                if (Input.GetKeyDown("a"))
                {
                    _handle.GetComponent<Rota>().enabled = true;
                }
            }
            else
            {
                _handle.GetComponent<Rota>().enabled = false;
            }
            // 回転がおわったかどうか
            bool isRotaEnd = _handle.GetComponent<Rota>().RotaEnd();
            if(isRotaEnd)
            {
                Debug.Log("おわりました お疲れ様です");
                _handle.GetComponent<Rota>().enabled = false;
            }
        }
    }

}
