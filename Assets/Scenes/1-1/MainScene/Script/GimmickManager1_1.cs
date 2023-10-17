// 1-1表世界のギミックマネージャー

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickManager1_1 : MonoBehaviour
{
    // ギミックが作動しているかどうか
    [SerializeField] public bool[] _operationGimmick;

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        // 橋の処理.
        GimmickBirdge._instance.UpdateBirdgeAisle();

        // 風車の処理
        RotateWindmill._instance.UpdateRotateWindmill();
    }

    // ギミックを解いたかを受け取る
    public bool GetSolveGimmick(int operationGimmick)
    {
        return _operationGimmick[operationGimmick];
    }
}
