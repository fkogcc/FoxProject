using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handleWall : MonoBehaviour
{
    // ハンドルを差し込み用フラグ
    public bool _isHandleSet;
    
    // ハンドルオブジェクトの状態を取得
    public Coll _coll;

    void Start()
    {
        _isHandleSet = false;
    }

    // Update is called once per frame
    public void Update()
    {
        if (_isHandleSet)
        {
            Debug.Log("セットできます");
            if (Input.GetKey("s"))
            {
                Debug.Log("S押しました");
                 _coll.GetHandleFlag(true);
                 _coll._isItemGet = false;
                 _coll._isHit = false;
                _coll._isHandleWallSet = true;
            }
        }

    }

    void OnTriggerStay(Collider collision)
    {
        if(collision.tag == "handle")
        {
            Debug.Log("handle");
            _isHandleSet = true;    
        }
    }

}
