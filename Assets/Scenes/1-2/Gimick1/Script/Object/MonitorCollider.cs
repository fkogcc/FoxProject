using UnityEngine;
// モニターの更新スクリプト.
public class MonitorCollider : MonoBehaviour
{
    // プレイヤーが範囲内にいるかどうか.
    private bool _isPlayerCollider;
    // ボタンを押されたかどうか.
    private bool _isPushButton;
    // ボタンの状態を渡すためにオブジェクトを取得.
    private ObjectManagement _gameManager;

    private MonitorCamera _monitorObject;
    // どこのモニターを見ているかを保存する変数.
    private string _name;

    void Start()
    {
        // 初期化処理.
        _isPlayerCollider = false;
        _isPushButton = false;

        // オブジェクトを取得.
        _gameManager = GameObject.Find("GameManager").GetComponent<ObjectManagement>();
        _monitorObject = GameObject.Find("MonitorCamera").GetComponent<MonitorCamera>();
    }

    void Update()
    {
        CameraFlag();
    }
    // カメラを切り替える処理
    public void CameraFlag()
    {
        // プレイヤーが判定内にいるとき.
        if (_isPlayerCollider)
        {
            // Aボタンを押したら.
            if (Input.GetKeyDown("joystick button 1"))
            {
                // ボタンのフラグをオンにする(カメラON).
                _isPushButton = true;
                _name = this.transform.name;
                _gameManager.PlayerHandGenerate(_name);
            }
            // Xボタンを押したら.
            else if (Input.GetKeyDown("joystick button 0"))
            {
                // ボタンのフラグをオフにする(カメラOFF).
                _isPushButton = false;
                _name = null;
                _gameManager.PlayerHandDestory();

            }
            _monitorObject.SetCameraName(_name);
            _gameManager.SetPushFlag(_isPushButton);
        }
    }

    // 当たり判定の処理
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // プレイヤーがコライダーに入ったとき.
            _isPlayerCollider = true;

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            // プレイヤーがコライダーから出たとき.
            _isPlayerCollider = false;
            // おされた場所のモニターがどこかを保存する.
            _name = null;

        }
    }
}
