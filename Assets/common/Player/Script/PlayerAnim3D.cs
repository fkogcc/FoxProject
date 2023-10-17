// 3Dプレイヤーアニメーション.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim3D : MonoBehaviour
{
    public static PlayerAnim3D _instance;
    private void Awake()
    {
        if( _instance == null )
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //-------------------------------------------
    // アニメーション再生.
    // true: 再生.
    // false:再生しない.
    //-------------------------------------------

    // 移動.
    public bool Run()
    {
        // 垂直方向.
        float vertical = Input.GetAxis("Vertical");
        // 水平方向.
        float horizontal = Input.GetAxis("Horizontal");
        // スティックを傾けた.
        bool isStickTilt = vertical != 0 ||
            horizontal != 0;

        
        if(isStickTilt)
        {
            return true;
        }
        return false;
    }

    // ジャンプアニメーション.
    public bool Jump()
    {
        if(!IsGroundedCheck._instance._isGround)
        {
            return true;
        }
        return false;
    }

    // ゲームオーバーアニメーション.
    public bool GameOver()
    {
        //if (Player2DMove._instance._hp <= 0)
        //{
        //    return true;
        //}
        return false;
    }

}
