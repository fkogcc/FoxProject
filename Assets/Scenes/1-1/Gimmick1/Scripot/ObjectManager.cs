using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    GameObject _handle1;
    GameObject _playerColl;
    public string _name;
    // �ǂɃZ�b�g�ł��邩�ǂ���
    private bool _isWallNowSet;
    // �ǂɃZ�b�g�ł������ǂ���
    private bool _isWallSet;
    // �ǂɃZ�b�g������ǂ����邩
    private bool _isWallSetRota;
    // Start is called before the first frame update
    void Start()
    {
        _handle1 = GameObject.Find(_name);
        _playerColl = GameObject.Find("fox");
        _isWallSet = false;
        _isWallSetRota = false;
        _isWallNowSet = false;
    }

    // Update is called once per frame
    void Update()
    {
        // �n���h�����������񂾂��ǂ���
        if(!_isWallSetRota)
        {
            // �n���h���̋߂��ɂ��邩�ǂ���
            bool isHit = _playerColl.GetComponent<Coll>().HitHandle();
            // �n���h���������ݗp�̕ǋ߂��ɂ��邩�ǂ���
            bool isHitWall = _playerColl.GetComponent<Coll>().HitHandleWall();

            // �n���h���̋߂��ɂ��邩�ǂ���
            // ���Ȃ��������]���Ȃ�
            if (isHit && !isHitWall)
            {
                // �{�^�������������]
                // �n���h���̉�]��L��������
                if (Input.GetKeyDown("joystick button 1"))
                {
                    _handle1.GetComponent<Rota>().enabled = true;
                    _handle1.GetComponent<HandlePos>().HandlePosIsPlayer();
                    _isWallNowSet = true;
                }
            }
            else
            {
                _handle1.GetComponent<Rota>().enabled = false;
            }

            // ��]������������ǂ���
            // �I�������v���C���[�̈ʒu�Ƀn���h�����ړ�
            bool isRotaEnd = _handle1.GetComponent<Rota>().RotaEnd();
            if (_isWallNowSet)
            {
                _handle1.GetComponent<Rota>().enabled = false;
                _handle1.GetComponent<HandlePos>().HandlePosIsPlayer();
                isHit = true;
            }

            // �n���h���������Ă��ăn���h���������݌��ɂ�����
            // �������߂�
            if (isHitWall && isHit)
            {
                if (Input.GetKeyDown("joystick button 1"))
                {
                    _isWallSet = true;
                    Debug.Log("�������݂܂�");
                    _handle1.GetComponent<HandlePos>().HandlePosIsHandleWall();
                    _handle1.GetComponent<Rota>().RotaReset();
                    _isWallSetRota = true;
                    _isWallNowSet = false;
                }
            }
        }
        else
        {
            // �n���h���������ݗp�̕ǋ߂��ɂ��邩�ǂ���
            bool isHitWall = _playerColl.GetComponent<Coll>().HitHandleWall();
            if(isHitWall)
            {
                // ��]������
                if (Input.GetKeyDown("joystick button 1"))
                {
                    _handle1.GetComponent<Rota>().enabled = true;
                }
            }
            else
            {
                _handle1.GetComponent<Rota>().enabled = false;
            }
            // ��]������������ǂ���
            bool isRotaEnd = _handle1.GetComponent<Rota>().RotaEnd();
            if(isRotaEnd)
            {
                Debug.Log("�����܂��� �����l�ł�");
                _handle1.GetComponent<Rota>().enabled = false;
            }
        }
    }
}
