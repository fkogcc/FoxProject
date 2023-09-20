using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionGimmick : MonoBehaviour
{
    ExplosionGimmick _instance;

    [Header("爆風に当たった時に吹っ飛ぶ力の強さ")]
    [SerializeField] private float _blastPower;

    [Header("爆風の判定が発生するディレイ")]
    [SerializeField] private float _startBlast;

    [Header("爆風の持続フレーム")]
    [SerializeField] private int _durationFrame;

    [Header("エフェクト含めたすべての再生が終了するまでの時間")]
    [SerializeField] private float _endEffectTime;

    // パーティクルオブジェクト
    [Header("爆発するパーティクルオブジェクト代入")]
    [SerializeField] private ParticleSystem _effect;

    // 丸の当たり判定
    [Header("球の当たり判定")]
    [SerializeField] private SphereCollider _collider;

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

        _effect.Stop();
        _collider.enabled = false;
    }

    // 爆発する
    public void Explode()
    {
        // 当たり判定管理のコルーチン
    }
}
