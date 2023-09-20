using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltConveyorGimmick : MonoBehaviour
{
    public static BeltConveyorGimmick _instance;

    // �x���g�R���x�A�����̂𓮂�������
    [SerializeField] private Vector3 _moveDirection = Vector3.forward;
    // �x���g�R���x�A�̑��x
    [SerializeField] private float _ConveyorSpeed;
    // �R���x�A�ɍڂ��Ă��镨�̂̉����x
    [SerializeField] private float _forcePower;

    // �x���g�R���x�A�̌��݂̑��x
    [SerializeField] private float _CurrentSpeed { get { return _currentSpeed; } }

    private float _currentSpeed = 0;
    private List<Rigidbody> _rigidbodies = new List<Rigidbody>();

    // �x���g�R���x�A�̉ғ���
    [SerializeField] private bool _isOn = false;


    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(_instance);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // �����𐳋K������
        _moveDirection = _moveDirection.normalized;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var rigidBody = collision.gameObject.GetComponent<Rigidbody>();
        _rigidbodies.Add(rigidBody);
    }

    private void OnCollisionExit(Collision collision)
    {
        var rigidBody = collision.gameObject.GetComponent<Rigidbody>();
        _rigidbodies.Remove(rigidBody);
    }

    /// <summary>
    /// �x���g�R���x�A�̍X�V����
    /// </summary>
    /// <param name="solve">�M�~�b�N�����������ǂ���</param>
    public void UpdateBeltConveyor(bool solve)
    {
        if (!solve) return;
        // ���ł����I�u�W�F�N�g�͏�������
        _rigidbodies.RemoveAll(r => r == null);

        foreach (var r in _rigidbodies)
        {
            // ���̂̈ړ����x�̃x���g�R���x�A�����̐������������o��
            var objectSpeed = Vector3.Dot(r.velocity, _moveDirection);

            // �ڕW�l�ȉ��Ȃ��������
            if (objectSpeed < Mathf.Abs(_ConveyorSpeed))
            {
                r.AddForce(_moveDirection * _forcePower, ForceMode.Acceleration);
            }
        }
    }
}
