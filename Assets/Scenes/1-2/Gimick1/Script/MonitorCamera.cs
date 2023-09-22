using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorCamera : MonoBehaviour
{
    // �{�^�������������̏��.
    public bool _isPushFlag;
    // �Q�[���I�u�W�F�N�g���擾����
    public GameObject _monitorCameraObject;
    public GameObject _playerObject;
    public GameObject _handObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // �{�^���̏�Ԃɂ���ĕ��򂳂���.
        if (_isPushFlag)
        {
            // ���j�^�[�O�̃J�������I���ɂ���
            _monitorCameraObject.gameObject.SetActive(true);
            // �v���C���[���\���ɂ���
            _playerObject.gameObject.SetActive(false);
            // �v���C���[�̎��\������
            _handObject.gameObject.SetActive(true);
        }
        else
        {
            // ���j�^�[�O�̃J�������I�t�ɂ���
            _monitorCameraObject.gameObject.SetActive(false);
            _playerObject.gameObject.SetActive(true);
            _handObject.gameObject.SetActive(false);
        }
    }
    void FixedUpdate()
    {

    }
}
