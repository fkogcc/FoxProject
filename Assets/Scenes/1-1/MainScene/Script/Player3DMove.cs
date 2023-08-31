using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player3DMove : MonoBehaviour
{
    CharacterController _playerController;
    GameObject _camera;
    private Animator _animator;

    private Rigidbody _Rigid;// �v���C���[�̃��W�b�g�{�f�B
    public static float _speed = 5.0f;// �ړ��X�s�[�h
    [SerializeField] private float _jumpPower = 8.0f;// �W�����v��
    [SerializeField] private float _gravity = 10.0f;// �d��
    private float _Ver;
    private float _Hor;
    private int _motionNum;// ���[�V�����ԍ�.

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
        _Rigid = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _motionNum = 0;
        startPos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetInteger("MotionNum", _motionNum);

        _Ver = Input.GetAxis("Vertical");
        _Hor = Input.GetAxis("Horizontal");

        // �J�����̌�������ɂ������ʕ����̃x�N�g��
        Vector3 cameraForward = Vector3.Scale(_camera.transform.forward, new Vector3(1.0f, 0.0f, 1.0f)).normalized;

        // (�J�����)
        Vector3 moveZ = cameraForward * _Ver * _speed;// �O��
        Vector3 moveX = _camera.transform.right * _Hor * _speed;// ���E

        if(_Ver != 0 || _Hor != 0)
        {
            _motionNum = 1;
        }
        else
        {
            _motionNum = 0;
        }

        Debug.Log(RaycastCheck._instance._isGround);

        if (RaycastCheck._instance.CheckGrounded())
        {
            
            _moveDirection = moveZ + moveX;
            if (Input.GetKeyDown("joystick button 0"))
            {
                _moveDirection.y = _jumpPower;
            }
        }
        else
        {
            //_motionNum = 2;
            _moveDirection = moveZ + moveX + new Vector3(0.0f, _moveDirection.y, 0.0f);
            _moveDirection.y -= _gravity * Time.deltaTime;
        }

        if(!RaycastCheck._instance._isGround)
        {
            _motionNum = 2;
        }

        // �v���C���[�̌�������͂̌����ɕύX
        transform.LookAt(transform.position + moveZ + moveX);

        // Move�͎w�肵���x�N�g�������ړ������閽��
        _playerController.Move(_moveDirection * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if(this.transform.position.y <= -5.0f)
        {
            this.transform.position = new Vector3(0.0f, 1.0f, 0.0f);
        }
    }
}
