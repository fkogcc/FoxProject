using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickBirdge : MonoBehaviour
{
    // ���̒ʘH
    // ��
    [SerializeField] private GameObject _birdgeLeft;
    // �E
    [SerializeField] private GameObject _birdgeRight;
    // �M�~�b�N�����������ǂ����̃f�o�b�O�p����
    [SerializeField] private bool _isSuccessGimmick;

    // Start is called before the first frame update
    void Start()
    {
        _isSuccessGimmick = false;
    }

    // Update is called once per frame
    void Update()
    {
        // �����˂���ƈȍ~�������Ȃ�
        if (_birdgeLeft.transform.localEulerAngles == new Vector3(0.0f, 0.0f, 0.0f) ||
           _birdgeRight.transform.localEulerAngles == new Vector3(0.0f, 0.0f, 0.0f))
            return;

        // �M�~�b�N�������Ă��Ȃ��Ə������Ȃ�
        if(!_isSuccessGimmick) return;

        RotateBirdgeAisleLeft();
        RotateBirdgeAisleRight();
    }

    private void RotateBirdgeAisleLeft()
    {
        _birdgeLeft.transform.Rotate(0,0,-1);

        if(_birdgeLeft.transform.localEulerAngles  == new Vector3(0.0f,0.0f,0.0f))
        {
            _isSuccessGimmick = false;
        }
    }

    private void RotateBirdgeAisleRight()
    {
        _birdgeRight.transform.Rotate(0, 0, 1);

        if (_birdgeRight.transform.localEulerAngles == new Vector3(0.0f, 0.0f, 0.0f))
        {
            _isSuccessGimmick = false;
        }
    }
}
