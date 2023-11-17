﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    private float kwallHeight = 1.5f;//最初の壁の高さ
    //private float kclearHeight = -5.0f;//この高さまで壁を下げたらクリア
    private float kclearLavaPos = 9.2f;//クリアした際の溶岩のポジション
    private Vector3 klavaSpeed = new Vector3(0.03f, 0, 0);
    //ロープのゲームオブジェクト
    private GameObject _rope;
    private PullRope _pullRope;
    //下がる壁のゲームオブジェクト
    private GameObject _wall;
    //動く溶岩のゲームオブジェクト
    private GameObject _lava;
    //動く壁のポジション
    private Vector3 _wallPos;
    //引っ張ったロープの長さ
    private float kclearHeight = 0;//この高さまで壁を下げたらクリア
    // 今のフレームのロープの長さ
    private float _nowRopeLength;
    // 前のフレームのロープの長さ
    private float _prevRopeLength = 0.0f;
    //引っ張れる場所にいるかどうか
    private bool _isFlag;
    // クリアフラグ
    private bool _isClearFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        _rope = GameObject.Find("Rope");
        _pullRope = _rope.GetComponent<PullRope>();
        _wall = GameObject.Find("Door");
        _lava = GameObject.Find("MoveLava");
        _wallPos = _wall.transform.position;//壁のポジションを取得
        // HACK あとできれいに書き直す
        // (当たり判定を半分引いて 下げる位置を計算している)
        kclearHeight = _lava.transform.position.y - (_wall.GetComponent<BoxCollider>().bounds.size.y * 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //_ropeLength = _rope.GetComponent<PullRope>().GetNowLength() - 5;
        //if (_ropeLength > 0 && _wallPos.y > kclearHeight)//壁の高さがクリアの高さよりも低くなるまで動く
        //{
        //    _wallPos.y =kwallHeight - _ropeLength;
        //    _wall.transform.position = _wallPos;
        //}
        //if (_wallPos.y <= kclearHeight)
        //{
        //    _isFlag = true;
        //}
        //if (_isFlag)
        //{
        //    if (_lava.transform.position.x < kclearLavaPos)
        //    {
        //        _lava.transform.Translate(klavaSpeed);
        //    }
        //}

        WallUpdate();
    }
    // 壁の計算の更新処理.
    private void WallUpdate()
    {
        // 今のロープの長さを取得する
        _nowRopeLength = _pullRope.GetNowLength();
        // 今のロープの位置と前フレームのロープの位置が同じじゃなければ処理をする
        if (_nowRopeLength != _prevRopeLength)
        {
            // 前のフレームから引っ張った分の長さの差分を出す
            var addLength = _nowRopeLength - _prevRopeLength;
            //壁の高さがクリアの高さよりも低くなるまで動く
            if (_nowRopeLength > 0 && _wallPos.y > kclearHeight)
            {
                _wallPos.y = _wall.transform.position.y - addLength;
                _wall.transform.position = _wallPos;
            }
        }
        // クリア位置まで壁が下がったら溶岩を流すフラグを立てる
        if (_wallPos.y <= kclearHeight)
        {
            _isFlag = true;
        }

        // 溶岩を流す処理
        if (_isFlag)
        {
            if (_lava.transform.position.x < kclearLavaPos)
            {
                _lava.transform.Translate(klavaSpeed);
            }
            else
            {
                //Debug.Log("くりあ");
                _isClearFlag = true;
            }
        }
        // ロープの位置の更新
        _prevRopeLength = _nowRopeLength;
    }
    public bool GetResult()
    {
        return _isClearFlag;
    }
}
