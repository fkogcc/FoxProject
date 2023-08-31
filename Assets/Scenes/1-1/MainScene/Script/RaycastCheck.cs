using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastCheck : MonoBehaviour
{
    // インスタンス.
    public static RaycastCheck _instance;

    // 以下Inspectorでアクセス可
    // Rayの長さ.
    [SerializeField] private float _rayLength = 1f;
    // Rayをどれくらい身体にめり込ませるか.
    [SerializeField] private float _rayOffset;
    // Rayの判定に用いるLayer.
    [SerializeField] private LayerMask _layerMask = default;

    private CharacterController _characterController;
    public bool _isGround;

    private void Awake()
    {
        if(_instance == null)
        {
            // 自身をインスタンス
            _instance = this;
        }
        else
        {
            // インスタンスが既に存在していたら自身を消去
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // CharacterControllerを取得
        _characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        // 接地判定
        _isGround = CheckGrounded();
    }

    public bool CheckGrounded()
    {
        // 放つ光線の初期位置と姿勢
        // 若干身体にめり込ませた位置から発射しないと正しく判定できないときがある
        var ray = new Ray(origin: transform.position + Vector3.up * _rayOffset, direction: Vector3.down);

        // Raycastがhitするかどうかで判定
        // レイヤの指定を忘れずに
        return Physics.Raycast(ray,_rayLength, _layerMask);
    }

    // Rayの可視化
    private void OnDrawGizmos()
    {
        // 設置判定時は緑、空中にいる時は赤にする
        Gizmos.color = _isGround ? Color.green : Color.red;
        Gizmos.DrawRay(transform.position + Vector3.up * _rayOffset, Vector3.down * _rayLength);
    }
}
