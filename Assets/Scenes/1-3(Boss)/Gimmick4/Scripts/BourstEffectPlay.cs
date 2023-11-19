using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class BourstEffectPlay : MonoBehaviour
{
    [SerializeField] private GameObject _bourst = default;
    private MoveWall _wall;
    private GameObject _effectBurst;
    // エフェクトの再生が終わったかどうか
    private bool _isEffectNowPlay = false;
    // Start is called before the first frame update
    void Start()
    {
        _wall = GameObject.Find("MoveWallDir").GetComponent<MoveWall>();
        //// エフェクトを生成
        //_effectBurst = Instantiate(_bourst, this.transform.position,
        //                                        Quaternion.identity); // 初期化処理

    }

    // Update is called once per frame
    void Update()
    {
        if (_wall.GetResult())
        {
            if (_effectBurst == null)
            {
                // エフェクトを生成
                _effectBurst = Instantiate(_bourst, this.transform.position,
                                                        Quaternion.identity); // 初期化処理
            }
            else
            {
                //  エフェクトの再生が終わっていたらclear判定にする
                if (!_effectBurst.GetComponent<ParticleSystem>().isPlaying)
                {
                    // エフェクトの中身を全部消す.
                    Destroy(_effectBurst);
                    _isEffectNowPlay= true;
                }
            }
        }
    }
}
