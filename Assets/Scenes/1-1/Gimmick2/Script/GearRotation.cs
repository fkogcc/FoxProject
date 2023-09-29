using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearRotation : MonoBehaviour
{
    // オブジェクトのRigidbodyを取得.
    Rigidbody _rb;
    // 回転度合.
    private Vector3 _rotaDegrees;
    // 回転.
    private Quaternion _rotation;
    // 一回転したかのフラグ
    private bool _playerRotation;
    // プレイヤーが範囲内にいるかどうかのフラグ.
    private bool _colRange;
    // 回転率.
    private float _gearDegree;
    // 回転した回数
    private int _count;

    // インスタンスの作成.
    void Start()
    {
        // 初期化.
        _rotaDegrees += new Vector3(0.0f, -1.0f, 0.0f);
        _rotation = Quaternion.AngleAxis(0.0f, _rotaDegrees);
        _playerRotation = false;
        _colRange = false; 
         _rb = GetComponent<Rigidbody>();
        _gearDegree = 0.0f;
    }

    // 60フレームに一回の更新処理.
    void FixedUpdate()
    {
        // プレイヤーが持ち手を持って一回転したら
        if (_playerRotation)
        {
            // 回転度合をかけて足す(ずっと回転させる).
            this.transform.rotation = _rotation * this.transform.rotation;
        }
    }

    // 更新処理.
    void Update()
    {
        // 判定内にいたら.
        if (_colRange)
        { // 一回転していなかったら.
            if (!_playerRotation)
            {
                // 回転させる計算.
                _gearDegree = this.transform.localEulerAngles.y % 360;
                _gearDegree = _gearDegree - 359.0f;
                // ボタンを押したら回転できるようにする.
                if (Input.GetKeyDown("joystick button 1"))
                {
                    _rb.constraints = RigidbodyConstraints.FreezePosition
                     | RigidbodyConstraints.FreezeRotationX
                     | RigidbodyConstraints.FreezeRotationZ;
                }
                // 一回転したら.
                if (_gearDegree >= 0.0f)
                {
                    _playerRotation = true;
                    // RigidbodyのRotationを固定させる.
                    _rb.freezeRotation = true;
                    // 回転速度を固定させる.
                    _rotation = Quaternion.AngleAxis(1.5f, _rotaDegrees);
                }
            }

        }
    }
    // プレイヤーがコライダー内にいるとき.
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _colRange = true;
        }
    }
    // プレイヤーがコライダー外に出たとき.
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _colRange = false;
            _rb.freezeRotation = true;
        }
    }
}
