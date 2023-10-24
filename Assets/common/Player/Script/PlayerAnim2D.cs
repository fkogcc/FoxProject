// 2Dアニメーション

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim2D : MonoBehaviour
{
    private float _horizontal = 0;

    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
    }

    //-------------------------------------------
    // アニメーション再生.
    // true: 再生.
    // false:再生しない.
    //-------------------------------------------

    // アイドル状態.
    public bool Idle()
    {
        if(_horizontal == 0 && !Player2DMove._instance.GetIsJumpNow() &&
            Player2DMove._instance.GetHp() != 0)
        {
            return true;
        }

        return false;
    }

    // 移動.
    public bool Run()
    {
        if(_horizontal != 0)
        {
            return true;
        }

        return false;
    }

    // ジャンプアニメーション.
    public bool Jump()
    {
        if (Player2DMove._instance.GetIsJumpNow())
        {
            return true;
        }

        return false;
    }

    // ゲームオーバーアニメーション.
    public bool GameOver()
    {
        if(Player2DMove._instance.GetHp() <= 0)
        {
            return true;
        }

        return false;
    }
}
