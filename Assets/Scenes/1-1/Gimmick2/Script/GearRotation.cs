using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearRotation : MonoBehaviour
{
    Rigidbody rb;
    // 回転度合.
    public Vector3 _rotaDegrees;
    // 回転.
    public Quaternion _rotation;
    // TODO プレイヤーがボタンを押したかのフラグ
    public bool _pushButton;
    // TODO プレイヤーがボタンを押したかのフラグ
    public bool _colRange;

    // インスタンスの作成.
    void Start()
    {
        // 初期化
        _rotaDegrees += new Vector3( 0.0f, 1.0f, 0.0f); 
        _rotation = Quaternion.AngleAxis(0.5f, _rotaDegrees);
        _pushButton = false;
        _colRange = false;
        rb = GetComponent<Rigidbody>();
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
        if (_colRange)
        {
            Debug.Log("ボタンをおせる");
            if (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey(KeyCode.LeftShift))
            {
                Debug.Log("ボタンをおした");
                _pushButton = true;
                rb.freezeRotation = _pushButton;
            }
        }
        else
        {
            Debug.Log("ボタンをおせない");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // プレイヤーがEmptyのコライダーに入ったとき
            Debug.Log("範囲内");
            _colRange = true;
            // InspectorタブのonTriggerStayで指定された処理を実行する
            //onTriggerStay.Invoke(other);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            // プレイヤーがEmptyのコライダーから出たとき
            Debug.Log("範囲外");
            _colRange = false;
        }
    }
}
