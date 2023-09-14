using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botton : MonoBehaviour
{
    // 押してるかどうかを渡す
    // トリガー判定用
    public bool isTrigger { get; set; }

    // 現在ボタンを押しているかどうか
    private bool isTriggerActive = false;
    // Start is called before the first frame update
    void Start()
    {
        isTrigger = false;
    }
 
    // Update is called once per frame
    void Update()
    {
        isTrigger = false;
        if (Input.GetKey(KeyCode.JoystickButton1))
        {
            if (!isTriggerActive)
            {
                isTriggerActive = true;
                isTrigger = true;
            }
        }
        else
        {
            isTriggerActive = false;
        }

        if (isTrigger)
        {
            Debug.Log("押せてる");

        }
    }
    public bool GetButtonB()
    {
        return isTrigger;
    }
}
