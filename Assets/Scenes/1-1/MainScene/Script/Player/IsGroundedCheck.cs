using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGroundedCheck : MonoBehaviour
{
    public static IsGroundedCheck _instance;

    // ������n�ʂ܂ł�Ray�̒���
    [SerializeField] public float _rayLength = 1f;

    // �g�̂ɂ߂荞�܂���Ray�̒���
    [SerializeField] public float _rayOffset;

    // Ray�̔���ɗp����Layer
    [SerializeField] private LayerMask _layerMask = default;

    // ���`���ʉ݂��J�n����n�_�̒��S
    [SerializeField] private Vector3 _origin;
    // ���̔��a
    [SerializeField] private float _radius;
    // ����ʉ߂��������
    [SerializeField] private Vector3 _direction;
    // RayCast�ɂ����𓾂邽�߂̍\����
    RaycastHit _hitInfo;
    // �L���X�g�̒����̍ő�l
    [SerializeField] private float _maxDistance;

    // �n�ʂɐڒn���Ă��邩�ǂ���
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
        // Ray�̏����ʒu�Ǝp��
        Ray ray = new(origin: transform.position + Vector3.up * _rayOffset, direction: Vector3.down);

        // Ray���ڒn���邩�ǂ���
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
        // �f�o�b�O�\��
        // �ڒn
        // true ��
        // false ��
        Gizmos.color = _isGround ? Color.green : Color.red;
        Gizmos.DrawRay(transform.position + Vector3.up * _rayOffset, Vector3.down * _rayLength);
    }
}
