using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coll : MonoBehaviour
{
    // ハンドルタグのオブジェクトに当たっているかどうか
    private bool _isHandleHit;
    private bool _isHandleWallHit;
    
    private void Start()
    {
        _isHandleHit = false;
        _isHandleWallHit = false;
    }

    private void Update()
    {
    
    }

    void OnTriggerEnter(Collider collision)
    {
        // プレイヤーに当たる
        if (collision.tag == "handle")
        {           
            _isHandleHit = true;
        }
        // プレイヤーに当たる
        if (collision.tag == "handleWall")
        {
            _isHandleWallHit = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        // プレイヤーに当たっていない場合
        if (collision.tag == "handle")
        {
            _isHandleHit = false;
        }
        // プレイヤーに当たっていない場合
        if (collision.tag == "handleWall")
        {
            _isHandleWallHit = false;
        }
    }

    // ハンドルに当たっているかどうか
    public bool HitHandle()
    {
        return _isHandleHit;
    }
    // ハンドル差し込む壁に当たっているかどうか
    public bool HitHandleWall()
    {
        return _isHandleWallHit;
    }
}
