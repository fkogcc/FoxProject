using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearRotation : MonoBehaviour
{
    // オブジェクトのRigidbodyを取得.
    private Rigidbody _rigidbody;
    // 回転度合.
    private Vector3 _rotaDegrees;
    // 回転.
    private Quaternion _rotation;
    // 一回転したかのフラグ(クリアした判定にも使用).
    private bool _playerRotation;
    // プレイヤーが範囲内にいるかどうかのフラグ.
    private bool _colRange;
    // 今の回転率.
    private int _nowAngel;
    // 前フレームの回転率.
    private int _prevAngle;
    // 回転率.
    private int _angle;
    // 一回転したら時間を計測するためのタイマー.
    private int _coutnTime;
    // タイマーが指定した時間に達したかのフラグ.
    private bool _isTimeFlag;


    // てすと
    // 回転中しているかどうか
    public bool IsRotating { get; private set; }

    // 角速度[deg/s]
    public float AngularVelocity { get; private set; }

    // 回転軸
    public Vector3 Axis { get; private set; }

    // 前フレームの姿勢
    private Quaternion _prevRotation;

    // インスタンスの作成.
    void Start()
    {
        // 初期化.
        _rotaDegrees += new Vector3(0.0f, -1.0f, 0.0f);
        _rotation = Quaternion.AngleAxis(0.0f, _rotaDegrees);
        _playerRotation = false;
        _colRange = false;
        _rigidbody = GetComponent<Rigidbody>();
        _nowAngel = (int)this.transform.localEulerAngles.y % 360;
        _prevAngle = (int)this.transform.localEulerAngles.y % 360;
        _angle = 360;
        _coutnTime = 60 * 2;


        // てすと
        _prevRotation = transform.rotation;

    }

    // 60フレームに一回の更新処理.
    void FixedUpdate()
    {
        // プレイヤーが持ち手を持って一回転したら.
        if (_playerRotation)
        {
            _coutnTime--;
            // 回転度合をかけて足す(ずっと回転させる).
            this.transform.rotation = _rotation * this.transform.rotation;
            if(_coutnTime < 0)
            {
                _isTimeFlag = true;
            }
        }

    }

    // 更新処理.
    void Update()
    {
        // 判定内にいたら.
        if (_colRange)
        {
            // 回転を調べる処理.
            CheckRotation();
        }

        //TestRota();
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
            _rigidbody.freezeRotation = true;
        }
    }

    //private void TestRota()
    //{
    //    // 現在フレームの姿勢を取得
    //    var rotation = transform.rotation;

    //    // 前フレームからの回転量を求める
    //    var diffRotation = Quaternion.Inverse(_prevRotation) * rotation;
    //    // 回転した角度と軸（ローカル空間）を求める
    //    diffRotation.ToAngleAxis(out var angle, out var axis);

    //    // 回転角度が0以外なら回転しているとみなす
    //    IsRotating = !Mathf.Approximately(angle, 0);

    //    // 回転角度から角速度を計算
    //    AngularVelocity = angle / Time.deltaTime;
    //    // ローカル空間の回転軸をワールド空間に変換
    //    Axis = rotation * axis;

    //    //Debug.Log(_prevRotation);
    //    // 前フレームの姿勢を更新
    //    _prevRotation = rotation;

    //    //// 回転中かどうか
    //    //if (IsRotating)
    //    //{
    //    //    // 回転している場合は、角速度と回転軸を出力
    //    //    print($"角速度 = {AngularVelocity}, 回転軸 = {Axis}");
    //    //}
    //    //else
    //    //{
    //    //    // 回転していない場合
    //    //    print("回転していない");
    //    //}
    //}
    // 回転を調べる処理.
    private void CheckRotation()
    {
        // 一回転していなかったら.
        if (!_playerRotation)
        {
            GearRotaRete();

            // ボタンを押したら回転できるようにする.
            if (Input.GetKeyDown("joystick button 1"))
            {
                _rigidbody.constraints = RigidbodyConstraints.FreezePosition
                 | RigidbodyConstraints.FreezeRotationX
                 | RigidbodyConstraints.FreezeRotationZ;
            }
            // 一回転したら.
            if (_angle < 0.0f)
            {
                _playerRotation = true;
                // RigidbodyのRotationを固定させる.
                _rigidbody.freezeRotation = true;
                // 回転速度を固定させる.
                _rotation = Quaternion.AngleAxis(1.5f, _rotaDegrees);
            }
        }
    }
    // ギミックの回転率を調べる処理
    private void GearRotaRete()
    {
        // 回転させる計算.
        // 前のフレームの回転率.
        _prevAngle = _nowAngel;
        // 現在の回転率.
        _nowAngel = (int)this.transform.localEulerAngles.y % 360;

        //Debug.Log(_nowAngel);
        //Debug.Log(_nowAngel - _prevAngle);

        // 現在のフレームより前のフレームが小さければ
        // 指定した方向と逆回転しているので処理をしない.
        if (_nowAngel >_prevAngle || _nowAngel - _prevAngle > 0 || _nowAngel - _prevAngle < -10)
        {
            return;
        }
        // 現在のフレームより前のフレームがおおきければ
        // 指定した方向の回転しているので処理をする.
        else if (_nowAngel < _prevAngle )
        {
            if (_prevAngle != _nowAngel)
            {
                // 現在の回転率と前フレームの回転率を減算して.
                // 差をアングルに入れる.
                _angle += _nowAngel - _prevAngle;
            }
        }
    }
    // シーン移行するための関数.
    public bool GetResult()
    {
        return _isTimeFlag;
    }
}
