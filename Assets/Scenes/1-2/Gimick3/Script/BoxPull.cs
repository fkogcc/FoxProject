using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPull : MonoBehaviour
{
    // �M�~�b�N�u���b�N�̒���
    private const float kGimmickLength = 0.75f;

    // �f�B���N�^�[.
    private BoxDirector _director;
    // �M�~�b�N�̐F.
    public string Color;
    // �v���C���[�̈ʒu���.
    private Transform _player;
    // �M�~�b�N�I�u�W�F.
    private GameObject _gimmick;
    private List<GameObject> _gimmicks;
    // �u���b�N��ǉ����鋗��
    private float _longDis;
    // �u���b�N�����炷����
    private float _shortDis;
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
    // �p�x������悤
    private float _angle = 0.0f;

    void Start()
    {
        _director = GameObject.Find("GimmickDirector").GetComponent<BoxDirector>();

        _player = GameObject.Find("3DPlayer").GetComponent<Transform>();

        // �N���A�O�܂ł̃I�u�W�F.
        _gimmick = (GameObject)Resources.Load(Color + "Cube");

        _gimmicks = new List<GameObject>();

        _longDis = 0.0f;
        _shortDis = 0.0f;

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

        if ((Input.GetKeyDown("joystick button 1") || Input.GetKeyDown(KeyCode.F)) && _isPullRange)
        {
            // ��������n�߂��ʒu�̕ۑ�.
            _startPos = _player.position;

            _gimmicks.Add(Instantiate(_gimmick, this.transform.position, Quaternion.identity));
            _shortDis = 0;
            _longDis = kGimmickLength;

            _director.SetGimmickOut(Color);

            _isPull = true;
        }

        if ((Input.GetKeyUp("joystick button 1") || Input.GetKeyUp(KeyCode.F)) && _isPull)
        {
            foreach (var temp in _gimmicks)
            {
                Destroy(temp.gameObject);
            }
            _gimmicks.Clear();

            // �������F����������n�߂��F�Ɠ�����.
            // �M�~�b�N�N���A�͈͓��ɂ��邩.
            if (_director.IsSameColor())
            {
                // �M�~�b�N���N���A�������Ƃɂ���.
                _isClear = true;

                // �N���A��I�u�W�F�𐶐�.
                Instantiate(_clearObj);

                // ���̓N���A��ɃI�u�W�F�N�g��ς��Ȃ��ł����@.
                //// �ʒu�����ꂢ�ɂȂ�悤�ɐ��`.
                //_moveVec = _director.GetGimmickPos() - this.transform.position;


                //ObjPlacement();
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
        // ���݂܂ł̃x�N�g�����v�Z.
        _moveVec = _player.position - _startPos;

        float _nowLength = _moveVec.magnitude;
        // �������L�т���ǉ�����.
        if (_longDis <= _nowLength)
        {
            // ���苗���̍X�V.
            _longDis += kGimmickLength;
            _shortDis += kGimmickLength;

            // �u���b�N�̒ǉ�.
            _gimmicks.Add(Instantiate(_gimmick, this.transform.position, Quaternion.identity));
        }
        // ��������������폜����.
        else if (_nowLength < _shortDis)
        {
            // ���苗���̍X�V.
            _longDis -= kGimmickLength;
            _shortDis -= kGimmickLength;

            // GameObject���폜�̂̂��A���X�g����폜.
            Destroy(_gimmicks[_gimmicks.Count - 1]);
            _gimmicks.RemoveAt(_gimmicks.Count - 1);
        }

        // �p�x�����߂�.
        _angle = Mathf.Atan2(_moveVec.z, _moveVec.x) * Mathf.Rad2Deg * -1;

        // �o���I�u�W�F�N�g�̗ʂŊ���.
        _moveVec /= _gimmicks.Count;

        for (int i = 0; i < _gimmicks.Count; i++)
        {
            _gimmicks[i].transform.position = this.transform.position + _moveVec * (i + 1);
            _gimmicks[i].transform.rotation = Quaternion.AngleAxis(_angle, new Vector3(0.0f, 1.0f, 0.0f));
        }
    }
}
