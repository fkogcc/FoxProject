using UnityEngine;

public class Gimick1_2_1Manager : MonoBehaviour
{
    // オブジェクトの取得

    // プレイヤーの手
    private GameObject _handObject;
    private PlayerHand _playerHand;
    // モニター前カメラ
    private GameObject _cameraObject;
    // モニター前カメラのテスト用
    private MonitorCamera _camera;
    // オブジェクトの管理しているマネージャー
    private ObjectManagement _objectManagement;

    // ギミックのパネル（モニター）の取得
    [SerializeField] private GameObject[] _panelObject;
    // ボタンの状態を管理するスクリプトクラス
    private ButtonState[] _buttonState;
    // エフェクトの取得
    private GameObject _effect;
    private EffectPlay _effectPlay;
    // サウンドの取得
    //[SerializeField] private SoundManager _sound; 
    public SoundManager _sound; 
    // 前フレームにいたモニターの場所の取得
    private string _prevFrameName = null;
    // 今のフレームにいるモニターの場所の取得
    private string _nowFrameName = null;


    // 初期化処理
    void Start()
    {
        // カメラの取得
        _cameraObject = GameObject.Find("MonitorCamera");
        _camera = _cameraObject.GetComponent<MonitorCamera>();
        // オブジェクトのマネージャー取得
        _objectManagement = GetComponent<ObjectManagement>();
        // ボタンの状態を取得
        _buttonState = new ButtonState[_panelObject.Length];
        for (int i = 0; i < _buttonState.Length; i++)
        {
            _buttonState[i] = _panelObject[i].GetComponent<ButtonState>();
        }
        // エフェクトの取得
        _effect = GameObject.Find("EffectCreate");
        _effectPlay = _effect.GetComponent<EffectPlay>();
        // エフェクトの初期化処理
        _effectPlay.EffectInit();
        _sound.PlayBGM("1_2_1_BGM");

    }

    // Update is called once per frame
    void Update()
    {
        // HACK さすがに長すぎるし乱雑なので関数化するなりきれいに書き直すなりしましょう
        _handObject = GameObject.Find("FoxHand(Clone)");
        // モニターを変えるかどうかをチェックしている
        _objectManagement.MonitorChenge();
        // カメラのUpdate
        _camera.CameraUpdate();
        if (_handObject != null)
        {
            // プレイヤーの手がボタンを押したかどうか
            if (_handObject.activeInHierarchy)
            {
                _handObject.GetComponent<PlayerHand>().ButtonPush();
                
            }
            _nowFrameName = _camera.GetCameraName();
            //foreach (GameObject panel in _panelObject)
            foreach (ButtonState button in _buttonState)
            {
                if (button.name == _camera.GetCameraName())
                {
                    //_buttonState = panel.GetComponent<ButtonState>();
                    button.GetPlayerObject(_handObject);
                    // ボタンの状態
                    button.ButtonAcquisition();

                    _effectPlay.GetPanelName(button.transform.name);
                    _effectPlay.GetSoundData(_sound);
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
            _effectPlay.GenaretaText();


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