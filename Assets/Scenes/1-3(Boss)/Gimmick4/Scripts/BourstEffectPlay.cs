using UnityEngine;

// 爆発エフェクトの生成
public class BourstEffectPlay : MonoBehaviour
{
    // 爆発エフェクトの取得.
    [SerializeField, Header("爆発エフェクト")] private GameObject _bourst = default;
    // 扉の取得.
    private MoveWall _wall;
    // エフェクトの再生.
    private GameObject _effectBurst;
    // エフェクトの再生が終わったかどうか.
    private bool _isEffectNowPlay = false;

    // 初期化処理.
    void Start()
    {
        _wall = GameObject.Find("MoveWallDir").GetComponent<MoveWall>();
    }

    void Update()
    {
        BourstEffectCreate();
    }
    private void BourstEffectCreate()
    {
        // 壁がすべて降りて溶岩で満たしていたら.
        if (_wall.GetResult())
        {
            if (_effectBurst == null)
            {
                // エフェクトを生成.
                _effectBurst = Instantiate(_bourst, this.transform.position,
                                                        Quaternion.identity);
            }
            else
            {
                //  エフェクトの再生が終わっていたらclear判定にする.
                if (!_effectBurst.GetComponent<ParticleSystem>().isPlaying)
                {
                    // エフェクトの中身を全部消す.
                    Destroy(_effectBurst);
                    _isEffectNowPlay = true;
                }
            }
        }
    }
}
