using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearRotation : MonoBehaviour
{
    // 回転度合.
    public Vector3 _rotaDegrees;
    // 回転.
    public Quaternion _rotation;
    // TODO プレイヤーがボタンを押したかのフラグ（テスト）
    public bool _pushButton;

    // インスタンスの作成.
    void Start()
    {
        // 初期化
        _rotaDegrees += new Vector3( 0.0f, 1.0f, 0.0f); 
        _rotation = Quaternion.AngleAxis(0.5f, _rotaDegrees);
        _pushButton = false;
    }

    // 60フレームに一回の更新処理.
    void FixedUpdate()
    {
        if (_pushButton)
        {
            // 回転度合をかけて足す
            this.transform.rotation = _rotation * this.transform.rotation;
        }
    }
    
    // 更新処理.
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("すぺーすをおした");
            _pushButton = true;
        }
        //if(this.transform.rotation.y > 0)
        //{
        //    Debug.Log("180");
        //    _pushButton = false;
        //}
    }
}
