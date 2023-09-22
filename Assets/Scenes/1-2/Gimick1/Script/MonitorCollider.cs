using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorCollider : MonoBehaviour
{
    // �v���C���[���͈͓��ɂ��邩�ǂ���.
    private bool _isPlayerCollider;
    // �{�^���������ꂽ���ǂ���.
    public bool _isPushButton;

    // �{�^���̏�Ԃ�n�����߂ɃI�u�W�F�N�g���擾.
    private GameObject _gameObject;
    // script���擾.
    MonitorCamera _monitor;

    // Start is called before the first frame update
    void Start()
    {
        // ����������.
        _isPlayerCollider = false;
        _isPushButton = false;

        // �I�u�W�F�N�g���擾.
        _gameObject = GameObject.Find("GameManager");
        // �I�u�W�F�N�g�̒��ɂ���script���擾.
        _monitor = _gameObject.GetComponent<MonitorCamera>();

    }

    // Update is called once per frame
    void Update()
    {
        // �v���C���[��������ɂ���Ƃ�.
        if (_isPlayerCollider)
        {
            // A�{�^������������
            if (Input.GetKeyDown("joystick button 1"))
            {
                // �{�^���̃t���O���I���ɂ���(�J����ON).
                _isPushButton = true;
            }
            // X�{�^������������
            else if (Input.GetKeyDown("joystick button 3"))
            {
                // �{�^���̃t���O���I�t�ɂ���(�J����OFF).
                _isPushButton = false;
            }
        }
        // �{�^�������������̃t���O��n��.
        _monitor._isPushFlag = _isPushButton;
    }

    void FixedUpdate()
    {

    }

    // �����蔻��̏���
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // �v���C���[���R���C�_�[�ɓ������Ƃ�.
            _isPlayerCollider = true;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            // �v���C���[���R���C�_�[����o���Ƃ�.
            _isPlayerCollider = false;
        }
    }
}
