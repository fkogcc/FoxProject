// 壁ギミック

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGimmick : MonoBehaviour
{
    private SolveGimmickManager _manager;

    // シングルトン
    public static WallGimmick _instance;
    // 扉が開いた時の最終位置
    private Vector3 _targetPosition;
    private Vector3 _velocity = Vector3.zero;
    [Header("ドアの配置をリセットするときの座標")]
    [SerializeField] private Vector3 _resetPosition = Vector3.zero;
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

    private void Start()
    {
        _manager = GameObject.Find("SceneManager").GetComponent<SolveGimmickManager>();
        _targetPosition = new Vector3(transform.position.x, transform.position.y + 10.0f, transform.position.z);
    }

    private void FixedUpdate()
    {
        if (_manager._solve[0])
        {
            UpdateWall();
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
            transform.position = _resetPosition;
        }
    }

}
