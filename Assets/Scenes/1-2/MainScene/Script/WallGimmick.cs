using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGimmick : MonoBehaviour
{
    // シングルトン
    public static WallGimmick _instance;
    // 扉が開いた時の最終位置
    private Vector3 _targetPosition = new Vector3(84.0f, 15.0f, 1.0f);
    private Vector3 _velocity = Vector3.zero;
    // ターゲットにたどり着く時間
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
    /// 壁のギミック更新処理
    /// </summary>
    /// <param name="solveGimmick">ギミックを解いたかどうか</param>
    public void UpdateWall(bool solveGimmick)
    {
        // ギミックが解かれていなかったらreturn
        if(!solveGimmick) return;

        transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref _velocity, _time);
    }

    // デバッグ用ギミックリセット
    public void DebugReset(bool solveGimmick)
    {
        if(!solveGimmick)
        {
            transform.position = new Vector3(84.0f, 5.0f, 1.0f);
        }
    }

}
