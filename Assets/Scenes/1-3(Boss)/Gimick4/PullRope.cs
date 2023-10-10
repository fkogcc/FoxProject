using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullRope : MonoBehaviour
{
    // �M�~�b�N�u���b�N�̒���
    private const float kGimmickLength = 0.75f;
    // �v���C���[�̈ʒu���.
    private Transform _player;
    // �M�~�b�N�I�u�W�F.
    public GameObject _gimmick;
    private List<GameObject> _gimmicks;
    // �u���b�N��ǉ����鋗��
    private float _longDis;
    // �u���b�N�����炷����
    private float _shortDis;
    // ���������Ă��邩.
    private bool _isPull;
    // ��������n�߂��ʒu.
    private Vector3 _startPos;
    // �ړ��x�N�g��.
    private Vector3 _moveVec;
    // �p�x������悤
    private float _angle = 0.0f;
    // ���������͈͂ɂ��邩
    private bool _isFlag;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("3DPlayer").GetComponent<Transform>();

        _gimmicks = new List<GameObject>();

        _longDis = 0.0f;

        _shortDis = 0.0f;
        _isPull = false;
        _isFlag = false;
        _startPos = new Vector3();
        _moveVec = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown("joystick button 1") || Input.GetKeyDown(KeyCode.F)) && _isFlag)
        {
            // ��������n�߂��ʒu�̕ۑ�.
            _startPos = _player.position;

            _gimmicks.Add(Instantiate(_gimmick, this.transform.position, Quaternion.identity));
            _shortDis = 0;
            _longDis = kGimmickLength;

            _isPull = true;
        }
        if ((Input.GetKeyUp("joystick button 1") || Input.GetKeyUp(KeyCode.F)) && _isPull)
        {
            foreach (var temp in _gimmicks)
            {
                Destroy(temp.gameObject);
            }
            _gimmicks.Clear();
            _isPull = false;
        }
    }

    private void FixedUpdate()
    {
        if (_isPull)
        {
            ObjPlacement();
        }
    }

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
    void OnTriggerEnter(Collider other)
    {
        _isFlag = true;
    }
}
