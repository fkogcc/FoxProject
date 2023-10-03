using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGroundedCheck : MonoBehaviour
{
    public static IsGroundedCheck _instance;

    // ������n�ʂ܂ł�Ray�̒���.
    //[SerializeField] private float _rayLength = 1.0f;

    // �g�̂ɂ߂荞�܂���Ray�̒���.
    [SerializeField] private float _rayOffset;

    // �~��Ray�̒���
    [SerializeField] private float _raySphereLength = 0.1f;

    // �~��y���W����
    [SerializeField] private float _SphereCastRegulationY = 0;

    // Ray�̔���ɗp����Layer.
    //[SerializeField] private LayerMask _layerMask = default;

    // SphereCast�̒��S���W
    private Vector3 _SphereCastCenterPosition = Vector3.zero;

    // �n�ʂɐڒn���Ă��邩�ǂ���.
    public bool _isGround;

    // ���C
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
        _SphereCastCenterPosition = new Vector3(transform.position.x, transform.position.y + _SphereCastRegulationY, transform.position.z);

        _isGround = CheckGrounded();
    }

    private bool CheckGrounded()
    {
        // Ray�̏����ʒu�Ǝp��.
        Ray ray = new(origin: transform.position + Vector3.up * _rayOffset, direction: Vector3.down);

        // �~�L���X�g.
        Physics.SphereCast(_SphereCastCenterPosition, _raySphereLength, -transform.up, out hit);

        // �ڒn�����ɂ����true.
        if (hit.distance <= 0.1f && hit.distance != 0.0f)
        {
            return true;
        }

        // Ray���ڒn���邩�ǂ���.
        // �~
        return false;
        // ��
        //return Physics.Raycast(ray, _rayLength, _layerMask);

        //return Physics.SphereCast(transform.position, 0.1f, -transform.up, out hit);
    }

    private void OnDrawGizmos()
    {
        // �f�o�b�O�\��.
        // �ڒn.
        // true ��.
        // false ��.
        Gizmos.color = _isGround ? Color.green : Color.red;
        //Gizmos.DrawRay(transform.position + Vector3.up * _rayOffset, Vector3.down * _rayLength);
        //Gizmos.DrawWireSphere(transform.position, 0.1f);
        Gizmos.DrawWireSphere(_SphereCastCenterPosition + -transform.up * (hit.distance), _raySphereLength);
    }
}
