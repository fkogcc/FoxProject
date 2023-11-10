using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MonitorCamera : MonoBehaviour
{
    // Hack 毎回新しいのを作る
    [SerializeField] private GameObject PlayerHand = default;
    // ボタンを押したかの状態.
    private bool _isPushFlag;
    // ゲームオブジェクトを取得する
    public GameObject _monitorCameraObject;
    public GameObject _playerObject;
    private GameObject _handObject;
    public CinemachineVirtualCamera _vcamera;

    // Start is called before the first frame update
    void Start()
    {
        _handObject = Instantiate(PlayerHand,
                    this.transform.position,
                    Quaternion.identity) as GameObject;
    }

    public void MonitorChenge()
    {
        // ボタンの状態によって分岐させる.
        if (_isPushFlag)
        {
            // モニター前のカメラをオンにする
            //_monitorCameraObject.gameObject.SetActive(true);
            _vcamera.Priority = 15;
            // プレイヤーを非表示にする
            _playerObject.gameObject.SetActive(false);
            // プレイヤーの手を表示する
            _handObject.gameObject.SetActive(true);

            //if (_handObject == null)
            //{
            //    // テスト
            //    _handObject = Instantiate(PlayerHand,
            //            this.transform.position,
            //            Quaternion.identity) as GameObject;
            //}
        }
        else
        {
            // モニター前のカメラをオフにする
            //_monitorCameraObject.gameObject.SetActive(false);
            _vcamera.Priority = 5;
            _playerObject.gameObject.SetActive(true);
            _handObject.gameObject.SetActive(false);

            //if (_handObject != null)
            //{
            //    Destroy(_handObject);
            //}
        }
    }

    public void SetPushFlag(bool ispush)
    {
        _isPushFlag = ispush;  
    }
}
