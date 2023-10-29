// 壁ギミック

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGimmick : MonoBehaviour
{
    private SolveGimmickManager _manager;

    // 扉が開いた時の最終位置.
    private Vector3 _targetPosition;
    private Vector3 _velocity = Vector3.zero;
    [Header("ドアの配置をリセットするときの座標")]
    [SerializeField] private Vector3 _resetPosition = Vector3.zero;
    // ターゲットにたどり着く時間.
    [SerializeField] private float _time;

    private void Start()
    {
        _manager = GameObject.FindWithTag("GimmickManager").GetComponent<SolveGimmickManager>();
        _targetPosition = new Vector3(transform.position.x, transform.position.y + 10.0f, transform.position.z);
    }

    private void FixedUpdate()
    {
        if (_manager._solve[0])
        {
            UpdateWall();
        }
        if (!_manager._solve[0])
        {
            DebugReset();
        }
    }

    /// <summary>
    /// 壁のギミック更新処理.
    /// </summary>
    public void UpdateWall()
    {
        transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref _velocity, _time);
    }

    // デバッグ用ギミックリセット.
    public void DebugReset()
    {
        transform.position = _resetPosition;
    }

}
