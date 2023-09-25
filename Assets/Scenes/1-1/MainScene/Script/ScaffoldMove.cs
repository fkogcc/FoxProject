// �㉺�ɓ�������.
// TODO:����I�u�W�F�N�g���ꎞ�I�ɏ����Ă��邽�߃A�^�b�`���Ă���I�u�W�F�N�g�͂Ȃ�.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaffoldMove : MonoBehaviour
{
    // ��̍��W���E�n.
    float _top;
    // ���̍��W���E�n.
    float _bottom;
    // �����X�s�[�h�̐�Βl.
    private float _speed = 0.05f;
    // ���������̕ύX.
    private float _exchange = 0.05f;
    

    void Start()
    {
        // ������.
        _top = gameObject.transform.position.y + 3.0f;
        _bottom = gameObject.transform.position.y - 3.0f;
    }

    private void FixedUpdate()
    {
        // �I�u�W�F�N�g�m�F.
        //Debug.Log($"{name}");

        // �X�s�[�h�̕ύX.
        if (gameObject.transform.position.y > _top)
        {
            _exchange = -_speed;
        }

        if(gameObject.transform.position.y < _bottom)
        {
            _exchange = _speed;
        }

        gameObject.transform.Translate(0, _exchange, 0);
    }
}
