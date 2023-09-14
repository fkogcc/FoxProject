using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorCamera : MonoBehaviour
{
    // ボタンを押したかの状態.
    public bool _isPushFlag;
    public GameObject _monitorCameraObject;
    public GameObject _playerObject;
    public GameObject _HandObject;

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
            _monitorCameraObject.gameObject.SetActive(true);
            _playerObject.gameObject.SetActive(false);
            _HandObject.gameObject.SetActive(true);
        }
        else
        {
            // モニター前のカメラをオフにする
            _monitorCameraObject.gameObject.SetActive(false);
            _playerObject.gameObject.SetActive(true);
            _HandObject.gameObject.SetActive(false);
        }
    }
    void FixedUpdate()
    {

    }
}
