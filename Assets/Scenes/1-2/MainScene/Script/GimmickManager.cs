// �M�~�b�N�}�l�[�W���[

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickManager : MonoBehaviour
{
    // �M�~�b�N�����������ǂ���
    [SerializeField] private bool[] _solveGimmick;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // �ǃM�~�b�N
        WallGimmick._instance.UpdateWall(_solveGimmick[0]);
        WallGimmick._instance.DebugReset(_solveGimmick[0]);

        // �x���g�R���x�A
        BeltConveyorGimmick._instance.UpdateBeltConveyor(_solveGimmick[1]);
    }
}
