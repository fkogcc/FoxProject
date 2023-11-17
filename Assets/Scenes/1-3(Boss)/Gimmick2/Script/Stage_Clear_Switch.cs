using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_Clear_Switch : MonoBehaviour
{
    void OnCollisionStay(Collision collision)
    {
        //プレイヤーが触れたとき.
        if (collision.gameObject.name == "3DPlayer")
        {
            //Xボタンを押したら.
            if (Input.GetKeyDown("joystick button 2"))
            {
                //ステージクリアの関数を呼ぶ
                GetResult();
            }
        }
    }

    //ステージクリアの関数
    public bool GetResult()
    {
        Debug.Log("クリア");
        return true;
    }
}
