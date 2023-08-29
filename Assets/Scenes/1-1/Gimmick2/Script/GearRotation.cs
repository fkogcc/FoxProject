using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearRotation : MonoBehaviour
{
    Rigidbody _rb;
    CapsuleCollider _collider;

    // ��]�x��.
    public Vector3 _rotaDegrees;
    // ��].
    public Quaternion _rotation;
    // ���]�������̃t���O
    public bool _playerRotation;
    // �v���C���[���͈͓��ɂ��邩�ǂ����̃t���O
    public bool _colRange;
    // ��]��
    float _gearDegree;
    // �C���X�^���X�̍쐬.
    void Start()
    {
        // ������.
        _rotaDegrees += new Vector3(0.0f, 1.0f, 0.0f);
        _rotation = Quaternion.AngleAxis(0.0f, _rotaDegrees);
        _playerRotation = false;
        _colRange = false;
        _rb = GetComponent<Rigidbody>();
        _gearDegree = 0.0f;
        _collider = GetComponent<CapsuleCollider>();
    }

    // 60�t���[���Ɉ��̍X�V����.
    void FixedUpdate()
    {
        if (_playerRotation)
        {
            // ��]�x���������đ���.
            this.transform.rotation = _rotation * this.transform.rotation;
        }
    }


    // �X�V����.
    void Update()
    {
        if (!_playerRotation)
        {
            _gearDegree = this.transform.localEulerAngles.y % 360;
            //Debug.Log(_gearDegree);
            if (_gearDegree >= 355.0f)
            {
                Debug.Log("������");
            }


            if (_colRange)
            {
                Debug.Log("�{�^����������");
                if (Input.GetKeyDown("joystick button 1"))
                {
                    Debug.Log("�{�^����������");
                    //this._collider.isTrigger = false;
                }

                if (_gearDegree >= 355.0f)
                {
                    Debug.Log("���]����");
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
