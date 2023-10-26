using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionGimmick : MonoBehaviour
{
    private SolveGimmickManager _manager;

    [Header("パーティクルオブジェクト")]
    [SerializeField] ParticleSystem _particleSystem;

    [Header("爆発オブジェクト")]
    [SerializeField] GameObject _bombObject;

    [Header("爆発する力")]
    [SerializeField] private float _force;

    [Header("爆発範囲の半径")]
    [SerializeField] private float _radius;

    [Header("上に飛ばされる力")]
    [SerializeField] private float _upwardsPower;

    [Header("パーティクルの最大再生時間")]
    [SerializeField] private float _particleMaxCount;

    // パーティクル再生時間
    private float _particleCount;

    // 爆発する座標
    Vector3 _ExplosionPosition;

    private void Start()
    {
        _manager = GameObject.Find("SceneManager").GetComponent<SolveGimmickManager>();
    }

    private void FixedUpdate()
    {
        if (_manager._solve[2])
        {
            UpdateExplosion();
        }
    }


    /// <summary>
    /// 爆発処理
    /// </summary>
    public void UpdateExplosion()
    {
        // パーティクル再生.
        _particleSystem.Play();
        // パーティクル座標を代入.
        _ExplosionPosition = _particleSystem.transform.position;

        // 範囲内のRigidbodyにAddExplosionForce.
        // 後でコメント変更.
        Collider[] hitColliders = Physics.OverlapSphere(_ExplosionPosition, _radius);
        for(int i = 0; i < hitColliders.Length; i++)
        {
            Rigidbody rigidbody = hitColliders[i].GetComponent<Rigidbody>();

            // 範囲内にいるRigidbodyを持つオブジェクトを吹き飛ばす.
            if(rigidbody)
            {
                rigidbody.AddExplosionForce(_force, _ExplosionPosition, _radius, _upwardsPower, ForceMode.Impulse);
            }
        }

        // 再生している時間.
        if(_particleCount < _particleMaxCount)
        {
            _particleCount++;
        }
        // 時間がたつとパーティクル再生終了.
        if(_particleCount == _particleMaxCount )
        {
            // パーティクル再生終了.
            _particleSystem.Stop();
        }

        _bombObject.SetActive(false);
    }
}
