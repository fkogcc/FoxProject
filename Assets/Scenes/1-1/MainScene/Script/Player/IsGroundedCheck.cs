using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGroundedCheck : MonoBehaviour
{
    IsGroundedCheck _instance;

    // 足から地面までのRayの長さ
    [SerializeField] private float _rayLength = 1f;

    // 身体にめり込ませるRayの長さ
    [SerializeField] private float _rayOffset;

    // Rayの判定に用いるLayer
    [SerializeField] private LayerMask _layerMask = default;

    // 地面に接地しているかどうか
    private bool _isGround;

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
        Ray ray = new Ray(origin: transform.position + Vector3.up * _rayOffset, direction: Vector3.down);
        return Physics.Raycast(ray, _rayLength, _layerMask);
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
