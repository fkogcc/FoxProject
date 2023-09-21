using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlePos : MonoBehaviour
{
    // プレイヤー
    GameObject _player;
    // ハンドルの差し込み口
    GameObject _handleWall;
    // ハンドルの回転フレームを測る
    private int _rotaFrameHandle = 0;
    // Start is called before the first frame update
    void Start()
    {
        // プレイヤー
        _player     = GameObject.Find("3DPlayer");
        // ハンドルの差し込み口
        _handleWall = GameObject.Find("HandleWall0");

    }
    // ハンドルの位置をプレイヤーの位置にします

    // ハンドルをプレイヤーの位置に移動
    public void HandlePosIsPlayer()
    {
        Vector3 pos;
        pos.x = _player.transform.position.x;
        pos.y = _player.transform.position.y + 3.3f;
        pos.z = _player.transform.position.z;
        this.transform.position = pos;
    }

    // ハンドルを差し込み位置に移動
    public void HandlePosIsHandleWall()
    {
        Vector3 pos;
        pos.x = _handleWall.transform.position.x;
        pos.y = _handleWall.transform.position.y;
        pos.z = _handleWall.transform.position.z - 0.4f;
        this.transform.position = pos;
    }

    // ハンドルの回転
    public void Rota(float speed)
    {
        this.transform.Rotate(0, 0, speed);
        _rotaFrameHandle++;
    }

    public bool IsGetRotaTimeOver(int frame)
    {
        if(_rotaFrameHandle > frame)
        {
            return true;
        }

        return false;
    }
}
