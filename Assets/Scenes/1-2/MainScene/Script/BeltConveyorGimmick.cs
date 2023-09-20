using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltConveyorGimmick : MonoBehaviour
{
    // ベルトコンベアが物体を動かす向き
    [SerializeField] private Vector3 _moveDirection = Vector3.forward;
    // ベルトコンベアの速度
    [SerializeField] private float _ConveyorSpeed;
    // コンベアに載っている物体の加速度
    [SerializeField] private float _forcePower;

    // ベルトコンベアの現在の速度
    [SerializeField] private float _CurrentSpeed { get { return _currentSpeed; } }

    private float _currentSpeed = 0;
    private List<Rigidbody> _rigidbodies = new List<Rigidbody>();

    // ベルトコンベアの稼働状況
    [SerializeField] private bool _isOn = false;

    // Start is called before the first frame update
    void Start()
    {
        // 方向を正規化する
        _moveDirection = _moveDirection.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _currentSpeed = _isOn ? _ConveyorSpeed : 0;

        // 消滅したオブジェクトは除去する
        _rigidbodies.RemoveAll(r => r == null);

        foreach(var r in _rigidbodies)
        {
            // 物体の移動速度のベルトコンベア方向の成分だけを取り出す
            var objectSpeed = Vector3.Dot(r.velocity, _moveDirection);

            // 目標値以下なら加速する
            if(objectSpeed < Mathf.Abs(_ConveyorSpeed))
            {
                r.AddForce(_moveDirection * _forcePower, ForceMode.Acceleration);
            }
        }
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
}
