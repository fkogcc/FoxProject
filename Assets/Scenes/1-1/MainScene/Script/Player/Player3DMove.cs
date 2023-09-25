using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player3DMove : MonoBehaviour
{
    // Component.
    // �L�����N�^�[�R���g���[���[.
    private CharacterController _playerController;
    // �J����.
    private GameObject _camera;
    // �A�j���[�^�[.
    private Animator _animator;

    // int.
    // ���[�V�����ԍ�.
    // 0.Idle.
    // 1.Run.
    // 2.Jump.
    // 3.GameOver.
    private int _motionNum;

    // float.
    // �ړ��X�s�[�h.
    [SerializeField] public static float _speed = 5.0f;
    // �W�����v��.
    [SerializeField] private float _jumpPower = 8.0f;
    // �d��.
    [SerializeField] private float _gravity = 10.0f;

    // bool
    // �n�ʂɓ������Ă��邩.
    private bool _isGround;

    // Vector3
    // ��������.
    Vector3 _moveDirection = Vector3.zero;

    enum MotionNum
    {
        Idle,
        Run,
        Jump,
        GameOver
    }


    // Start is called before the first frame update
    void Start()
    {
        // �}�E�X�J�[�\�����\���ɂ��A�ʒu���Œ�.
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        //---------------------------------------
        // �ȉ��I�u�W�F�N�g�擾.
        //---------------------------------------
        // �L�����N�^�[�R���g���[���[.
        _playerController = GetComponent<CharacterController>();
        // Camera�I�u�W�F�N�g.
        _camera = GameObject.Find("Camera");
        // �A�j���[�^�[.
        _animator = GetComponent<Animator>();
        // ���[�V�����ԍ�������.
        _motionNum = (int)MotionNum.Idle;
        _isGround = false;
    }

    // Update is called once per frame
    void Update()
    {
        // �ڒn���Ă��邩����.
        _isGround = IsGroundedCheck._instance._isGround;

        // �A�j���[�V�����ԍ�.
        _animator.SetInteger("MotionNum", _motionNum);

        // ��������.
        float vertical = Input.GetAxis("Vertical");
        // ��������.
        float horizontal = Input.GetAxis("Horizontal");

        // �J�����̌�������ɂ������ʕ����̃x�N�g��.
        Vector3 cameraForward = Vector3.Scale(_camera.transform.forward, new Vector3(1.0f, 0.0f, 1.0f)).normalized;

        // �J�����.
        Vector3 moveZ = cameraForward * vertical * _speed;// �O��
        Vector3 moveX = _camera.transform.right * horizontal * _speed;// ���E

        // ���n����.
        if (_isGround)
        {
            // A�{�^����������W�����v.
            _moveDirection = moveZ + moveX;
            if (Input.GetKeyDown("joystick button 0"))
            {
                _moveDirection.y = _jumpPower;
            }

            // �ړ����.
            if (vertical != 0 || horizontal != 0)
            {
                _motionNum = (int)MotionNum.Run;
            }
            else
            {
                _motionNum = (int)MotionNum.Idle;
            }
        }
        else
        {
            _motionNum = (int)MotionNum.Jump;
        }
        _moveDirection = moveZ + moveX + new Vector3(0.0f, _moveDirection.y, 0.0f);
        _moveDirection.y -= _gravity * Time.deltaTime;

        // �v���C���[�̌�������͂̌����ɕύX.
        transform.LookAt(transform.position + moveZ + moveX);

        // Move�͎w�肵���x�N�g�������ړ������閽��.
        _playerController.Move(_moveDirection * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        FallDebug();
    }

    // �n�ʂ��痎�����珉���ʒu�̃X�|�[��.
    private void FallDebug()
    {
        if (this.transform.position.y <= -5.0f)
        {
            this.transform.position = new Vector3(0.0f, 1.0f, 0.0f);
        }
    }
}
