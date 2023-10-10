// 風車ギミックの処理.
// HACK:マジックナンバー過多.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWindmill : MonoBehaviour
{
    // インスタンス.
    public static RotateWindmill _instance;

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
    // ギミックを解いたかどうか.
    //[SerializeField] private bool _isSolveGimmick = false;
    // 回転速度が下がるかどうか.
    private bool _isCountDownRotateSpeed = false;
    
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

    private void FixedUpdate()
    {
        //transform.Rotate(_rotateSpeed, 0.0f, 0.0f);

        //// 風を発生させるタイミング.
        //if(_rotateSpeed > 25.0f)
        //{
        //    _windSpace.SetActive(true);
        //}
        //else if(_rotateSpeed < 20.0f)
        //{
        //    _windSpace.SetActive(false);
        //}

        //// ギミックを解いていなかったら処理を通さない.
        //if (!_isSolveGimmick) return;
        //SolveGimmickAfter();
    }

    public void UpdateRotateWindmill(bool solveGimmick)
    {
        transform.Rotate(_rotateSpeed, 0.0f, 0.0f);

        // 風を発生させるタイミング.
        if (_rotateSpeed > 25.0f)
        {
            _windSpace.SetActive(true);
        }
        else if (_rotateSpeed < 20.0f)
        {
            _windSpace.SetActive(false);
        }

        // ギミックを解いていなかったら処理を通さない.
        if (!solveGimmick) return;
        SolveGimmickAfter(solveGimmick);
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
            solveGimmick = false;
            _isCountDownRotateSpeed = false;
        }
    }
}
