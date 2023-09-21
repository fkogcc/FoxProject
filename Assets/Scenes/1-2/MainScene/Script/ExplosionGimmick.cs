using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionGimmick : MonoBehaviour
{
    public static ExplosionGimmick _instance;

    // パーティクルオブジェクト
    [SerializeField] ParticleSystem _particleSystem;

    // 爆弾オブジェクト
    [SerializeField] GameObject _bombObject;

    // 爆発の与える力
    [SerializeField] private float _force;

    // 爆発範囲の半径
    [SerializeField] private float _radius;

    // 上に飛ばされる力
    [SerializeField] private float _upwardsPower;

    // パーティクルの最大再生時間
    [SerializeField] private float _particleMaxCount;

    // パーティクル再生時間
    private float _particleCount;

    // 爆発する座標
    Vector3 _ExplosionPosition;

    private void Awake()
    {
        // シングルトンの呪文
        if( _instance == null )
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _particleSystem.Stop();
    }

    /// <summary>
    /// 爆発処理
    /// </summary>
    /// <param name="solve">ギミックを解いたかどうか</param>
    public void UpdateExplosion(bool solve)
    {
        if(!solve) return;

        // パーティクル再生
        _particleSystem.Play();
        // パーティクル座標を代入
        _ExplosionPosition = _particleSystem.transform.position;

        // 範囲内のRigidbodyにAddExplosionForce
        // 後でコメント変更
        Collider[] hitColliders = Physics.OverlapSphere(_ExplosionPosition, _radius);
        for(int i = 0; i < hitColliders.Length; i++)
        {
            Rigidbody rigidbody = hitColliders[i].GetComponent<Rigidbody>();

            // 範囲内にいるRigidbodyを持つオブジェクトを吹き飛ばす
            if(rigidbody)
            {
                rigidbody.AddExplosionForce(_force, _ExplosionPosition, _radius, _upwardsPower, ForceMode.Impulse);
            }
        }

        // 再生している時間
        if(_particleCount < _particleMaxCount)
        {
            _particleCount++;
        }
        // 時間がたつとパーティクル再生終了
        if(_particleCount == _particleMaxCount )
        {
            // パーティクル再生終了
            _particleSystem.Stop();
        }


        

        _bombObject.SetActive(false);
    }
}
