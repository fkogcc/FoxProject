using UnityEngine;

public class Gimick1_2_1Manager : MonoBehaviour
{
    private GameObject _handObject;

    private GameObject _monitorObject;
    private GameObject _effect;
    // Start is called before the first frame update
    void Start()
    {
        _monitorObject = GameObject.Find("MonitorCamera");
        _effect = GameObject.Find("EffectCreate");
        

    }

    // Update is called once per frame
    void Update()
    {
        _handObject = GameObject.Find("FoxHand(Clone)");
        
        // モニターを変えるかどうかをチェックしている
        this.GetComponent<ObjectManagement>().MonitorChenge();
        // カメラのUpdate
        _monitorObject.GetComponent<Test>().CameraUpdate();
        if (_handObject != null)
        {
            // プレイヤーの手がボタンを押したかどうか
            if (_handObject.activeInHierarchy)
            {
                _handObject.GetComponent<PlayerHand>().ButtonPush();
                
            }
            this.GetComponent<ButtonState>().GetPlayerObject(_handObject);
            // ボタンの状態
            this.GetComponent<ButtonState>().ButtonAcquisition();

            _effect.GetComponent<EffectPlay>().GetPlayerObject(_handObject);
            _effect.GetComponent<EffectPlay>().CheckTap(this.GetComponent<ButtonState>().isCheckButton());
            _effect.GetComponent<EffectPlay>().EffectDestory(GetComponent<ButtonState>().IsResetFlag());
        }
    }
    void FixedUpdate()
    {
        if (_handObject != null)
        {
            // プレイヤーの手の移動処理
            _handObject.GetComponent<PlayerHand>().MovePlayerHand();
        }
    }
    public GameObject SetHandObject()
    {
        return _handObject;
    }
}
