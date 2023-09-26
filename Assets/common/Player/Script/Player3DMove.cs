using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player3DMove : MonoBehaviour
{
    // �L�����N�^�[�R���g���[���[.
    private CharacterController _playerController;
    // �J����.
    private GameObject _camera;
    // �A�j���[�^�[
    private Animator _animator;

    // float.
    // �ړ��X�s�[�h.
    [SerializeField] public static float _speed = 5.0f;
    // �W�����v��.
    [SerializeField] private float _jumpPower = 8.0f;
    // �d��.
    [SerializeField] private float _gravity = 10.0f;

    // �n�ʂɓ������Ă��邩.
    private bool _isGround = false;

    // ���n�����u��.
    private bool _isMomentLanded = false;

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

        _playerController = GetComponent<CharacterController>();
        _camera = GameObject.Find("Camera");
        _animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        // �ڒn���Ă��邩����.
        _isGround = IsGroundedCheck._instance._isGround;

        // ��������.
        float vertical = Input.GetAxis("Vertical");
        // ��������.
        float horizontal = Input.GetAxis("Horizontal");

        // �J�����̌�������ɂ������ʕ����̃x�N�g��.
        Vector3 cameraForward = Vector3.Scale(_camera.transform.forward, new Vector3(1.0f, 0.0f, 1.0f)).normalized;

        // �J�����.
        Vector3 moveZ = cameraForward * vertical * _speed;// �O��
        Vector3 moveX = _camera.transform.right * horizontal * _speed;// ���E

        _moveDirection = moveZ + moveX + new Vector3(0.0f, _moveDirection.y, 0.0f);
        if (!_isGround)
        {
            _moveDirection.y -= _gravity * Time.deltaTime;
        }
        else
        {
        }

        Jump();

        

        Debug.Log(_moveDirection.y);

        // �v���C���[�̐i�ޕ����ɉ�].
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

    // �W�����v.
    private void Jump()
    {
        // ���n���Ă���Ƃ��̏���
        if (_isGround)
        {
            // A�{�^����������W�����v.
            if (Input.GetKeyDown("joystick button 0"))
            {
                _isMomentLanded = false;
                _moveDirection.y = _jumpPower;
            }
        }
    }

    // �������x������
    private void InitFall()
    {
        if (!_isMomentLanded) return;
        _moveDirection.y = 0.0f;
        _isMomentLanded=true;
    }
}
