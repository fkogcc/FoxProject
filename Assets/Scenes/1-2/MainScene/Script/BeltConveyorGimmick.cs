// ベルトコンベアギミック

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltConveyorGimmick : MonoBehaviour
{
    private SolveGimmickManager _manager;

    // アニメーション.
    private Animator _animator;

    // マテリアルの取得.
    public Material _material;
    // テクスチャのスピード
    public Vector2 _textureSpeed = Vector2.zero;

    // ベルトコンベアが物体を動かす向き.
    [SerializeField] private Vector3 _moveDirection = Vector3.forward;
    // ベルトコンベアの速度.
    [SerializeField] private float _ConveyorSpeed;
    // コンベアに載っている物体の加速度.
    [SerializeField] private float _forcePower;

    // ベルトコンベアの現在の速度.
    [SerializeField] private float _CurrentSpeed { get { return _currentSpeed; } }

    private float _currentSpeed = 0;
    private List<Rigidbody> _rigidbodies = new List<Rigidbody>();

    // 作動時間.
    private int _operatingTime = 0;

    void Start()
    {
        _manager = GameObject.FindWithTag("GimmickManager").GetComponent<SolveGimmickManager>();

        // 方向を正規化する.
        _moveDirection = _moveDirection.normalized;

        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _material.SetTextureScale("_MainTex", _textureSpeed);
        

        if (_manager._solve[1])
        {
            UpdateBeltConveyor();
            _operatingTime++;
            _animator.SetFloat("AnimSpeed", 1.0f);
            _textureSpeed = new Vector2(5.0f, 0.0f);
        }
        else
        {
            _animator.SetFloat("AnimSpeed", 0.0f);
            _textureSpeed = new Vector2(0.0f, 0.0f);
        }

        if(_operatingTime >= 90)
        {
            _manager._solve[1] = false;
            _operatingTime = 0;
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

    /// <summary>
    /// ベルトコンベアの更新処理.
    /// </summary>
    public void UpdateBeltConveyor()
    {
        // 消滅したオブジェクトは除去する.
        _rigidbodies.RemoveAll(r => r == null);

        foreach (var r in _rigidbodies)
        {
            // 物体の移動速度のベルトコンベア方向の成分だけを取り出す.
            var objectSpeed = Vector3.Dot(r.velocity, _moveDirection);

            // 目標値以下なら加速する.
            if (objectSpeed < Mathf.Abs(_ConveyorSpeed))
            {
                r.AddForce(_moveDirection * _forcePower, ForceMode.Acceleration);
            }
        }
    }
}
