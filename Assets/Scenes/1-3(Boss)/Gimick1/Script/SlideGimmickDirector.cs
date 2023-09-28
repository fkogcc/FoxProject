using Microsoft.Cci;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideGimmickDirector : MonoBehaviour
{
    // �v���C���[�̓�����
    private const float kSpeed = 0.25f;

    // �������u���b�N�̐�.
    private const int kBlockNum = 16;

    // ���݂̎�̈ʒu����̏㉺���E
    private const int kDirUp = -4;
    private const int kDirDown = 4;
    private const int kDirLeft = -1;
    private const int kDirRight = 1;
    // �㉺���E�̕����̐�
    private const int kDirNum = 4;

    // ���ɕ���ł���u���b�N�̐�
    private const int kRaw = 4;

    // ����ւ��ɂ�����t���[����
    private const int kMoveFrame = 25;

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

    // ����ւ����ԃJ�E���g�p
    private int _moveCount;
    private int _moveEle;
    // ����ւ������Ă��邩
    private bool _isChange;

    // �N���A���Ă��邩���Ă��Ȃ���
    private bool _isCreal;

    private void Start()
    {
        // ������
        _player = new GameObject();

        _parentObj = new GameObject();
        _gimmickObj = new GameObject[kBlockNum];

        _eles = new int[kBlockNum];

        _nowEle = kBlockNum - 1;

        _tempPos1 = new Vector3();
        _tempPos2 = new Vector3();
        _tempEle = 0;

        _moveCount = 0;
        _moveEle = 0;
        _isChange = false;

        _isCreal = false;

        // �v���C���[��T��
        _player = GameObject.Find("Hand");

        // �e�I�u�W�F��T��.
        _parentObj = GameObject.Find("Box");

        for (int i = 0; i < kBlockNum; i++)
        {
            // �q�I�u�W�F��T��.
            _gimmickObj[i] = _parentObj.transform.GetChild(i).gameObject;
            // �v�f�ԍ��̑��.
            _eles[i] = i;
        }

        // �V���b�t��
        for(int i = 0; i < 32; i++)
        {
            _nowEle = Random.Range(0, kBlockNum);
            
            switch(Random.Range(0, kDirNum))
            {
                case 0:// ��
                    // ����������ʒu��ς���
                    if (MoveCheck(kDirUp))  ChangeTrs(_nowEle + kDirUp);
                    // �������Ȃ������������x
                    // ������x���Ȃ��Ɗ��V���b�t���̎�������A�N���A�s�ɂȂ�
                    else                    i--;
                    break;
                case 1:// ��
                    if (MoveCheck(kDirDown))    ChangeTrs(_nowEle + kDirDown);
                    else                        i--;
                    break;
                case 2:// �E
                    if (MoveCheck(kDirRight))   ChangeTrs(_nowEle + kDirRight);
                    else                        i--;
                    break;
                case 3:// ��
                    if (MoveCheck(kDirLeft))    ChangeTrs(_nowEle + kDirLeft);
                    else                        i--;
                    break;
                default:
                    // �����ɂ͗��Ȃ�
                    break;
            }
        }
    }

    private void Update()
    {
        // �v���C���[�̈ړ�����
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _player.transform.position += Vector3.up * kSpeed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            _player.transform.position += Vector3.down * kSpeed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _player.transform.position += Vector3.right * kSpeed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _player.transform.position += Vector3.left * kSpeed;
        }

        // �N���A���Ă�����ړ��ȊO�������Ȃ�
        if (_isCreal) return;


        // ����̃{�^������������M�~�b�N�̏���
        // ���̎�����ւ����������Ă��Ȃ�
        if (Input.GetKeyDown(KeyCode.F) && !_isChange)
        {
            // ���݃v���C���[�̎肪����ʒu��ۑ�
            _nowEle = _player.GetComponent<GimmickHand>().GetEleNum();

            // �������邩�ǂ����̔�������Ă���
            EleCheck();
        }
    }

    private void FixedUpdate()
    {
        // �N���A���Ă����珈�����Ȃ�
        if (_isCreal) return;

        if (_isChange)
        {
            _moveCount++;

            // �������������Ă���
            _gimmickObj[_eles[_moveEle]].transform.position += _tempPos2;

            // ���Ԃ��������瓮���Ȃ��悤�ɂ���
            if (kMoveFrame <= _moveCount) _isChange = false;

            // �����I���܂ŉ��̏����͍s��Ȃ��悤����
            return;
        }

        // �v�f���ԍ��ʂ�ɕ���ł��邩�m�F
        for (int i = 0; i < kBlockNum; i++)
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
        if (_eles[_nowEle] == kBlockNum - 1) return;

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
        // ���̕����ɓ������邩�̊m�F
        if (!MoveCheck(dir)) return false;

        // dir�̕����̂��̂��󔒂̏ꍇ������
        if (_eles[_nowEle + dir] == kBlockNum - 1)
        {
            ChangeTrs(_nowEle + dir, false);

            return true;
        }

        return false;
    }

    bool MoveCheck(int dir)
    {
        // �v�f���Ȃ��ɂ��Ȃ���Ίm�F���Ȃ�
        if ((_nowEle + dir) < 0 ||
            kBlockNum <= (_nowEle + dir))
        {
            return false;
        }
        // ���E�̏ꍇ�[�ɂ���Ίm�F���Ȃ�
        if (dir == kDirLeft &&
            (_nowEle % kRaw) == 0)
        {
            return false;
        }
        if (dir == kDirRight &&
            (_nowEle % kRaw) == (kRaw - 1))
        {
            return false;
        }

        // �����܂ŗ����瓮������ʒu�ɂ���
        return true;
    }

    // �ʒu�̕ύX
    // �v�f��ځA�v�f���
    private void ChangeTrs(int ele, bool isShuffle = true)
    {
        // ���ꂼ��̈ʒu��ۑ�.
        _tempPos1 = _gimmickObj[_eles[_nowEle]].transform.position;
        _tempPos2 = _gimmickObj[_eles[ele]].transform.position;

        // �ۑ������ʒu���g���A�ʒu�̓���ւ�
        // �󔒒n�͂����Ɉړ�
        _gimmickObj[_eles[ele]].transform.position = _tempPos1;
        if (isShuffle) _gimmickObj[_eles[_nowEle]].transform.position = _tempPos2;
        else MoveEfeStart(ele);

        // �v�f�̔ԍ���ύX.
        _tempEle = _eles[_nowEle];
        _eles[_nowEle] = _eles[ele];
        _eles[ele] = _tempEle;
    }

    void MoveEfeStart(int ele)
    {
        // �����z���I������
        _moveEle = ele;
        // �J�E���g�̏�����
        _moveCount = 0;

        // �����ʒu�܂Ńx�N�g�������߁A�ړ����ԂŊ���
        _tempPos2 = _tempPos2 - _tempPos1;
        _tempPos2 /= kMoveFrame;

        // �����悤�ɂ���
        _isChange = true;
    }
}
