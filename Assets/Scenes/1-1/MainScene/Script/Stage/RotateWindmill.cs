using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWindmill : MonoBehaviour
{
    // 最高回転速度.
    [SerializeField] private float _rotateMaxSpeed = 5.0f;
    // 最低回転速度.
    [SerializeField] private float _rotateMinSpeed = 0.5f;
    // 回転速度.
    [SerializeField] private float _rotateSpeed = 0.5f;
    // 回転加速度.
    [SerializeField] private float _rotateAcceleration = 0.1f;
    // ギミックを解いたかどうか.
    [SerializeField] private bool _solveGimmick = false;
    // 回転速度が下がるかどうか.
    private bool _countDownRotateSpeed = false;
    private void FixedUpdate()
    {
        // 回転.
        transform.Rotate(_rotateSpeed, 0.0f, 0.0f);

        // ギミックを解いていなかったら処理を通さない.
        if (!_solveGimmick) return;
        SolveGimmickAfter();
    }

    /// <summary>
    /// ギミックを解いた後の処理
    /// </summary>
    private void SolveGimmickAfter()
    {
        // スピードが下がっていないかどうか
        if(!_countDownRotateSpeed)
        {
            _rotateSpeed += _rotateAcceleration;
        }
        else if(_countDownRotateSpeed)
        {
            _rotateSpeed -= _rotateAcceleration;
            
        }
        
        // 最高回転速度に到達したら回転速度を落とす
        if (_rotateSpeed >= _rotateMaxSpeed)
        {
            _rotateSpeed = _rotateMaxSpeed;
            _countDownRotateSpeed = true;
        }

        // 最低回転速度に固定
        if(_rotateSpeed <= _rotateMinSpeed)
        {
            _rotateSpeed = _rotateMinSpeed;
        }

    }
}
