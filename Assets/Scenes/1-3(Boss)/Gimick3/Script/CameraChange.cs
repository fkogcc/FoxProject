using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    // ボタンを押したかの状態.
    private bool _isPushFlag;
    public CinemachineVirtualCamera _monitorCameraObject;


    // Start is called before the first frame update
    void Start()
    {
        _isPushFlag = true;
    }

    private void Update()
    {
        // ボタンの状態によって分岐させる.
        if (_isPushFlag)
        {            
            // カメラを動かす.
            _monitorCameraObject.Priority = 3;
        }
        else
        {            
            // カメラを動かす.
            _monitorCameraObject.Priority = 15;
        }
        if (Input.GetKeyDown("joystick button 2"))
        {
            _isPushFlag = !_isPushFlag;
        }
    }

    public void SetPushFlag(bool ispush)
    {
        _isPushFlag = ispush;
    }
}
