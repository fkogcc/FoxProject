// ���ԃM�~�b�N�̏���.
// HACK:�}�W�b�N�i���o�[�ߑ�.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWindmill : MonoBehaviour
{
    // �C���X�^���X.
    public static RotateWindmill _instance;

    // ���̗͂𔭐������锻��.
    [SerializeField] private GameObject _windSpace;
    // �ō���]���x.
    [SerializeField] private float _rotateMaxSpeed = 30.0f;
    // �Œ��]���x.
    [SerializeField] private float _rotateMinSpeed = 0.5f;
    // ��]���x.
    [SerializeField] private float _rotateSpeed = 0.5f;
    // ��]�����x.
    [SerializeField] private float _rotateAcceleration = 0.1f;
    // �M�~�b�N�����������ǂ���.
    //[SerializeField] private bool _isSolveGimmick = false;
    // ��]���x�������邩�ǂ���.
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

        //// ���𔭐�������^�C�~���O.
        //if(_rotateSpeed > 25.0f)
        //{
        //    _windSpace.SetActive(true);
        //}
        //else if(_rotateSpeed < 20.0f)
        //{
        //    _windSpace.SetActive(false);
        //}

        //// �M�~�b�N�������Ă��Ȃ������珈����ʂ��Ȃ�.
        //if (!_isSolveGimmick) return;
        //SolveGimmickAfter();
    }

    public void UpdateRotateWindmill(bool solveGimmick)
    {
        transform.Rotate(_rotateSpeed, 0.0f, 0.0f);

        // ���𔭐�������^�C�~���O.
        if (_rotateSpeed > 25.0f)
        {
            _windSpace.SetActive(true);
        }
        else if (_rotateSpeed < 20.0f)
        {
            _windSpace.SetActive(false);
        }

        // �M�~�b�N�������Ă��Ȃ������珈����ʂ��Ȃ�.
        if (!solveGimmick) return;
        SolveGimmickAfter(solveGimmick);
    }

    // �M�~�b�N����������̏���.
    private void SolveGimmickAfter(bool solveGimmick)
    {
        // �X�s�[�h���������Ă��Ȃ����ǂ���.
        if(!_isCountDownRotateSpeed)
        {
            _rotateSpeed += _rotateAcceleration;
        }
        else if(_isCountDownRotateSpeed)
        {
            _rotateSpeed -= _rotateAcceleration;
            
        }
        
        // �ō���]���x�ɓ��B�������]���x�𗎂Ƃ�.
        // ��]���x�ᑬ�J�n.
        if (_rotateSpeed >= _rotateMaxSpeed)
        {
            _rotateSpeed = _rotateMaxSpeed;
            _isCountDownRotateSpeed = true;
        }

        // �Œ��]���x�ɌŒ�.
        // ��]���x�ᑬ�I��.
        if(_rotateSpeed <= _rotateMinSpeed)
        {
            _rotateSpeed = _rotateMinSpeed;
            solveGimmick = false;
            _isCountDownRotateSpeed = false;
        }
    }
}
