using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGroundedCheck : MonoBehaviour
{
    public static IsGroundedCheck _instance;

    // 足から地面までのRayの長さ
    [SerializeField] public float _rayLength = 1f;

    // 身体にめり込ませるRayの長さ
    [SerializeField] public float _rayOffset;

    // Rayの判定に用いるLayer
    [SerializeField] private LayerMask _layerMask = default;

    // 球形が通貨を開始する地点の中心
    [SerializeField] private Vector3 _origin;
    // 球の半径
    [SerializeField] private float _radius;
    // 球を通過させる方向
    [SerializeField] private Vector3 _direction;
    // RayCastによる情報を得るための構造体
    RaycastHit _hitInfo;
    // キャストの長さの最大値
    [SerializeField] private float _maxDistance;

    // 地面に接地しているかどうか
    public bool _isGround;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

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
        _isGround = CheckGrounded();
    }

    private bool CheckGrounded()
    {
        // Rayの初期位置と姿勢
        Ray ray = new(origin: transform.position + Vector3.up * _rayOffset, direction: Vector3.down);

        // Rayが接地するかどうか
        return Physics.Raycast(ray, _rayLength, _layerMask);

        //return Physics.SphereCast(transform.position + groundCheckOffsetY * Vector3.up,
        //groundCheckRadius,
        //Vector3.down,
        //out hit,
        //groundCheckDistance,
        //groundLayers,
        //QueryTriggerInteraction.Ignore);
    }

    private void OnDrawGizmos()
    {
        // デバッグ表示
        // 接地
        // true 緑
        // false 赤
        Gizmos.color = _isGround ? Color.green : Color.red;
        Gizmos.DrawRay(transform.position + Vector3.up * _rayOffset, Vector3.down * _rayLength);
    }
}
