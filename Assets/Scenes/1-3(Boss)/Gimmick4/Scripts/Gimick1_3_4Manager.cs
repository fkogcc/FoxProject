﻿using UnityEngine;

public class Gimick1_3_4Manager : MonoBehaviour
{
    // 動く壁の取得.
    [SerializeField] private GameObject _wall;
    private MoveWall _moveWall;
    // ロープの取得.
    [SerializeField] private GameObject _rope;
    private PullRope _pullRope;
    // マネージャーの取得.
    [SerializeField] private GameObject _gameObj;
    // カメラの取得.
    private CameraShake _cameraShake;
    // エフェクトの取得.
    private BourstEffectPlay _effect;
    // 機械の取得.
    [SerializeField] private GameObject _machine;
    private MachineDestory _machineObject;
    // 壁のフラグを入れる用の変数.
    private bool _isWallFlag = false;
    // カメラをもとに戻すフラグを入れる
    private bool _isUndo = false;
    // サウンドの取得
    [SerializeField] private SoundManager _sound;
    // Start is called before the first frame update
     private void Start()
    {
        _moveWall = _wall.GetComponent<MoveWall>();
        _pullRope = _rope.GetComponent<PullRope>();
        _effect = _gameObj.GetComponent<BourstEffectPlay>();
        _cameraShake = _gameObj.GetComponent<CameraShake>();
        _machineObject = _machine.GetComponent<MachineDestory>();
        _sound.PlayBGM("1_3_4_BGM");

    }

    // Update is called once per frame
    private void Update()
    {
        // ロープの更新処理.
        _pullRope.PullRopeUpdate();
        // 壁の更新処理.
        _moveWall.WallUpdate(_pullRope,_sound);
        // フラグの取得.
        _isWallFlag =_moveWall.GetFlawFlag();
        _isUndo = _effect.IsEffectPlay();
        // 機械を壊すかどうか.
        if (_machine != null)
        {
            _machineObject.ObjectDestory(_isWallFlag);
        }
        // エフェクトの生成
        _effect.BourstEffectCreate(_isWallFlag,_sound);
        // カメラを揺らすかどうか.
        _cameraShake.ShekeUpdate(_isWallFlag);
        // カメラをもとに戻す.
        _cameraShake.CameraUndo(_isUndo);

    }

    private void FixedUpdate()
    {
        _pullRope.PlacementUpdate();
    }
    public void FallSEPlay()
    {
        _sound.PlaySE("1_3_4_Fall");
    }
    public bool GetResult()
    {
        if(_isUndo)
        {
            _sound.StopBgm();
        }
        return _isUndo;
    }
}