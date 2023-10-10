using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MonitorCamera : MonoBehaviour
{
    // ボタンを押したかの状態.
    private bool _isPushFlag;
    // ゲームオブジェクトを取得する
    public GameObject _monitorCameraObject;
    public GameObject _playerObject;
    public GameObject _handObject;
    public CinemachineVirtualCamera vcamera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ボタンの状態によって分岐させる.
        if (_isPushFlag)
        {
            // モニター前のカメラをオンにする
            //_monitorCameraObject.gameObject.SetActive(true);
            vcamera.Priority = 15;
            // プレイヤーを非表示にする
            _playerObject.gameObject.SetActive(false);
            // プレイヤーの手を表示する
            _handObject.gameObject.SetActive(true);
        }
        else
        {
            // モニター前のカメラをオフにする
            //_monitorCameraObject.gameObject.SetActive(false);
            vcamera.Priority = 5;
            _playerObject.gameObject.SetActive(true);
            _handObject.gameObject.SetActive(false);
        }
    }

    public void SetPushFlag(bool ispush)
    {
        _isPushFlag = ispush;  
    }
    void FixedUpdate()
    {

    }
}
