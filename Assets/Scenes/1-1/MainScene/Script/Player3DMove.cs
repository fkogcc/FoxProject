using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player3DMove : MonoBehaviour
{
    private CharacterController _playerController;
    private GameObject _camera;
    private Animator _animator;

    private int _motionNum;

    public static float _speed = 5.0f;// �ړ��X�s�[�h
    float _jumpPower = 8.0f;// �W�����v��
    float _gravity = 10.0f;// �d��

    // ��������
    Vector3 _moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        // �}�E�X�J�[�\�����\���ɂ��A�ʒu���Œ�
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        _playerController = GetComponent<CharacterController>();
        _camera = GameObject.Find("Camera");
        _animator = GetComponent<Animator>();

        _motionNum = 0;

    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetInteger("MotionNum", _motionNum);

        // ��������.
        float Ver = Input.GetAxis("Vertical");
        // ��������
        float Hori = Input.GetAxis("Horizontal");

        // �J�����̌�������ɂ������ʕ����̃x�N�g��
        Vector3 cameraForward = Vector3.Scale(_camera.transform.forward, new Vector3(1.0f, 0.0f, 1.0f)).normalized;

        // (�J�����)
        Vector3 moveZ = cameraForward * Input.GetAxis("Vertical") * _speed;// �O��
        Vector3 moveX = _camera.transform.right * Input.GetAxis("Horizontal") * _speed;// ���E

        // ���n����
        if (_playerController.isGrounded)
        {
            // A�{�^����������W�����v.
            _moveDirection = moveZ + moveX;
            if (Input.GetKeyDown("joystick button 0"))
            {
                _moveDirection.y = _jumpPower;
            }
            
        }
        else
        {
            _moveDirection = moveZ + moveX + new Vector3(0.0f, _moveDirection.y, 0.0f);
            _moveDirection.y -= _gravity * Time.deltaTime;
        }

        // �v���C���[�̌�������͂̌����ɕύX
        transform.LookAt(transform.position + moveZ + moveX);

        // Move�͎w�肵���x�N�g�������ړ������閽��
        _playerController.Move(_moveDirection * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        FallDebug();
    }


    private void FallDebug()
    {
        if (this.transform.position.y <= -5.0f)
        {
            this.transform.position = new Vector3(0.0f, 1.0f, 0.0f);
        }
    }
}
