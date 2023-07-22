using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coll : MonoBehaviour
{
   public bool _isHit;
    public bool _isItemGet;
    public bool _isHandleWallSet;
    GameObject _playerObj;
    GameObject _handleWallObj;
    public static handleWall _wall;
    private void Start()
    {
        _isHit = false;
        _isItemGet = false;
        _isHandleWallSet = false;

        // プレイヤ―
        _playerObj = GameObject.Find("fox");
        _handleWallObj = GameObject.Find("handleWall1");
    }

    private void Update()
    {
        if(!_isHandleWallSet)
        {
            if(_isHit)
            {
                if(Input.GetKey("a"))
                {
                    Debug.Log("押してます");
                    _isItemGet = true;  
                }
            }
        }
        // ハンドルの位置とプレイヤーの位置を同じにする
        if(_isItemGet)
        {
            this.transform.position = _playerObj.transform.position;
        }
        else
        {
            Debug.Log("離します");
        }
        if(!_wall._isHandleSet)
        {
            Debug.Log("セットします");
            this.transform.position = _handleWallObj.transform.position;
        }
    }

    void OnTriggerStay(Collider collision)
    {
        // ぶつかった相手の名前を取得
        Debug.Log(collision.gameObject.name); 

        // プレイヤーに当たる
        if (collision.tag == "Player")
        {
            _isHit = true;
        }
        else
        {
            _isHit = false;
        }
    }
    public void GetHandleFlag(bool isItemPosSet)
    {
        _isHandleWallSet = isItemPosSet;
    }

    //private void Awake()
    //{
    //    if(_coll == null)
    //    {
    //        _coll = this;
    //        DontDestroyOnLoad(this.gameObject);
    //    }
    //    else
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}
}
