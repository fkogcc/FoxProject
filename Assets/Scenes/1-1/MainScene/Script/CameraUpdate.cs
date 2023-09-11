using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUpdate : MonoBehaviour
{
    // 終着地点座標
    private Vector3 _targetPosition;
    
    private Vector3 _velocity = Vector3.zero;

    [SerializeField] private float _time = 1.0f;

    // プレイヤーのゲームオブジェクト
    private GameObject _targetPlayer;
    // カメラのポジション.
    private float _cameraPosX;
    private float _cameraPosY;
    private float _cameraPosZ;

    // Start is called before the first frame update
    void Start()
    {
        // 初期化
        _targetPlayer = GameObject.Find("Foxidle");

        // X,Y座標にプレイヤーの座標を代入
        _cameraPosX = _targetPlayer.transform.position.x;
        _cameraPosY = _targetPlayer.transform.position.y;
        _cameraPosZ = -20.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // カメラの追従
        // プレイヤーの座標を代入し続ける
        _cameraPosX = _targetPlayer.transform.position.x;
        _cameraPosY = _targetPlayer.transform.position.y;

        // 向いている方向によってカメラの位置を変更
        if (!Player2DMove._instance._isDirection)
        {
            _targetPosition = new Vector3(_cameraPosX + 7, (_cameraPosY / 5.0f) + 6.0f, -20.0f);
        }
        else
        {
            _targetPosition = new Vector3(_cameraPosX - 7, (_cameraPosY / 5.0f) + 6.0f, -20.0f);
        }

        MoveCamera();

        //DebugCameraPos();

    }

    // デバッグ用カメラポジション
    private void DebugCameraPos()
    {
        float playerPosX = _targetPlayer.transform.position.x;
        float playerPosY = _targetPlayer.transform.position.y;
        transform.position = new Vector3(playerPosX + 7, (playerPosY / 5.0f) + 6.0f, -20.0f);
    }

    // カメラの移動
    private void MoveCamera()
    {
        // 最初と最後はゆっくり途中は早くなる移動処理
        transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref _velocity, _time);
    }
}
