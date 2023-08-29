using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearRotation : MonoBehaviour
{
    Rigidbody _rb;
    CapsuleCollider _collider;

    // 回転度合.
    public Vector3 _rotaDegrees;
    // 回転.
    public Quaternion _rotation;
    // 一回転したかのフラグ
    public bool _playerRotation;
    // プレイヤーが範囲内にいるかどうかのフラグ
    public bool _colRange;
    // 回転率
    float _gearDegree;
    // インスタンスの作成.
    void Start()
    {
        // 初期化.
        _rotaDegrees += new Vector3(0.0f, 1.0f, 0.0f);
        _rotation = Quaternion.AngleAxis(0.0f, _rotaDegrees);
        _playerRotation = false;
        _colRange = false;
        _rb = GetComponent<Rigidbody>();
        _gearDegree = 0.0f;
        _collider = GetComponent<CapsuleCollider>();
    }

    // 60フレームに一回の更新処理.
    void FixedUpdate()
    {
        if (_playerRotation)
        {
            // 回転度合をかけて足す.
            this.transform.rotation = _rotation * this.transform.rotation;
        }
    }


    // 更新処理.
    void Update()
    {
        if (!_playerRotation)
        {
            _gearDegree = this.transform.localEulerAngles.y % 360;
            //Debug.Log(_gearDegree);
            if (_gearDegree >= 355.0f)
            {
                Debug.Log("こえた");
            }


            if (_colRange)
            {
                Debug.Log("ボタンをおせる");
                if (Input.GetKeyDown("joystick button 1"))
                {
                    Debug.Log("ボタンをおした");
                    //this._collider.isTrigger = false;
                }

                if (_gearDegree >= 355.0f)
                {
                    Debug.Log("一回転した");
                    _playerRotation = true;
                    _rb.freezeRotation = true;

                    _rotation = Quaternion.AngleAxis(1.5f, _rotaDegrees);
                }
            }
            //Debug.Log(_pushButton);

        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // プレイヤーがコライダーに入ったとき.
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
            // プレイヤーがコライダーから出たとき.
            Debug.Log("範囲外");
            _colRange = false;
        }
    }
}
