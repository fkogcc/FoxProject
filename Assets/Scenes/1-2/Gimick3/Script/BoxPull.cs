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
        if (Input.GetKeyDown("joystick button 1") && _isPullRange)
        {
            Debug.Log("��������n�߂�");
            // ��������n�߂����̈ʒu��ۑ�
            _startPos = this._player.position;

            _isPull = true;
        }

        if (Input.GetKeyUp("joystick button 1"))
        {
            Debug.Log("��������I���");

            _isPull = false;

            // �����ŗ��������F�������Ȃ�ł�������������
            // ���݂͌��̈ʒu�ɖ߂邾���Ƃ���
            this.transform.position = _startPos;
        }
    }

    void FixedUpdate()
    {
        if (_isPull)
        {
            _delPos = this._player.position;
            _delPos.x -= 10f;

            this.transform.position = _delPos;
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
