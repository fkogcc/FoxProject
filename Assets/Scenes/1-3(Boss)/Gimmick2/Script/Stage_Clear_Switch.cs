using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_Clear_Switch : MonoBehaviour
{
    private bool _isClear;

    private void Start()
    {
        _isClear = false;
    }

    void OnCollisionStay(Collision collision)
    {
        //プレイヤーが触れたとき.
        if (collision.gameObject.name == "3DPlayer")
        {
            //Xボタンを押したら.
            if (Input.GetKeyDown("joystick button 2"))
            {
                //ステージクリアの関数を呼ぶ
                _isClear= true;
            }
        }
    }

    //ステージクリアの関数
    public bool GetResult()
    {
        return _isClear;
    }
}
