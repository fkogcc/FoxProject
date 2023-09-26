// プレイヤーアニメーション

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    public static PlayerAnim _instance;
    private void Awake()
    {
        if( _instance == null )
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // 移動アニメーション
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
}
