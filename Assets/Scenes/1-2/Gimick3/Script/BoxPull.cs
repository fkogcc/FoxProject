using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPull : MonoBehaviour
{
    const int kNum = 16;

    // �v���C���[�̈ʒu���
    Transform _player;

    // �M�~�b�N�I�u�W�F
    GameObject _gimmick;
    GameObject[] _gimmicks = new GameObject[kNum];


    // ���������͈͂ɂ��邩��
    bool _isPullRange;

    // ���������Ă��邩
    bool _isPull;


    // ��������n�߂��ʒu
    Vector3 _startPos;

    // �ړ��x�N�g��
    Vector3 _moveVec;

    void Start()
    {
        _player = GameObject.Find("3DPlayer").GetComponent<Transform>();

        _gimmick = (GameObject)Resources.Load("Cube");

        for (int i = 0; i < kNum; i++)
        {
            _gimmicks[i] = Instantiate(_gimmick, this.transform.position, Quaternion.identity);
        }

        _isPullRange = false;
        _isPull = false;

        _startPos = new Vector3();
        _moveVec = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown("joystick button 1") || Input.GetKeyDown(KeyCode.F)) && _isPullRange)
        {
            Debug.Log("��������n�߂�");

            // ��������n�߂��ʒu�̕ۑ�
            _startPos = _player.position;

            _isPull = true;
        }

        if ((Input.GetKeyDown("joystick button 1") || Input.GetKeyUp(KeyCode.F)))
        {
            Debug.Log("��������I���");

            // ���̈ʒu�ɖ߂�
            for (int i = 0; i < kNum; i++)
            {
                _gimmicks[i].transform.position = this.transform.position;
            }

            _isPull = false;
        }
    }

    void FixedUpdate()
    {
        if (_isPull)
        {
            // ���݂܂ł̃x�N�g�����v�Z
            _moveVec = _player.position - _startPos;

            // �o���I�u�W�F�N�g�̗ʂŊ���
            _moveVec /= kNum;

            // ���������炵�Ĉʒu��u��
            for (int i = 0; i < kNum; i++)
            {
                _gimmicks[i].transform.position = this.transform.position + _moveVec * i;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // �͈͓��ɓ������ꍇ���������悤�ɂ���
        Debug.Log("���������");
        _isPullRange = true;
    }

    void OnTriggerExit(Collider other)
    {
        // �͈͊O�ɏo�����������Ȃ��悤�ɂ���
        Debug.Log("��������Ȃ�");
        _isPullRange = false;
    }
}
