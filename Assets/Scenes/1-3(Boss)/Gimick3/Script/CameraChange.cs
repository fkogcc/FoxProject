using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    // ボタンを押したかの状態.
    private bool _isPushFlag;
    public CinemachineVirtualCamera _monitorCameraObject;
    public CinemachineVirtualCamera _stage2CameraObject;
    public GameObject _player;
    Vector3 _pos;

    // Start is called before the first frame update
    void Start()
    {
        _isPushFlag = true;
        _player = GameObject.Find("3DPlayer");
    }

    private void Update()
    {
        //_player.transform.position = _pos;
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
        else if(Input.GetKeyDown("joystick button 2") & _pos.x <= 7.50f)
        {

        }
    }

    public void SetPushFlag(bool ispush)
    {
        _isPushFlag = ispush;
    }
}
