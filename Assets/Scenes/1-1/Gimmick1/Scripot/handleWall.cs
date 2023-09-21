using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handleWall : MonoBehaviour
{
    // ハンドルを差し込み用フラグ
    public bool _isHandleSet;
    
    // ハンドルオブジェクトの状態を取得
    public Coll _coll;

    // 多分初期化
    void Start()
    {
        _isHandleSet = false;
    }

    // Update is called once per frame
    public void Update()
    {
        // 多分bool型
        if (_isHandleSet)
        {
            // なにこれ
            Debug.Log("セットできます");
            // あってるとおもう
            if (Input.GetKey("s"))
            {
                // うごけ
                Debug.Log("S押しました");

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
