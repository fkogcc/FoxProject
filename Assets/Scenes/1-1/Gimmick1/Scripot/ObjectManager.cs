using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    GameObject _handle;
    GameObject _playerColl;
    public string _name;
    // �ǂɃZ�b�g�ł��邩�ǂ���
    private bool _isWallNowSet;
    // �ǂɃZ�b�g������ǂ����邩
    private bool _isWallSetRota;

    // �n���h���i���o�[
    public int _handleNo;
    // Start is called before the first frame update
    void Start()
    {
        _handle = GameObject.Find(_name);
        _playerColl = GameObject.Find("fox");
        _isWallSetRota = false;
        _isWallNowSet = false;
    }

    // Update is called once per frame
    void Update()
    {
        // �n���h�����������񂾂��ǂ���
        if(!_isWallSetRota)
        {
            bool isHit = false;
            bool isHitWall = false;
            if (_handleNo == 1)
            {
                // �n���h���̋߂��ɂ��邩�ǂ���
                isHit = _playerColl.GetComponent<Coll>().HitHandle();
                // �n���h���������ݗp�̕ǋ߂��ɂ��邩�ǂ���
                isHitWall = _playerColl.GetComponent<Coll>().HitHandleWall();
            }
            else if (_handleNo == 2)
            {
                // �n���h���̋߂��ɂ��邩�ǂ���
                isHit = _playerColl.GetComponent<Coll>().HitHandle2();
                //// �n���h���������ݗp�̕ǋ߂��ɂ��邩�ǂ���SSSsSssssSSS
                isHitWall = _playerColl.GetComponent<Coll>().HitHandleWall2();
            }

            // �n���h���̋߂��ɂ��邩�ǂ���
            // ���Ȃ��������]���Ȃ�
            if (isHit && !isHitWall)
            {
                // �{�^�������������]
                // �n���h���̉�]��L��������
                if (Input.GetKeyDown("a"))
                {
                    _handle.GetComponent<Rota>().enabled = true;
                    _handle.GetComponent<HandlePos>().HandlePosIsPlayer();
                    _isWallNowSet = true;
                }
            }
            else
            {
                _handle.GetComponent<Rota>().enabled = false;
            }

            // ��]������������ǂ���
            // �I�������v���C���[�̈ʒu�Ƀn���h�����ړ�
            bool isRotaEnd = _handle.GetComponent<Rota>().RotaEnd();
            if (_isWallNowSet)
            {
                _handle.GetComponent<Rota>().enabled = false;
                _handle.GetComponent<HandlePos>().HandlePosIsPlayer();
                isHit = true;
            }

            // �n���h���������Ă��ăn���h���������݌��ɂ�����
            // �������߂�
            if (isHitWall && isHit)
            {
                if (Input.GetKeyDown("a"))
                {
                    Debug.Log("�������݂܂�");
                    _handle.GetComponent<HandlePos>().HandlePosIsHandleWall();
                    _handle.GetComponent<Rota>().RotaReset();
                    _isWallSetRota = true;
                    _isWallNowSet = false;
                }
            }
        }
        else
        {
            bool isHitWall = false;
            if (_handleNo == 1)
            {
                // �n���h���������ݗp�̕ǋ߂��ɂ��邩�ǂ���
                isHitWall = _playerColl.GetComponent<Coll>().HitHandleWall();
            }
            else if(_handleNo == 2)
            {
                // �n���h���������ݗp�̕ǋ߂��ɂ��邩�ǂ���
                isHitWall = _playerColl.GetComponent<Coll>().HitHandleWall2();
            }
            if(isHitWall)
            {
                // ��]������
                if (Input.GetKeyDown("a"))
                {
                    _handle.GetComponent<Rota>().enabled = true;
                }
            }
            else
            {
                _handle.GetComponent<Rota>().enabled = false;
            }
            // ��]������������ǂ���
            bool isRotaEnd = _handle.GetComponent<Rota>().RotaEnd();
            if(isRotaEnd)
            {
                Debug.Log("�����܂��� �����l�ł�");
                _handle.GetComponent<Rota>().enabled = false;
            }
        }
    }

}
