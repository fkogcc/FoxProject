// 1-1�M�~�b�N�}�l�[�W���[

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickManager1_1 : MonoBehaviour
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
        // ���̏���.
        GimmickBirdge._instance.UpdateBirdgeAisle(_solveGimmick[0]);

        // ���Ԃ̏���
        RotateWindmill._instance.UpdateRotateWindmill(_solveGimmick[1]);
    }
}
