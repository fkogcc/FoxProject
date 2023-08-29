using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coll : MonoBehaviour
{
    // ハンドルタグのオブジェクトに当たっているかどうか
    private bool _isHandleHit;
    private bool _isHandleWallHit;


    public string _tagHandleName;
    public string _tagHandleWallName;

    private bool _isHandleHit2;
    private bool _isHandleWallHit2;

    public string _tagHandleName2;
    public string _tagHandleWallName2;
    private void Start()
    {
        _isHandleHit = false;
        _isHandleWallHit = false;

        _isHandleHit2 = false;
        _isHandleWallHit2 = false;
    }

    private void Update()
    {
    
    }

    void OnTriggerEnter(Collider collision)
    {
        // プレイヤーに当たる
        if (collision.gameObject.name == _tagHandleName)
        {           
            _isHandleHit = true;
        }
        // プレイヤーに当たる
        if (collision.gameObject.name == _tagHandleWallName)
        {
            _isHandleWallHit = true;
        }

        // プレイヤーに当たる
        if (collision.gameObject.name == _tagHandleName2)
        {
            _isHandleHit2 = true;
        }
        // プレイヤーに当たる
        if (collision.gameObject.name == _tagHandleWallName2)
        {
            _isHandleWallHit2 = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        // プレイヤーに当たっていない場合
        if (collision.gameObject.name == _tagHandleName)
        {
            _isHandleHit = false;
        }
        // プレイヤーに当たっていない場合
        if (collision.gameObject.name == _tagHandleWallName)
        {
            _isHandleWallHit = false;
        }

        // プレイヤーに当たっていない場合
        if (collision.gameObject.name == _tagHandleName2)
        {
            _isHandleHit2 = false;
        }
        // プレイヤーに当たっていない場合
        if (collision.gameObject.name == _tagHandleWallName2)
        {
            _isHandleWallHit2 = false;
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

    // ハンドルに当たっているかどうか
    public bool HitHandle2()
    {
        return _isHandleHit2;
    }
    // ハンドル差し込む壁に当たっているかどうか
    public bool HitHandleWall2()
    {
        return _isHandleWallHit2;
    }
}
