// 2Dカメラ処理.
// HACK:マジックナンバーが残っているので何とかする.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUpdate : MonoBehaviour
{
    // カメラが追う座標.
    private Vector3 _targetPosition;
    // カメラの速度
    private Vector3 _velocity = Vector3.zero;
    // カメラが追う座標に向かう時間.
    [SerializeField] private float _time = 0.2f;

    // プレイヤーのゲームオブジェクト.
    private GameObject _targetPlayer;
    // カメラのポジション.
    private float _cameraPosX;
    private float _cameraPosY;
    private float _cameraPosZ;

    // Start is called before the first frame update
    void Start()
    {
        _targetPlayer = GameObject.Find("Foxidle");

        // X,Y座標にプレイヤーの座標を代入
        _cameraPosX = _targetPlayer.transform.position.x;
        _cameraPosY = _targetPlayer.transform.position.y;

        _cameraPosZ = -20.0f;
    }

    private void FixedUpdate()
    {
        // カメラの追従.
        // プレイヤーの座標を代入し続ける.
        _cameraPosX = _targetPlayer.transform.position.x;
        _cameraPosY = _targetPlayer.transform.position.y;

        // 向いている方向によってカメラの位置を変更.
        if (!Player2DMove._instance._isDirection)
        {
            _targetPosition = new Vector3(_cameraPosX + 7, (_cameraPosY / 5.0f) + 6.0f, _cameraPosZ);
        }
        else
        {
            _targetPosition = new Vector3(_cameraPosX - 7, (_cameraPosY / 5.0f) + 6.0f, _cameraPosZ);
        }

        // ステージ端に来たらカメラの固定.
        if(transform.position.x <= 0.0f || transform.position.x >= 160.0f)
        {
            transform.position = new Vector3(0, (_cameraPosY / 5.0f) + 6.0f, -20.0f);
        }
        

        MoveCamera();


    }

    // デバッグ用カメラポジション.
    private void DebugCameraPos()
    {
        float playerPosX = _targetPlayer.transform.position.x;
        float playerPosY = _targetPlayer.transform.position.y;
        transform.position = new Vector3(playerPosX + 7, (playerPosY / 5.0f) + 6.0f, _cameraPosZ);
    }

    // カメラの移動.
    private void MoveCamera()
    {
        // 移動.
        transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref _velocity, _time);
    }
}
