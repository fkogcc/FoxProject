// 風車ギミックの処理.
// HACK:マジックナンバー過多.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWindmill : MonoBehaviour
{
    // インスタンス.
    public static RotateWindmill _instance;

    private SolveGimmickManager _gimmickManager;

    //private GimmickManager1_1 _manager;

    // 風の力を発生させる判定.
    [SerializeField] private GameObject _windSpace;
    // 最高回転速度.
    [SerializeField] private float _rotateMaxSpeed = 30.0f;
    // 最低回転速度.
    [SerializeField] private float _rotateMinSpeed = 0.5f;
    // 回転速度.
    [SerializeField] private float _rotateSpeed = 0.5f;
    // 回転加速度.
    [SerializeField] private float _rotateAcceleration = 0.1f;

    // 風の判定が生きているかどうか.
    private bool _isWindActive = false;

    // ギミックを解いたかどうか.
    //[SerializeField] private bool _isSolveGimmick = false;
    // 回転速度が下がるかどうか.
    private bool _isCountDownRotateSpeed = false;

    // ギミックが作動中かどうか
    private bool _isOperationGimmick;

    private void Awake()
    {
        if( _instance == null )
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _gimmickManager = GameObject.FindWithTag("GimmickManager").GetComponent<SolveGimmickManager>();
    }

    private void FixedUpdate()
    {
        if (_gimmickManager._solve[1])
        {
            UpdateRotateWindmill();
        }
    }

    private void UpdateRotateWindmill()
    {
        transform.Rotate(_rotateSpeed, 0.0f, 0.0f);

        _windSpace.SetActive(_isWindActive);

        // 風を発生させるタイミング.
        if (_rotateSpeed > 25.0f)
        {
            _isWindActive = true;
        }
        else if (_rotateSpeed < 20.0f)
        {
            _isWindActive = false;
        }

        // ギミックを解いていなかったら処理を通さない.
        SolveGimmickAfter(_isOperationGimmick);
    }

    // ギミックを解いた後の処理.
    private void SolveGimmickAfter(bool solveGimmick)
    {
        // スピードが下がっていないかどうか.
        if(!_isCountDownRotateSpeed)
        {
            _rotateSpeed += _rotateAcceleration;
        }
        else if(_isCountDownRotateSpeed)
        {
            _rotateSpeed -= _rotateAcceleration;
            
        }
        
        // 最高回転速度に到達したら回転速度を落とす.
        // 回転速度低速開始.
        if (_rotateSpeed >= _rotateMaxSpeed)
        {
            _rotateSpeed = _rotateMaxSpeed;
            _isCountDownRotateSpeed = true;
        }

        // 最低回転速度に固定.
        // 回転速度低速終了.
        if(_rotateSpeed <= _rotateMinSpeed)
        {
            _rotateSpeed = _rotateMinSpeed;
            //_manager._operationGimmick[1] = false;
            _isCountDownRotateSpeed = false;
        }
    }

    public bool GetWindActive()
    {
        return _isWindActive;
    }
}
