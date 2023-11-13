using UnityEngine;
using Cinemachine;
using System;

public class ObjectManagement : MonoBehaviour
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

    // 追従対象情報
    [Serializable]
    public struct TargetInfo
    {
        // 追従対象
        public Transform name;
        // Test
        public Transform hand;
    }

    // 追従対象リスト
    [SerializeField] private TargetInfo[] _targetList;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerHandGenerate();
        //_handObject = PlayerHand;
    }

    public void MonitorChenge()
    {
        // ボタンの状態によって分岐させる.
        if (_isPushFlag)
        {
            // モニター前のカメラをオンにする
            _vcamera.Priority = 15;
            // プレイヤーを非表示にする
            _playerObject.gameObject.SetActive(false);
            // プレイヤーの手を表示する
            //_handObject.gameObject.SetActive(true);
        }
        else
        {
            // モニター前のカメラをオフにする
            _vcamera.Priority = 5;
            _playerObject.gameObject.SetActive(true);
            //_handObject.gameObject.SetActive(false);
        }
    }
    public void PlayerHandGenerate(string name)
    {
        if (_handObject == null)
        {
            // HACK とりあえず動きはするけどめっちゃ乱雑コードの出来上がり
            for (int i = 0; i < _targetList.Length; i++)
            {
                if (_targetList[i].name.name == name)
                {
                    var info = _targetList[i];
                    _handObject = Instantiate(PlayerHand,
                        info.hand.transform.position,
                        info.hand.transform.rotation) as GameObject;
                }
            }
        }
    }
    public void PlayerHandDestory()
    {
        if (_handObject != null)
        {
            Destroy(_handObject);
        }
    }
    public void SetPushFlag(bool ispush)
    {
        _isPushFlag = ispush;  
    }
}
