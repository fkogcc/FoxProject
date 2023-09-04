using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGroundedCheck : MonoBehaviour
{
    IsGroundedCheck _instance;

    // ������n�ʂ܂ł�Ray�̒���
    [SerializeField] private float _rayLength = 1f;

    // �g�̂ɂ߂荞�܂���Ray�̒���
    [SerializeField] private float _rayOffset;

    // Ray�̔���ɗp����Layer
    [SerializeField] private LayerMask _layerMask = default;

    // �n�ʂɐڒn���Ă��邩�ǂ���
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
        // �f�o�b�O�\��
        // �ڒn
        // true ��
        // false ��
        Gizmos.color = _isGround ? Color.green : Color.red;
        Gizmos.DrawRay(transform.position + Vector3.up * _rayOffset, Vector3.down * _rayLength);
    }
}
