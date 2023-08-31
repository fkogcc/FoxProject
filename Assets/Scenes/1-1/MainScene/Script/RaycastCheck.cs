using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastCheck : MonoBehaviour
{
    // �C���X�^���X.
    public static RaycastCheck _instance;

    // �ȉ�Inspector�ŃA�N�Z�X��
    // Ray�̒���.
    [SerializeField] private float _rayLength = 1f;
    // Ray���ǂꂭ�炢�g�̂ɂ߂荞�܂��邩.
    [SerializeField] private float _rayOffset;
    // Ray�̔���ɗp����Layer.
    [SerializeField] private LayerMask _layerMask = default;

    private CharacterController _characterController;
    public bool _isGround;

    private void Awake()
    {
        if(_instance == null)
        {
            // ���g���C���X�^���X
            _instance = this;
        }
        else
        {
            // �C���X�^���X�����ɑ��݂��Ă����玩�g������
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // CharacterController���擾
        _characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        // �ڒn����
        _isGround = CheckGrounded();
    }

    public bool CheckGrounded()
    {
        // �������̏����ʒu�Ǝp��
        // �኱�g�̂ɂ߂荞�܂����ʒu���甭�˂��Ȃ��Ɛ���������ł��Ȃ��Ƃ�������
        var ray = new Ray(origin: transform.position + Vector3.up * _rayOffset, direction: Vector3.down);

        // Raycast��hit���邩�ǂ����Ŕ���
        // ���C���̎w���Y�ꂸ��
        return Physics.Raycast(ray,_rayLength, _layerMask);
    }

    // Ray�̉���
    private void OnDrawGizmos()
    {
        // �ݒu���莞�͗΁A�󒆂ɂ��鎞�͐Ԃɂ���
        Gizmos.color = _isGround ? Color.green : Color.red;
        Gizmos.DrawRay(transform.position + Vector3.up * _rayOffset, Vector3.down * _rayLength);
    }
}
