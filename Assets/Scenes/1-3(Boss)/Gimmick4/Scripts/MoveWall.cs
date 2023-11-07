using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    private float kwallHeight = 1.5f;//最初の壁の高さ
    private float kclearHeight = -0.5f;//この高さまで壁を下げたらクリア
    private float kclearLavaPos = 9.2f;//クリアした際の溶岩のポジション
    private Vector3 klavaSpeed = new Vector3(0.03f,0,0);
    //ロープのゲームオブジェクト
    private GameObject _rope;
    //下がる壁のゲームオブジェクト
    private GameObject _wall;
    //動く溶岩のゲームオブジェクト
    private GameObject _lava;
    //動く壁のポジション
    private Vector3 _wallPos;
    //引っ張ったロープの長さ
    private float _ropeLength;
    //引っ張れる場所にいるかどうか
    private bool _isFlag;
    // Start is called before the first frame update
    void Start()
    {
        _rope = GameObject.Find("Rope");
        _wall = GameObject.Find("MoveWall");
        _lava = GameObject.Find("MoveLava");
        _wallPos = _wall.transform.position;//壁のポジションを取得
    }

    // Update is called once per frame
    void Update()
    {
        _ropeLength = _rope.GetComponent<PullRope>().GetNowLength() - 5;
        if (_ropeLength > 0 && _wallPos.y > kclearHeight)//壁の高さがクリアの高さよりも低くなるまで動く
        {
            _wallPos.y =kwallHeight - _ropeLength;
            _wall.transform.position = _wallPos;
        }
        if (_wallPos.y <= kclearHeight)
        {
            _isFlag = true;
        }
        if (_isFlag)
        {
            if (_lava.transform.position.x < kclearLavaPos)
            {
                _lava.transform.Translate(klavaSpeed);
            }
        }
    }
}
