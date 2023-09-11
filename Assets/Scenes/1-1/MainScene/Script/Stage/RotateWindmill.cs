using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWindmill : MonoBehaviour
{
    // �ō���]���x.
    [SerializeField] private float _rotateMaxSpeed = 5.0f;
    // �Œ��]���x.
    [SerializeField] private float _rotateMinSpeed = 0.5f;
    // ��]���x.
    [SerializeField] private float _rotateSpeed = 0.5f;
    // ��]�����x.
    [SerializeField] private float _rotateAcceleration = 0.1f;
    // �M�~�b�N�����������ǂ���.
    [SerializeField] private bool _solveGimmick = false;
    // ��]���x�������邩�ǂ���.
    private bool _countDownRotateSpeed = false;
    private void FixedUpdate()
    {
        // ��].
        transform.Rotate(_rotateSpeed, 0.0f, 0.0f);

        // �M�~�b�N�������Ă��Ȃ������珈����ʂ��Ȃ�.
        if (!_solveGimmick) return;
        SolveGimmickAfter();
    }

    /// <summary>
    /// �M�~�b�N����������̏���
    /// </summary>
    private void SolveGimmickAfter()
    {
        // �X�s�[�h���������Ă��Ȃ����ǂ���
        if(!_countDownRotateSpeed)
        {
            _rotateSpeed += _rotateAcceleration;
        }
        else if(_countDownRotateSpeed)
        {
            _rotateSpeed -= _rotateAcceleration;
            
        }
        
        // �ō���]���x�ɓ��B�������]���x�𗎂Ƃ�
        if (_rotateSpeed >= _rotateMaxSpeed)
        {
            _rotateSpeed = _rotateMaxSpeed;
            _countDownRotateSpeed = true;
        }

        // �Œ��]���x�ɌŒ�
        if(_rotateSpeed <= _rotateMinSpeed)
        {
            _rotateSpeed = _rotateMinSpeed;
        }

    }
}
