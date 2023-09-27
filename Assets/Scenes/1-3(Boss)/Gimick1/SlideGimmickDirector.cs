using Microsoft.Cci;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideGimmickDirector : MonoBehaviour
{
    // �������u���b�N�̐�.
    const int kNum = 16;

    // ���݂̎�̈ʒu����̏㉺���E
    const int kUp = -4;
    const int kDown = 4;
    const int kLeft = -1;
    const int kRight = 1;

    // ���ɕ���ł���u���b�N�̐�
    const int kRaw = 4;

    // �v���C���[
    GameObject _player;

    // �M�~�b�N�e�I�u�W�F.
    GameObject _parentObj;
    // �M�~�b�N�q�I�u�W�F.
    GameObject[] _gimmickObj;

    // �v�f�̔ԍ�.
    int[] _eles;

    // ���������̃t���O
    bool _isHitKey;

    // ���݂̗v�f
    int _nowEle;

    // ����ւ��p.
    Vector3 _tempPos1;
    Vector3 _tempPos2;
    int _tempEle;

    void Start()
    {
        // ������
        _player = new GameObject();

        _parentObj = new GameObject();
        _gimmickObj = new GameObject[kNum];

        _eles = new int[kNum];

        _isHitKey = false;

        _nowEle = 0;

        _tempPos1 = new Vector3();
        _tempPos2 = new Vector3();
        _tempEle = 0;

        // �v���C���[��T��
        _player = GameObject.Find("Hand");

        // �e�I�u�W�F��T��.
        _parentObj = GameObject.Find("Box");

        for (int i = 0; i < kNum; i++)
        {
            // �q�I�u�W�F��T��.
            _gimmickObj[i] = _parentObj.transform.GetChild(i).gameObject;
            // �v�f�ԍ��̑��.
            _eles[i] = i;
        }

        // �V���b�t��
        for(int i = 0; i < 32; i++)
        {
            // todo: �����̂𕜊�
            //ChangeTrs(Random.Range(0, kNum), Random.Range(0, kNum));
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.F) && !_isHitKey)
        {
            _nowEle = _player.GetComponent<GimmickHand>().GetEleNum();

            EleCheck();

            _isHitKey = true;
        }
        else if (!Input.GetKey(KeyCode.F))
        {
            _isHitKey = false;
        }
    }

    public void EleCheck()
    {
        // �v�f�ԍ��̈ʒu���󔒒n�Ȃ牽�����Ȃ�
        if (_eles[_nowEle] == kNum - 1) return;

        // ��̃`�F�b�N
        if (DirCheck(kUp)) return;
        Debug.Log("��Ⴄ");
        // ���̃`�F�b�N
        if (DirCheck(kDown)) return;
        Debug.Log("���Ⴄ");
        // ���̃`�F�b�N
        if (DirCheck(kLeft)) return;
        Debug.Log("���Ⴄ");
        // �E�̃`�F�b�N
        if (DirCheck(kRight)) return;
    }

    bool DirCheck(int dir)
    {
        // ���E�̏ꍇ�[�ɂ���Ίm�F���Ȃ�
        if (dir == kLeft &&
            (_nowEle % kRaw) == 0)
        {
            return false;
        }
        if (dir == kLeft &&
            (_nowEle & kRaw) == (kRaw - 1))
        {
            return false;
        }

        // dir�̕����̂��̂��󔒂̏ꍇ������
        if (_eles[_nowEle + dir] == kNum - 1)
        {
            ChangeTrs(_nowEle + dir);

            return true;
        }

        return false;
    }

    /// �ʒu�̕ύX
    // �v�f��ځA�v�f���
    void ChangeTrs(int ele)
    {
        // ���ꂼ��̈ʒu��ۑ�.
        _tempPos1 = _gimmickObj[_eles[_nowEle]].transform.position;
        _tempPos2 = _gimmickObj[_eles[ele]].transform.position;

        // �ۑ������ʒu���g���A�ʒu�̓���ւ�.
        _gimmickObj[_eles[_nowEle]].transform.position = _tempPos2;
        _gimmickObj[_eles[ele]].transform.position = _tempPos1;

        // �v�f�̔ԍ���ύX.
        _tempEle = _eles[_nowEle];
        _eles[_nowEle] = _eles[ele];
        _eles[ele] = _tempEle;
        
        // �f�o�b�O�\�L�p
        Debug.Log("���݂̏��");
        for (int i = 0; i < 4; i++)
        {
            Debug.Log(_eles[i * 4] + ", " + _eles[i * 4 + 1] + ", " + _eles[i * 4 + 2] + ", " + _eles[i * 4 + 3] + ", ");
        }
    }
}
