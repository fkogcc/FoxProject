using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPull : MonoBehaviour
{
    // �M�~�b�N�̃R�[�h���Ȃ��r���̃L���[�u�̐�
    private const int kNum = 20;

    // �f�B���N�^�[.
    private BoxDirector _director;
    // �M�~�b�N�̐F.
    public string Color;
    // �v���C���[�̈ʒu���.
    private Transform _player;
    // �M�~�b�N�I�u�W�F.
    private GameObject _gimmick;
    private GameObject[] _gimmicks = new GameObject[kNum];
    // �N���A�I�u�W�F.
    private GameObject _clearObj;
    // ���������͈͂ɂ��邩��.
    private bool _isPullRange;
    // ���������Ă��邩.
    private bool _isPull;
    // �M�~�b�N�N���A���Ă��邩.
    private bool _isClear;
    // ��������n�߂��ʒu.
    private Vector3 _startPos;
    // �ړ��x�N�g��.
    private Vector3 _moveVec;

    void Start()
    {
        _director = GameObject.Find("GimmickDirector").GetComponent<BoxDirector>();

        _player = GameObject.Find("3DPlayer").GetComponent<Transform>();

        // �N���A�O�܂ł̃I�u�W�F.
        _gimmick = (GameObject)Resources.Load("Cube");

        for (int i = 0; i < kNum; i++)
        {
            _gimmicks[i] = Instantiate(_gimmick, this.transform.position, Quaternion.identity);
        }

        // �N���A��̃I�u�W�F.
        _clearObj = (GameObject)Resources.Load(Color + "Cylinder");

        // bool�֌W�����ׂ�false��.
        _isPullRange = false;
        _isPull = false;
        _isClear = false;

        _startPos = new Vector3();
        _moveVec = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        // �M�~�b�N���N���A���Ă����珈�������Ȃ�.
        if (_isClear) return;

        if ((Input.GetKeyDown("joystick button 1") || Input.GetKeyUp(KeyCode.F)) && _isPullRange)
        {
            // ��������n�߂��ʒu�̕ۑ�.
            _startPos = _player.position;

            _director.SetGimmickOut(Color);

            _isPull = true;
        }

        if ((Input.GetKeyUp("joystick button 1") || Input.GetKeyUp(KeyCode.F)) && _isPull)
        {
            // �������F����������n�߂��F�Ɠ�����.
            // �M�~�b�N�N���A�͈͓��ɂ��邩.
            if (_director.IsSameColor())
            {
                // �M�~�b�N���N���A�������Ƃɂ���.
                _isClear = true;

                // �N���A��I�u�W�F�𐶐�.
                Instantiate(_clearObj);

                // �N���A�O�I�u�W�F�̍폜.
                for (int i = 0; i < kNum; i++)
                {
                    Destroy(_gimmicks[i]);
                }

                // ���̓N���A��ɃI�u�W�F�N�g��ς��Ȃ��ł����@.
                //// �ʒu�����ꂢ�ɂȂ�悤�ɐ��`.
                //_moveVec = _director.GetGimmickPos() - this.transform.position;


                //ObjPlacement();
            }
            else
            {
                // ���̈ʒu�ɖ߂�.
                for (int i = 0; i < kNum; i++)
                {
                    _gimmicks[i].transform.position = this.transform.position;
                }
            }

            _isPull = false;
        }
    }

    void FixedUpdate()
    {
        // �M�~�b�N���N���A���Ă����珈�������Ȃ�.
        if (_isClear) return;

        if (_isPull)
        {
            // ���݂܂ł̃x�N�g�����v�Z.
            _moveVec = _player.position - _startPos;

            ObjPlacement();
        }
    }

    // �͈͓��ɓ������ꍇ���������悤�ɂ���.
    void OnTriggerEnter(Collider other)
    {
        _isPullRange = true;
    }

    // �͈͊O�ɏo�����������Ȃ��悤�ɂ���.
    void OnTriggerExit(Collider other)
    {
        _isPullRange = false;
    }

    // �ړ��ʕ����炵�ăI�u�W�F�N�g�̐ݒu.
    void ObjPlacement()
    {
        // �o���I�u�W�F�N�g�̗ʂŊ���.
        _moveVec /= kNum;

        // ���������炵�Ĉʒu��u��.
        for (int i = 0; i < kNum; i++)
        {
            _gimmicks[i].transform.position = this.transform.position + _moveVec * (i + 1);
        }
    }
}
