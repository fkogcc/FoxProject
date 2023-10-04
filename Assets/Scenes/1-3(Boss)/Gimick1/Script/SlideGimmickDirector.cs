using Microsoft.Cci;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideGimmickDirector : MonoBehaviour
{
    // �X�e�B�b�N���
    // ��������.
    private float _vertical;
    // ��������.
    private float _horizontal;
    // �v���C���[�̓�����.
    private const float kSpeed = 0.125f;

    // ���ɕ���ł���u���b�N�̐�.
    private const int kRaw = 4;
    // �c�ɕ���ł���u���b�N�̐�.
    private const int kCol = 4;
    // �u���b�N�̑���.
    private const int kBlockNum = kRaw * kCol;
    // �Ō�̃u���b�N���󔒂Ƃ���.
    private const int kNoneBlockNo = kBlockNum - 1;
    // -1���ЂƂO�ɖ߂�{�^���Ƃ��Ă���
    private const int kBackOneStepNo = -1;
    // -2�����Z�b�g�{�^���Ƃ��Ă���
    private const int kResetNo = -2;

    // ���݂̎�̈ʒu����̏㉺���E.
    private const int kDirUp = -kRaw;
    private const int kDirDown = kRaw;
    private const int kDirLeft = -1;
    private const int kDirRight = 1;
    // �㉺���E�̕����̐�.
    private const int kDirNum = 4;

    // ����ւ��ɂ�����t���[����.
    private const int kMoveFrame = 10;

    // �v���C���[.
    private GameObject _player;

    // �M�~�b�N�e�I�u�W�F.
    private GameObject _parentObj;
    // �M�~�b�N�q�I�u�W�F.
    private GameObject[] _gimmickObj;

    // �v�f�̔ԍ�.
    private int[] _eles;

    // ���݂̗v�f.
    private int _nowEle;

    // �͂��߂̗v�f��������悤.
    private int[] _startEles;
    // �ЂƂO�ɓ��������ꏊ���1
    Stack<int> _endEle1;
    // �ЂƂO�ɓ��������ꏊ���2
    Stack<int> _endEle2;

    // ����ւ��p.
    private Vector3 _tempPos1;
    private Vector3 _tempPos2;
    private int _tempEle;

    // ����ւ����ԃJ�E���g�p.
    private int _moveCount;
    private int _moveEle;
    // ����ւ������Ă��邩.
    private bool _isChange;

    // �N���A���Ă��邩���Ă��Ȃ���.
    private bool _isCreal;

    private void Start()
    {
        // ������
        _vertical = 0.0f;
        _horizontal = 0.0f;
        _player = new GameObject();

        _parentObj = new GameObject();
        _gimmickObj = new GameObject[kBlockNum];

        _eles = new int[kBlockNum];

        _nowEle = kNoneBlockNo;

        _startEles = new int[kBlockNum];
        _endEle1 = new Stack<int>();
        _endEle2 = new Stack<int>();

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

        int[] _dirNum = { kDirDown, kDirUp, kDirLeft, kDirRight };
        int _changeDir;

        // �V���b�t��.
        for (int i = 0; i < 48; i++)
        {
            // 0~�󔒒n�O�܂ł̃u���b�N�œ������悤�ɂ���.
            _nowEle = Random.Range(0, kNoneBlockNo);

            // �������ʒu���󔒂łȂ��ꍇ�̂ݓ�����.
            // �������Ȃ�or�󔒒n�ł���ꍇ��
            // ������x�J��Ԃ��������s���悤�ɂ���.
            // �J��Ԃ��̂͊�񂵂��������Ă��Ȃ��ꍇ�ςݔz�u���o���Ă��܂�����.
            _changeDir = _dirNum[Random.Range(0, kDirNum)];
            if (MoveCheck(_changeDir, true)) ChangeTrs(_nowEle + _changeDir, false);
            else i--;
        }

        // ���߂̏�Ԃ�ۑ�
        for (int i = 0; i < kBlockNum; i++)
        {
            _startEles[i] = _eles[i];
        }
    }

    private void Update()
    {
        // ��������.
        _vertical = Input.GetAxis("Horizontal");
        // ��������.
        _horizontal = Input.GetAxis("Vertical");

        // �v���C���[�̈ړ�����.
        if (0.0f < _horizontal)
        {
            _player.transform.position += Vector3.up * kSpeed;
        }
        if (_horizontal < 0.0f)
        {
            _player.transform.position += Vector3.down * kSpeed;
        }
        if (0.0f < _vertical)
        {
            _player.transform.position += Vector3.right * kSpeed;
        }
        if (_vertical < 0.0f)
        {
            _player.transform.position += Vector3.left * kSpeed;
        }

        // �N���A���Ă�����ړ��ȊO�������Ȃ�.
        if (_isCreal) return;

        // ����ւ����Ă����珈�����Ȃ�.
        if (_isChange) return;

        // ����̃{�^������������M�~�b�N�̏���.
        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown("joystick button 1"))
        {
            // ���݃v���C���[�̎肪����ʒu��ۑ�.
            _nowEle = _player.GetComponent<GimmickHand>().HitNo;

            if (_nowEle == kBackOneStepNo)
            {
                Debug.Log("�ЂƂO�ɖ߂�");
                BackOneStep();
            }
            else if (_nowEle == kResetNo)
            {
                ResetBlock();
            }
            else
            {
                // �������邩�ǂ����̔�������Ă���.
                EleCheck();
            }
        }
    }

    private void FixedUpdate()
    {
        // �N���A���Ă����珈�����Ȃ�.
        if (_isCreal) return;

        if (_isChange)
        {
            _moveCount++;

            // �������������Ă���.
            _gimmickObj[_eles[_moveEle]].transform.position += _tempPos2;

            // ���Ԃ��������瓮���Ȃ��悤�ɂ���.
            if (kMoveFrame <= _moveCount) _isChange = false;

            // �����I���܂ŉ��̏����͍s��Ȃ��悤����.
            return;
        }

        // �v�f���ԍ��ʂ�ɕ���ł��邩�m�F.
        for (int i = 0; i < kBlockNum; i++)
        {
            // �v�f�ԍ��ʂ�łȂ��Ȃ炱���ł̏����I��.
            if (_eles[i] != i) return;
        }

        // �����܂ŗ�����N���A���Ă���̂Ŋ����Ƃ���.
        _isCreal = true;
        Debug.Log("�N���A");
    }

    // 1�O�̏��ɖ߂�
    private void BackOneStep()
    {
        // �f�[�^�������ĂȂ��ꍇ�͂��Ȃ�
        if (_endEle1.Count <= 0) return;

        Debug.Log("�ς����");
        _nowEle = _endEle1.Pop();
        ChangeTrs(_endEle2.Pop(), false);
    }

    // �͂��߂̏�Ԃɖ߂�
    private void ResetBlock()
    {
        for (int i = 0; i < kBlockNum; i++)
        {
            _nowEle = i;

            // ���݂̈ʒu�̕����͂��߂ƈꏏ�̏ꍇ���̂Ɉڂ�
            if (_eles[i] == _startEles[_nowEle]) continue;

            // ����ȊO�͒T������
            for (int j = i + 1; j < kBlockNum; j++)
            {
                // ���߂̏ꏊ���������炻���Əꏊ�ւ�
                if (_eles[j] == _startEles[_nowEle])
                {
                    ChangeTrs(j, false);

                    // �T����ƏI��
                    break;
                }
            }
        }

        // 1�O�ɖ߂����Ƃ�������S�ď���
        _endEle1.Clear();
        _endEle2.Clear();
    }

    private void EleCheck()
    {
        // �v�f�ԍ��̈ʒu���󔒒n�Ȃ牽�����Ȃ�.
        if (_eles[_nowEle] == kNoneBlockNo) return;

        // ��̃`�F�b�N.
        if (DirCheck(kDirUp)) return;
        // ���̃`�F�b�N.
        if (DirCheck(kDirDown)) return;
        // ���̃`�F�b�N.
        if (DirCheck(kDirLeft)) return;
        // �E�̃`�F�b�N.
        if (DirCheck(kDirRight)) return;
    }

    // ���̕����ɓ������邩�ǂ���.
    private bool DirCheck(int dir)
    {
        // ���̕����ɓ������邩�̊m�F.
        if (!MoveCheck(dir, false)) return false;
        
        ChangeTrs(_nowEle + dir, true);

        return true;
    }

    // �����ׂ̍����`�F�b�N.
    // �����������A�V���b�t�����ǂ���.
    bool MoveCheck(int dir, bool isShuffle)
    {
        // �v�f���Ȃ��ɂ��Ȃ���Ίm�F���Ȃ�.
        if ((_nowEle + dir) < 0 ||
            kBlockNum <= (_nowEle + dir))
        {
            return false;
        }
        // ���E�̏ꍇ�[�ɂ���Ίm�F���Ȃ�.
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

        // �V���b�t���̏ꍇ.
        if (isShuffle)
        {
            // dir�̕����̂��̂��󔒈ȊO�̏ꍇ������.
            if (_eles[_nowEle + dir] != kNoneBlockNo)
            {
                return true;
            }
        }
        else
        // �V���b�t���łȂ��ꍇ.
        {
            // dir�̕����̂��̂��󔒂̏ꍇ������.
            if (_eles[_nowEle + dir] == kNoneBlockNo)
            {
                return true;
            }
        }

        return false;

    }

    // �ʒu�̕ύX.
    // �������ʒu�A�V���b�t�����ǂ���.
    private void ChangeTrs(int ele, bool isNormal)
    {
        // ���ꂼ��̈ʒu��ۑ�.
        _tempPos1 = _gimmickObj[_eles[_nowEle]].transform.position;
        _tempPos2 = _gimmickObj[_eles[ele]].transform.position;

        // �ۑ������ʒu���g���A�ʒu�̓���ւ�.
        // �󔒒n�͂����Ɉړ�.
        _gimmickObj[_eles[ele]].transform.position = _tempPos1;
        // �ʏ�̓����ȊO�����ɓ�����.
        if (!isNormal) _gimmickObj[_eles[_nowEle]].transform.position = _tempPos2;
        // �ʏ�̏ꍇ�͓���������.
        else MoveEfeStart(ele);

        // �ʏ�̓����̏ꍇ�͓����������ʒu��ۑ�����.
        if (isNormal)
        {
            _endEle1.Push(_nowEle);
            _endEle2.Push(ele);
        }
        // �v�f�̔ԍ���ύX.
        _tempEle = _eles[_nowEle];
        _eles[_nowEle] = _eles[ele];
        _eles[ele] = _tempEle;
    }

    void MoveEfeStart(int ele)
    {
        // �����z���I������.
        _moveEle = ele;
        // �J�E���g�̏�����.
        _moveCount = 0;

        // �����ʒu�܂Ńx�N�g�������߁A�ړ����ԂŊ���.
        _tempPos2 = _tempPos2 - _tempPos1;
        _tempPos2 /= kMoveFrame;

        // �����悤�ɂ���.
        _isChange = true;
    }
}
