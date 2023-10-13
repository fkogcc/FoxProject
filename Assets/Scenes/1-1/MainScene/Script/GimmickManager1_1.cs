// 1-1ギミックマネージャー

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickManager1_1 : MonoBehaviour
{
    // ギミックが作動しているかどうか
    [SerializeField] private bool[] _operationGimmick;

    private void FixedUpdate()
    {
        // 橋の処理.
        GimmickBirdge._instance.UpdateBirdgeAisle(_operationGimmick[0]);

        // 風車の処理
        RotateWindmill._instance.UpdateRotateWindmill(_operationGimmick[1]);
    }

    // ギミックを解いたかを受け取る
    public bool GetSolveGimmick(int operationGimmick)
    {
        return _operationGimmick[operationGimmick];
    }
}
