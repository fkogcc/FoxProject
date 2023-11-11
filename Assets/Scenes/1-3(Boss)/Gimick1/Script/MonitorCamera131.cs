using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorCamera131 : MonoBehaviour
{
    // ボタンを押したかの状態.
    private bool _isPushFlag;
    // ゲームオブジェクトを取得する
    public GameObject _vcamera;
    public GameObject _playerObject;
    public GameObject _monitorCameraObject;
    public GameObject _handObject;

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
            // 通常状態での動作関係をActiveに
            _vcamera.gameObject.SetActive(true);
            _playerObject.gameObject.SetActive(true);
            // 絵合わせ状態での動作関係をNonActiveに
            _monitorCameraObject.gameObject.SetActive(false);
            _handObject.gameObject.SetActive(false);
        }
        else
        {
            // 通常状態での動作関係をNonActiveに
            _vcamera.gameObject.SetActive(false);
            _playerObject.gameObject.SetActive(false);
            // 絵合わせ状態での動作関係をActiveに
            _monitorCameraObject.gameObject.SetActive(true);
            _handObject.gameObject.SetActive(true);
        }
    }

    public void SetPushFlag(bool ispush)
    {
        _isPushFlag = ispush;
        Debug.Log("呼ばれた");
        Debug.Log(_isPushFlag);

    }
}
