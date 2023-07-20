using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearRotation : MonoBehaviour
{
    Rigidbody rb;
    // ��]�x��.
    public Vector3 _rotaDegrees;
    // ��].
    public Quaternion _rotation;
    // TODO �v���C���[���{�^�������������̃t���O
    public bool _pushButton;
    // TODO �v���C���[���{�^�������������̃t���O
    public bool _colRange;

    // �C���X�^���X�̍쐬.
    void Start()
    {
        // ������
        _rotaDegrees += new Vector3( 0.0f, 1.0f, 0.0f); 
        _rotation = Quaternion.AngleAxis(0.5f, _rotaDegrees);
        _pushButton = false;
        _colRange = false;
        rb = GetComponent<Rigidbody>();
    }

    // 60�t���[���Ɉ��̍X�V����.
    void FixedUpdate()
    {
        if (_pushButton)
        {
            // ��]�x���������đ���
            this.transform.rotation = _rotation * this.transform.rotation;
            
        }
    }

    // �X�V����.
    void Update()
    {
        if (_colRange)
        {
            Debug.Log("�{�^����������");
            if (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey(KeyCode.LeftShift))
            {
                Debug.Log("�{�^����������");
                _pushButton = true;
                rb.freezeRotation = _pushButton;
            }
        }
        else
        {
            Debug.Log("�{�^���������Ȃ�");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // �v���C���[��Empty�̃R���C�_�[�ɓ������Ƃ�
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
            // �v���C���[��Empty�̃R���C�_�[����o���Ƃ�
            Debug.Log("�͈͊O");
            _colRange = false;
        }
    }
}
