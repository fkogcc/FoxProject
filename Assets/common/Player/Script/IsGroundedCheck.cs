using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGroundedCheck : MonoBehaviour
{
    public static IsGroundedCheck _instance;

    // 足から地面までのRayの長さ.
    [SerializeField] public float _rayLength = 1.0f;

    // 身体にめり込ませるRayの長さ.
    [SerializeField] public float _rayOffset;

    // Rayの判定に用いるLayer.
    [SerializeField] private LayerMask _layerMask = default;

    // 地面に接地しているかどうか.
    public bool _isGround;

    // レイ
    RaycastHit hit;

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
        // Rayの初期位置と姿勢.
        Ray ray = new(origin: transform.position + Vector3.up * _rayOffset, direction: Vector3.down);

        // Rayが接地するかどうか.
        // 円
        return Physics.SphereCast(transform.position, 5, transform.forward * 10, out hit);
        // 線
        //return Physics.Raycast(ray, _rayLength, _layerMask);
    }

    private void OnDrawGizmos()
    {
        // デバッグ表示.
        // 接地.
        // true 緑.
        // false 赤.
        Gizmos.color = _isGround ? Color.green : Color.red;
        //Gizmos.DrawRay(transform.position + Vector3.up * _rayOffset, Vector3.down * _rayLength);
        Gizmos.DrawWireSphere(transform.position + Vector3.up * _rayOffset, _rayLength);
    }
}
