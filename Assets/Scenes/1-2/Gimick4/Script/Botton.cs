using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botton : MonoBehaviour
{
    // 押してるかどうかを渡す
    // トリガー判定用
    private bool _isTrigger { get; set; }
    // 現在ボタンを押しているかどうか
    private bool _isTriggerActive = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _isTrigger = false;
    }
 
    // Update is called once per frame
    void Update()
    {
        _isTrigger = false;
        // Bを押す
        if (Input.GetKey(KeyCode.JoystickButton1)) // B
        {
            if (!_isTriggerActive)
            {
                _isTriggerActive = true;
                _isTrigger = true;
            }
        }
        else
        {
            _isTriggerActive = false;
        }
    }
    public bool GetButtonB()
    {
        return _isTrigger;
    }
}
