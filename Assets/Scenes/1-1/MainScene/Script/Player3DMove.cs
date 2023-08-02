using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player3DMove : MonoBehaviour
{
    CharacterController _playerController;
    GameObject _camera;

    private Rigidbody _Rigid;// �v���C���[�̃��W�b�g�{�f�B
    float _speed = 1.0f;// �ړ��X�s�[�h
    float _jumpPower = 8.0f;// �W�����v��
    float gravity = 10.0f;// �d��

    Vector3 _moveDirection = Vector3.zero;
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {

        // �}�E�X�J�[�\�����\���ɂ��A�ʒu���Œ�
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        _playerController = GetComponent<CharacterController>();
        _camera = GameObject.Find("Camera");
        //_camera = GameObject.Find("testCamera");
        _Rigid = GetComponent<Rigidbody>();

        startPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        // �J�����̌�������ɂ������ʕ����̃x�N�g��
        Vector3 cameraForward = Vector3.Scale(_camera.transform.forward, new Vector3(1.0f, 0.0f, 1.0f)).normalized;

        // (�J�����)
        Vector3 moveZ = cameraForward * Input.GetAxis("Vertical") * _speed;// �O��
        Vector3 moveX = _camera.transform.right * Input.GetAxis("Horizontal") * _speed;// ���E

        Debug.Log(_playerController.isGrounded);
        if (_playerController.isGrounded)
        {
            // A�{�^����������W�����v
            //if (Input.GetKeyDown("joystick button 0"))
            //{
            //    Jump();
            //}
            _moveDirection = moveZ + moveX;
            if (Input.GetKeyDown("joystick button 0"))
            {
                _moveDirection.y = _jumpPower;
            }
            
        }
        else
        {
            _moveDirection = moveZ + moveX + new Vector3(0.0f, _moveDirection.y, 0.0f);
            _moveDirection.y -= gravity * Time.deltaTime;
        }

        // �v���C���[�̌�������͂̌����ɕύX
        transform.LookAt(transform.position + moveZ + moveX);

        // Move�͎w�肵���x�N�g�������ړ������閽��
        _playerController.Move(_moveDirection * Time.deltaTime);
    }

    // �W�����v����
    void Jump()
    {
        _Rigid.AddForce(transform.up * _jumpPower, ForceMode.Impulse);
    }
}
