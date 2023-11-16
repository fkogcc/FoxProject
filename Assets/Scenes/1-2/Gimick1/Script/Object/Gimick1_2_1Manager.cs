using UnityEngine;

public class Gimick1_2_1Manager : MonoBehaviour
{
    private GameObject _handObject;
    private PlayerHand _playerHand;
    private GameObject _cameraObject;
    private Test _test;
    private ObjectManagement _objectManagement;

    [SerializeField] private GameObject[] _panelObject;
    private ButtonState[] _buttonState;
    private GameObject _effect;
    private EffectPlay _effectPlay;

    private string _prevFrameName = null;
    private string _nowFrameName = null;
    // Start is called before the first frame update
    void Start()
    {
        _cameraObject = GameObject.Find("MonitorCamera");

        _test = _cameraObject.GetComponent<Test>();
        _objectManagement = GetComponent<ObjectManagement>();

        _buttonState = new ButtonState[_panelObject.Length];
        for (int i = 0; i < _buttonState.Length; i++)
        {
            _buttonState[i] = _panelObject[i].GetComponent<ButtonState>();
        }
        _effect = GameObject.Find("EffectCreate");
        _effectPlay = _effect.GetComponent<EffectPlay>();
        _effectPlay.EffectInit();
    }

    // Update is called once per frame
    void Update()
    {
        _handObject = GameObject.Find("FoxHand(Clone)");
        // モニターを変えるかどうかをチェックしている
        _objectManagement.MonitorChenge();
        // カメラのUpdate
        _test.CameraUpdate();
        if (_handObject != null)
        {
            // プレイヤーの手がボタンを押したかどうか
            if (_handObject.activeInHierarchy)
            {
                _handObject.GetComponent<PlayerHand>().ButtonPush();
                
            }
            _nowFrameName = _test.GetCameraName();
            //foreach (GameObject panel in _panelObject)
            foreach (ButtonState button in _buttonState)
            {
                if (button.name == _test.GetCameraName())
                {
                    //_buttonState = panel.GetComponent<ButtonState>();
                    button.GetPlayerObject(_handObject);
                    // ボタンの状態
                    button.ButtonAcquisition();

                    _effectPlay.GetPanelName(button.transform.name);
                    _effectPlay.GetPlayerObject(_handObject);
                    _effectPlay.CheckTap(button.isCheckButton());
                    _effectPlay.EffectClearGenerete(button.IsGimckClear());
                    _effectPlay.EffectDestory(button.IsResetFlag());
                }
                if (_prevFrameName != _nowFrameName)
                {
                    button.ButtnReset();
                    _effectPlay.EffectPosReset();
                }
            }
            _prevFrameName = _nowFrameName;
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