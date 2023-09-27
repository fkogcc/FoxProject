using Microsoft.Cci;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideGimmickDirector : MonoBehaviour
{
    // �v���C���[�̓�����
    private const float kSpeed = 0.125f;

    // �������u���b�N�̐�.
    private const int kNum = 16;

    // ���݂̎�̈ʒu����̏㉺���E
    private const int kDirUp = -4;
    private const int kDirDown = 4;
    private const int kDirLeft = -1;
    private const int kDirRight = 1;

    // ���ɕ���ł���u���b�N�̐�
    private const int kRaw = 4;

    // �v���C���[
    private GameObject _player;

    // �M�~�b�N�e�I�u�W�F.
    private GameObject _parentObj;
    // �M�~�b�N�q�I�u�W�F.
    private GameObject[] _gimmickObj;

    // �v�f�̔ԍ�.
    private int[] _eles;

    // ���݂̗v�f
    private int _nowEle;

    // ����ւ��p.
    private Vector3 _tempPos1;
    private Vector3 _tempPos2;
    private int _tempEle;

    // �N���A���Ă��邩���Ă��Ȃ���
    private bool _isCreal;

    private void Start()
    {
        // ������
        _player = new GameObject();

        _parentObj = new GameObject();
        _gimmickObj = new GameObject[kNum];

        _eles = new int[kNum];

        _nowEle = kNum - 1;

        _tempPos1 = new Vector3();
        _tempPos2 = new Vector3();
        _tempEle = 0;

        _isCreal = false;

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
            // todo: ����̃V���b�t���ł̓N���A�ł��Ȃ��ςݔz�u�ɂȂ��Ă��܂�����C������
            _nowEle = Random.Range(0, kNum);
            ChangeTrs(Random.Range(0, kNum));
        }
    }

    private void Update()
    {
        // �N���A���Ă����珈�����Ȃ�
        if (_isCreal) return;

        // �v���C���[�̈ړ�����
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _player.transform.position += new Vector3(0.0f, kSpeed, 0.0f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            _player.transform.position += new Vector3(0.0f, -kSpeed, 0.0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _player.transform.position += new Vector3(kSpeed, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _player.transform.position += new Vector3(-kSpeed, 0.0f, 0.0f);
        }

        // ����̃{�^������������M�~�b�N�̏���
        if (Input.GetKeyDown(KeyCode.F))
        {
            _nowEle = _player.GetComponent<GimmickHand>().GetEleNum();

            EleCheck();
        }
    }

    private void FixedUpdate()
    {
        // �N���A���Ă����珈�����Ȃ�
        if (_isCreal) return;

        // �v�f���ԍ��ʂ�ɕ���ł��邩�m�F
        for (int i = 0; i < kNum; i++)
        {
            // �v�f�ԍ��ʂ�łȂ��Ȃ炱���ł̏����I��
            if (_eles[i] != i) return;
        }

        // �����܂ŗ�����N���A���Ă���̂Ŋ����Ƃ���
        _isCreal = true;
        Debug.Log("�N���A");
    }

    private void EleCheck()
    {
        // �v�f�ԍ��̈ʒu���󔒒n�Ȃ牽�����Ȃ�
        if (_eles[_nowEle] == kNum - 1) return;

        // ��̃`�F�b�N
        if (DirCheck(kDirUp)) return;
        // ���̃`�F�b�N
        if (DirCheck(kDirDown)) return;
        // ���̃`�F�b�N
        if (DirCheck(kDirLeft)) return;
        // �E�̃`�F�b�N
        if (DirCheck(kDirRight)) return;
    }

    private bool DirCheck(int dir)
    {
        // �v�f���Ȃ��ɂ��Ȃ���Ίm�F���Ȃ�
        if ((_nowEle + dir) < 0 ||
            kNum <= (_nowEle + dir))
        {
            return false;
        }
        // ���E�̏ꍇ�[�ɂ���Ίm�F���Ȃ�
        if (dir == kDirLeft &&
            (_nowEle % kRaw) == 0)
        {
            return false;
        }
        if (dir == kDirLeft &&
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
    private void ChangeTrs(int ele)
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

        for (int i = 0; i < 4; i++)
        {
            Debug.Log(_eles[i * kRaw] + ", " + _eles[i * kRaw + 1] + ", " + _eles[i * kRaw + 2] + ", " + _eles[i * kRaw + 3]);
        }
    }
}
