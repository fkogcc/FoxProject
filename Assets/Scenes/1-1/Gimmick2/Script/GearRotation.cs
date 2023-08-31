using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearRotation : MonoBehaviour
{
    Rigidbody rb;
    // ��]�x��.
    private Vector3 _rotaDegrees;
    // ��].
    public Quaternion _rotation;
    // TODO �v���C���[���{�^�������������̃t���O
    public bool _playerRptation;
    // TODO �v���C���[���{�^�������������̃t���O
    public bool _colRange;
    float _gearDegree;
    // �C���X�^���X�̍쐬.
    void Start()
    {
        // ������.
        _rotaDegrees += new Vector3(0.0f, 1.0f, 0.0f);
        _rotation = Quaternion.AngleAxis(0.0f, _rotaDegrees);
        _playerRptation = false;
        _colRange = false;
        rb = GetComponent<Rigidbody>();
        _gearDegree = 0.0f;

    }

    // 60�t���[���Ɉ��̍X�V����.
    void FixedUpdate()
    {
        if (_playerRptation)
        {
            // ��]�x���������đ���.
            this.transform.rotation = _rotation * this.transform.rotation;
        }
    }


    // �X�V����.
    void Update()
    {
        if (!_playerRptation)
        {
            _gearDegree = this.transform.localEulerAngles.y % 360;
            if (_gearDegree >= 355.0f)
            {
                Debug.Log("������");
            }

            if (_colRange)
            {
                Debug.Log("�{�^����������");

                if (_gearDegree >= 355.0f)
                {
                    Debug.Log("���]����");
                    _playerRptation = true;
                    rb.freezeRotation = true;

                    _rotation = Quaternion.AngleAxis(1.5f, _rotaDegrees);
                }
            }
            else
            {
                Debug.Log("�{�^���������Ȃ�");
            }

            //Debug.Log(_pushButton);

        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // �v���C���[���R���C�_�[�ɓ������Ƃ�.
            Debug.Log("�͈͓�");
            _colRange = true;
            // Inspector�^�u��onTriggerStay�Ŏw�肳�ꂽ���������s����
            //onTriggerStay.Invoke(other);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            // �v���C���[���R���C�_�[����o���Ƃ�.
            Debug.Log("�͈͊O");
            _colRange = false;
        }
    }
}
