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
        //if (collision.gameObject.name == "3DPlayer")
        //{
        //    if(Input.GetKeyDown("joystick button 2"))
        //    {
        //        //ステージクリアの関数を呼ぶ
        //        _isClear= true;
        //    }                            
        //}
    }

    private void OnTriggerStay(Collider other)
    {
        //プレイヤーが触れたとき.
        if (other.gameObject.name == "3DPlayer")
        {
            Debug.Log("当たっている");
            if (Input.GetKeyDown("joystick button 2"))
            {
                // ステージクリアの関数を呼ぶ
                _isClear = true;

                Debug.Log(_isClear);
            }
            else
            {
                Debug.Log("押していない");
            }
        }
    }

    //ステージクリアの関数
    public bool GetResult()
    {
        return _isClear;
    }
}
