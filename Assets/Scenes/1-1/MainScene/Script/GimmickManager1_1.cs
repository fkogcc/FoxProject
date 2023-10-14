// 1-1�M�~�b�N�}�l�[�W���[

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickManager1_1 : MonoBehaviour
{
    // �M�~�b�N���쓮���Ă��邩�ǂ���
    [SerializeField] public bool[] _operationGimmick;

    private void FixedUpdate()
    {
        // ���̏���.
        GimmickBirdge._instance.UpdateBirdgeAisle();

        // ���Ԃ̏���
        RotateWindmill._instance.UpdateRotateWindmill();
    }

    // �M�~�b�N�������������󂯎��
    public bool GetSolveGimmick(int operationGimmick)
    {
        return _operationGimmick[operationGimmick];
    }
}
