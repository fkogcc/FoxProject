// 爆発ギミックの処理

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionGimmick : MonoBehaviour
{
    private SolveGimmickManager _manager;

    [Header("火花のパーティクルオブジェクト")]
    [SerializeField] ParticleSystem _sparkParticle;
    [Header("爆風のパーティクルオブジェクト")]
    [SerializeField] ParticleSystem _blastParticle;

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

    [Header("爆発するまでの時間")]
    [SerializeField] private int _blastTime;

    // パーティクル再生時間
    private float _particleCount;

    // 爆発する座標
    Vector3 _ExplosionPosition;

    // 作動時間.
    private int _operatingTime = 0;
    // 作動終了時間
    private int _operatingFinish = 180;


    private void Start()
    {
        _manager = GameObject.FindWithTag("GimmickManager").GetComponent<SolveGimmickManager>();
        //_particleSystem.Stop();
        _sparkParticle.Stop();
        _blastParticle.Stop();
    }

    private void FixedUpdate()
    {
        if (_manager._solve[2])
        {
            _operatingTime++;
            _sparkParticle.Play();
        }

        if(_operatingTime > _blastTime)
        {
            UpdateExplosion();
        }

        if(_operatingTime >= _operatingFinish)
        {
            _manager._solve[2] = false;
            _operatingTime = 0;
        }
    }


    /// <summary>
    /// 爆発処理
    /// </summary>
    public void UpdateExplosion()
    {
        // パーティクル再生.
        _sparkParticle.Play();
        // パーティクル座標を代入.
        _ExplosionPosition = transform.position;

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
        //if(_particleCount < _particleMaxCount)
        //{
        //    _particleCount++;
        //}
        //// 時間がたつとパーティクル再生終了.
        //if(_particleCount == _particleMaxCount )
        //{
        //    // パーティクル再生終了.
        //    _sparkParticle.Stop();
        //}



        _bombObject.SetActive(false);
        //Destroy(gameObject);
    }
}
