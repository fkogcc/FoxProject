using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPull : MonoBehaviour
{
    // �v���C���[�̈ʒu���
    Transform _player;
    // �q�I�u�W�F�N�g(�M�~�b�N�̂��)
    GameObject _gimmick;

    // �����̈ʒu
    Vector3 _startPos;

    // ��������n�߂��ʒu
    Vector3 _pullPos;
    // ������������n�߂��ʒu���猻�݂܂ł̋���
    Vector3 _delPos;

    // �p�x
    float _angle;
    Vector3 _arrow;
    Vector3 _tempPos;

    // ���������͈͂ɂ��邩�̔���
    bool _isPullRange;

    // ���������Ă��邩
    bool _isPull;

    void Start()
    {
        _player = GameObject.Find("3DPlayer").GetComponent<Transform>();

        _gimmick = transform.GetChild(0).gameObject;

        _startPos = _gimmick.transform.position;

        _angle = 0f;
        _arrow = new Vector3(0.0f, 1.0f, 0.0f);
        _tempPos = new Vector3();

        _isPullRange = false;
        _isPull = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown("joystick button 1") || Input.GetKeyDown(KeyCode.F)) && _isPullRange)
        {
            Debug.Log("��������n�߂�");

            // ��������n�߂��̈ʒu��ۑ�
            _pullPos = this._player.position;

            _isPull = true;
        }

        if ((Input.GetKeyDown("joystick button 1") || Input.GetKeyUp(KeyCode.F)))
        {
            Debug.Log("��������I���");

            _isPull = false;

            // ���̈ʒu�A�p�x�A�T�C�Y�ɖ߂�
            _gimmick.transform.position = _startPos;
            _gimmick.transform.rotation = Quaternion.identity;
            _gimmick.transform.localScale = Vector3.one;
        }
    }

    void FixedUpdate()
    {
        if (_isPull)
        {
            //ChangeCenter();

            //ChangeSize();

            _tempPos = _player.position;
            _tempPos.z = _pullPos.z;

            _angle = Vector3.Angle(_tempPos, _player.position);

            if (0 < _player.position.z - _tempPos.z)
            {
                _angle *= -1;
            }

            //Debug.Log("[PullBox] pull" + _pullPos);
            //Debug.Log("[PullBox] player" + _player.position);
            Debug.Log("[PullBox] angle" + _angle);

            this.transform.rotation = Quaternion.AngleAxis(_angle, _arrow);
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

    /// �@���S��ύX����֐�(�����������)
    void ChangeCenter()
    {
        // ���߂̈ʒu��ۑ�
        _delPos = _startPos;
        // �ړ����Ă���ꍇ���S���E�Ɉړ�������
        _delPos.x = _delPos.x - (_pullPos.x - _player.position.x) / 2.0f;

        // ���S���ړ���������������
        _gimmick.transform.position = _delPos;
    }

    // �T�C�Y��ύX����֐�(�������������)
    void ChangeSize()
    {
        // �����n�߂��ʒu���猻�݂�X���W�̋������m�F
        _delPos.x = _pullPos.x - this._player.position.x;

        // �E�ɍs���Ȃ��ƒ����Ȃ�Ȃ��悤�ɂ���
        if (-1f < _delPos.x)
        {
            _delPos.x = 1;
        }

        // �c�A���s���̑傫�����Œ�
        _delPos.y = 1f;
        _delPos.z = 1f;

        // �T�C�Y�̕ύX
        _gimmick.transform.localScale = _delPos;
    }
}
