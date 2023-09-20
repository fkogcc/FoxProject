using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGimmick : MonoBehaviour
{
    // �V���O���g��
    public static WallGimmick _instance;
    // �����J�������̍ŏI�ʒu
    private Vector3 _targetPosition = new Vector3(84.0f, 15.0f, 1.0f);
    private Vector3 _velocity = Vector3.zero;
    // �^�[�Q�b�g�ɂ��ǂ蒅������
    [SerializeField] private float _time;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// �ǂ̃M�~�b�N�X�V����
    /// </summary>
    /// <param name="solveGimmick">�M�~�b�N�����������ǂ���</param>
    public void UpdateWall(bool solveGimmick)
    {
        // �M�~�b�N��������Ă��Ȃ�������return
        if(!solveGimmick) return;

        transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref _velocity, _time);
    }

    // �f�o�b�O�p�M�~�b�N���Z�b�g
    public void DebugReset(bool solveGimmick)
    {
        if(!solveGimmick)
        {
            transform.position = new Vector3(84.0f, 5.0f, 1.0f);
        }
    }

}
