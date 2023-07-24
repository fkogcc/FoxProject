using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    GameObject _handle1;
    GameObject _playerColl;
    public string _name;
    // 壁にセットできるかどうか
    private bool _isWallNowSet;
    // 壁にセットできたかどうか
    private bool _isWallSet;
    // 壁にセットした後どうするか
    private bool _isWallSetRota;
    // Start is called before the first frame update
    void Start()
    {
        _handle1 = GameObject.Find(_name);
        _playerColl = GameObject.Find("fox");
        _isWallSet = false;
        _isWallSetRota = false;
        _isWallNowSet = false;
    }

    // Update is called once per frame
    void Update()
    {
        // ハンドルを差し込んだかどうか
        if(!_isWallSetRota)
        {
            // ハンドルの近くにいるかどうか
            bool isHit = _playerColl.GetComponent<Coll>().HitHandle();
            // ハンドル差し込み用の壁近くにいるかどうか
            bool isHitWall = _playerColl.GetComponent<Coll>().HitHandleWall();

            // ハンドルの近くにいるかどうか
            // いなかったら回転しない
            if (isHit && !isHitWall)
            {
                // ボタンを押したら回転
                // ハンドルの回転を有効化する
                if (Input.GetKeyDown("joystick button 1"))
                {
                    _handle1.GetComponent<Rota>().enabled = true;
                    _handle1.GetComponent<HandlePos>().HandlePosIsPlayer();
                    _isWallNowSet = true;
                }
            }
            else
            {
                _handle1.GetComponent<Rota>().enabled = false;
            }

            // 回転がおわったかどうか
            // 終わったらプレイヤーの位置にハンドルが移動
            bool isRotaEnd = _handle1.GetComponent<Rota>().RotaEnd();
            if (_isWallNowSet)
            {
                _handle1.GetComponent<Rota>().enabled = false;
                _handle1.GetComponent<HandlePos>().HandlePosIsPlayer();
                isHit = true;
            }

            // ハンドルを持っていてハンドル差し込み口にいたら
            // 差し込める
            if (isHitWall && isHit)
            {
                if (Input.GetKeyDown("joystick button 1"))
                {
                    _isWallSet = true;
                    Debug.Log("差し込みます");
                    _handle1.GetComponent<HandlePos>().HandlePosIsHandleWall();
                    _handle1.GetComponent<Rota>().RotaReset();
                    _isWallSetRota = true;
                    _isWallNowSet = false;
                }
            }
        }
        else
        {
            // ハンドル差し込み用の壁近くにいるかどうか
            bool isHitWall = _playerColl.GetComponent<Coll>().HitHandleWall();
            if(isHitWall)
            {
                // 回転させる
                if (Input.GetKeyDown("joystick button 1"))
                {
                    _handle1.GetComponent<Rota>().enabled = true;
                }
            }
            else
            {
                _handle1.GetComponent<Rota>().enabled = false;
            }
            // 回転がおわったかどうか
            bool isRotaEnd = _handle1.GetComponent<Rota>().RotaEnd();
            if(isRotaEnd)
            {
                Debug.Log("おわりました お疲れ様です");
                _handle1.GetComponent<Rota>().enabled = false;
            }
        }
    }
}
