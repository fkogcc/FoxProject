// ギミックマネージャー

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickManager : MonoBehaviour
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
        // 壁ギミック
        WallGimmick._instance.UpdateWall(_solveGimmick[0]);
        WallGimmick._instance.DebugReset(_solveGimmick[0]);

        // ベルトコンベア
        BeltConveyorGimmick._instance.UpdateBeltConveyor(_solveGimmick[1]);
    }
}
