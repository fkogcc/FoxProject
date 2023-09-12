using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPull : MonoBehaviour
{
    // �v���C���[�̈ʒu���
    Transform _player;

    // ��������n�߂��ʒu
    Vector3 _startPos;
    // ������������n�߂��ʒu���猻�݂܂ł̋���
    Vector3 _delPos;

    // ���������͈͂ɂ��邩�̔���
    bool _isPullRange;

    // ���������Ă��邩
    bool _isPull;

    void Start()
    {
        _player = GameObject.Find("3DPlayer").GetComponent<Transform>();

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
            _startPos = this._player.position;

            _isPull = true;
        }

        if ((Input.GetKeyDown("joystick button 1") || Input.GetKeyUp(KeyCode.F)))
        {
            Debug.Log("��������I���");

            _isPull = false;

            // �����ŗ��������F�������Ȃ�ł�������������
            // ���݂͌��̈ʒu�ɖ߂邾���Ƃ���
            this.transform.localScale = Vector3.one;
        }
    }

    void FixedUpdate()
    {
        if (_isPull)
        {
            _delPos = _startPos - this._player.position;

            // �c�A���s���̑傫�����Œ�
            _delPos.y = 1f;
            _delPos.z = 1f;

            // �E�ɍs���Ȃ��ƒ����Ȃ�Ȃ��悤�ɂ���
            if (-1f < _delPos.x)
            {
                _delPos.x = 1;
            }

            this.transform.localScale = _delPos;
            Debug.Log("[PullBox]" + this.transform.localScale);
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
