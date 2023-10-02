using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlaneManager : MonoBehaviour
{
    private enum moveNum
    {
        up,
        right,
        down,
        left,
        empty,
    }
    private GameObject _player;//���C���v���C���[�������ϐ�
    private GameObject _planeManager;//�ړ��������܂Ƃ߂�X�N���v�g�����Ă���I�u�W�F�N�g������ϐ�
    private int _moveAngle;//�𓥂񂾎��̓����̕��������߂�ϐ�
    private float _planeAngle;//���ǂ̕����������Ă邩�����߂�ϐ�
    public bool _isPanelColor;//����������p�l���������łȂ����𔻒f����ϐ�
    public bool _isWall;//�ǂ��ǂ����𔻒f����ϐ�
    private int _lastCol;//�̏����������������Ă��邩���f����ϐ�

    private void Start()
    {
        _player = GameObject.Find("3DPlayer");//���C���v���C���[��������
        _planeManager = GameObject.Find("PlaneManager");//�ړ��������܂Ƃ߂Ă���I�u�W�F�N�g�������
        _planeAngle = this.transform.localEulerAngles.y;//�̌�����������

    }
    private void FixedUpdate()
    {
        Debug.Log(_planeManager.GetComponent<PlaneBool>().GetLastCol());
        if (_planeManager.GetComponent<PlaneBool>().GetMoving())//�̏����𓮂������ǂ����̔��f
        {
            if (_planeManager.GetComponent<PlaneBool>().GetAngle() == (int)moveNum.up)//����������Ă���ꍇ
            {
                _player.transform.position += new Vector3(-0.002f, 0.0f, 0.0f);
            }
            else if (_planeManager.GetComponent<PlaneBool>().GetAngle() == (int)moveNum.right)//���E�������Ă���ꍇ
            {
                _player.transform.position += new Vector3(0.0f, 0.0f, 0.002f);
            }
            else if (_planeManager.GetComponent<PlaneBool>().GetAngle() == (int)moveNum.down)//�����������Ă���ꍇ
            {
                _player.transform.position += new Vector3(0.002f, 0.0f, 0.0f);
            }
            else if (_planeManager.GetComponent<PlaneBool>().GetAngle() == (int)moveNum.left)//�����������Ă���ꍇ
            {
                _player.transform.position += new Vector3(0.0f, 0.0f, -0.002f);
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //if(_isPanelColor)
        //{
        //    _planeManager.GetComponent<PlaneBool>().ResetLastCol();
        //    _planeManager.GetComponent<PlaneBool>().SetLastCol(1);
        //}
        if (!_isWall)//�Ǐo�Ȃ������珈�����s��
        {
            _planeManager.GetComponent<PlaneBool>().SetLastCol(1);//�������s���Ă���̖������J�E���g����
            _planeManager.GetComponent<PlaneBool>().SetMoving(true);//�̏������s���悤�ɂ���
            if (_planeAngle == 0)//��
            {
                _planeManager.GetComponent<PlaneBool>().SetAngle((int)moveNum.up);
            }
            else if (_planeAngle == 90)//�E
            {
                _planeManager.GetComponent<PlaneBool>().SetAngle((int)moveNum.right);
            }
            else if (_planeAngle == 180)//��
            {
                _planeManager.GetComponent<PlaneBool>().SetAngle((int)moveNum.down);
            }
            else if (_planeAngle == 270)//��
            {
                _planeManager.GetComponent<PlaneBool>().SetAngle((int)moveNum.left);
            }
        }
        else//�ǂɂԂ������ꍇ�̏���
        {
            if (_planeManager.GetComponent<PlaneBool>().GetLastCol() > 0)
            {
                _planeManager.GetComponent<PlaneBool>().ResetLastCol();
            }
            _planeManager.GetComponent<PlaneBool>().SetMoving(false);//�̏������~�߂�
            _moveAngle = (int)moveNum.empty;//�����̕������Ȃ���
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (_isPanelColor)//���F�̃p�l������o���ꍇ
        {
            if (_planeManager.GetComponent<PlaneBool>().GetLastCol() > 0)//�������s���Ă���̖�����1���ȏゾ�����ꍇ
            {
                _planeManager.GetComponent<PlaneBool>().SetLastCol(-1);//�������s���Ă���̖������ꖇ���炷
            }
            if (_planeManager.GetComponent<PlaneBool>().GetLastCol() == 0)//�����������s���Ă��閇�����[����������
            {
                _planeManager.GetComponent<PlaneBool>().SetMoving(false);//�������~�߂�
                _moveAngle = (int)moveNum.empty;//�����̕������Ȃ���
            }
        }
    }
}


