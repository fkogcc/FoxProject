using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimick1_1_2_Manager : MonoBehaviour
{
    // 回転させるオブジェクトの取得.
    private GearRotation _gear;
    // サウンドの取得.
    [SerializeField] private SoundManager _sound;
    // クリアしたときにclearの画像を表示させる.
    [SerializeField] private GenerateImg _img;
    // 一回転したら時間を計測するためのタイマー.
    private int _coutnTime;
    private float _timer = 0;
    // タイマーが指定した時間に達したかのフラグ.
    private bool _isTimeFlag;
    // 一回転したかどうかのフラグ.
    private bool _isRotaFlag;
    private void Start()
    {
        _gear = GameObject.Find("GearHandle").GetComponent<GearRotation>();
        //_img = GetComponent<GenerateImg>();
        _sound.PlayBGM("1_1_2_BGM");
        _coutnTime = 60 * 2;

    }

    // 60フレームに一回の更新処理.
    private void FixedUpdate()
    {
        // ギアを回転させる.
        _gear.GearRotate();
        // 一回転していたら時間を計測する.
        TimeCount();
    }
    // 更新処理.
    private void Update()
    {
        _gear.PlayerColRange();
        _isRotaFlag = _gear.IsGearRotated();
    }
    // クリアしていたら少し時間をおいてから処理をするための関数.
    private void TimeCount()
    {
        // 一回転していたら.
        if (_isRotaFlag)
        {
            // タイマーをカウントさせる.
            _timer++;

            if (_timer > _coutnTime)
            {
                _isTimeFlag = true;
            }
        }
    }
    // シーン移行するための関数.
    public bool GetResult()
    {
        // 一回転していたら
        if (_isRotaFlag)
        {
            // 画像の表示.
            _img.GenerateImage();
        }
        //指定した時間がたったらBGMをストップさせる.
        if (_isTimeFlag)
        {
            // BGMをストップさせる.
            _sound.StopBgm();
        }
        // 指定した時間がたっていたらフェード処理をさせる.
        return _isTimeFlag;
    }
}
