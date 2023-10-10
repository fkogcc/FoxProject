// 1-1ギミックマネージャー

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickManager1_1 : MonoBehaviour
{
    // ギミックを解いたかどうか
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
        // 橋の処理.
        GimmickBirdge._instance.UpdateBirdgeAisle(_solveGimmick[0]);

        // 風車の処理
        RotateWindmill._instance.UpdateRotateWindmill(_solveGimmick[1]);
    }
}
