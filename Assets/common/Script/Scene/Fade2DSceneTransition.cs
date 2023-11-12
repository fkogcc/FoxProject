// 2Dのフェードインアウト処理.
// TODO:マジックナンバーあり.

using UnityEngine;
using UnityEngine.UI;

public class Fade2DSceneTransition : MonoBehaviour
{
    private Player2DMove _player;

    private GateFlag _transitionScene;

    private SceneTransitionManager _sceneTransitionManager;

    // ゴールしたタイミング
    public bool _isGoal;

    // 色.
    public Color _color;
    // ゲートのボタンを押したかどうか.
    private bool _isPush;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player2DMove>();
        // 初期化.
        _isGoal = false;
        _isPush = false;
        _color = gameObject.GetComponent<Image>().color;
        _color.r = 0.0f;
        _color.g = 0.0f;
        _color.b = 0.0f;
        _color.a = 1.0f;
        gameObject.GetComponent<Image>().color = _color;
        _transitionScene = GameObject.FindWithTag("Player").GetComponent<GateFlag>();
        _sceneTransitionManager = GetComponent<SceneTransitionManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // フェード処理.
        FadeUpdate();
        // シーン遷移関数.
        SceneTransition();
        //Debug.Log($"{name}");
    }

    // フェード処理.
    private void FadeUpdate()
    {
        // フェードインフラグ.
        if (_color.a >= 1.0f)
        {
            _isPush = false;
        }

        // 透明度を固定化.
        if (_color.a <= 0.0f)
        {
            _color.a = 0.0f;
        }

        // フェードイン.
        if (!_isPush)
        {
            _color.a -= 0.01f;
            gameObject.GetComponent<Image>().color = _color;
        }
        else// フェードアウト.
        {
            _color.a += 0.01f;
            gameObject.GetComponent<Image>().color = _color;
        }
    }

    // シーン遷移
    private void SceneTransition()
    {
        // ボタン押したら(ボタン配置は仮).
        if (Input.GetKeyDown("joystick button 3"))
        {
            // ゲートの前にいないときはスキップ.
            if (!_transitionScene.SetGateFlag()) return;
            _isPush = true;
        }

        // 共通フラグ
        bool transitionFlagCommon = _color.a >= 0.9f && !_player.GetIsMoveActive();

        // シーン遷移.
        if (_transitionScene._isGateGimmick1_1 && transitionFlagCommon)
        {
            _sceneTransitionManager.MainScene1_1_1();
        }
        else if (_transitionScene._isGateGimmick1_2 && transitionFlagCommon)
        {
            _sceneTransitionManager.MainScene1_1_2();
        }
        else if (_transitionScene._isGateGimmick2_1 && transitionFlagCommon)
        {
            _sceneTransitionManager.MainScene1_2_1();
        }
        else if (_transitionScene._isGateGimmick2_2 && transitionFlagCommon)
        {
            _sceneTransitionManager.MainScene1_2_2();
        }
        else if (_transitionScene._isGateGimmick2_3 && transitionFlagCommon)
        {
            _sceneTransitionManager.MainScene1_2_3();
        }
        else if (_transitionScene._isGateGimmick2_4 && transitionFlagCommon)
        {
            _sceneTransitionManager.MainScene1_2_4();
        }
        else if(_transitionScene._isGateRoad3_1 && transitionFlagCommon)
        {
            _sceneTransitionManager.GimmickRoad3_1();
        }
        else if(_transitionScene._isGateGimmick3_1 && transitionFlagCommon)
        {
            _sceneTransitionManager.MainScene1_3_1();
        }
        else if (_transitionScene._isGateRoad3_2 && transitionFlagCommon)
        {
            _sceneTransitionManager.GimmickRoad3_2();
        }
        else if (_transitionScene._isGateGimmick3_2 && transitionFlagCommon)
        {
            _sceneTransitionManager.MainScene1_3_2();
        }
        else if (_transitionScene._isGateRoad3_3 && transitionFlagCommon)
        {
            _sceneTransitionManager.GimmickRoad3_3();
        }
        else if (_transitionScene._isGateGimmick3_3 && transitionFlagCommon)
        {
            _sceneTransitionManager.MainScene1_3_3();
        }
        else if (_transitionScene._isGateRoad3_4 && transitionFlagCommon)
        {
            _sceneTransitionManager.GimmickRoad3_4();
        }
        else if (_transitionScene._isGateGimmick3_4 && transitionFlagCommon)
        {
            _sceneTransitionManager.MainScene1_3_4();
        }
        else if(_transitionScene._isGoal1_1 && transitionFlagCommon)
        {
            _sceneTransitionManager.MainScene1_2();
        }
        else if (_transitionScene._isGoal1_2 && transitionFlagCommon)
        {
            _sceneTransitionManager.MainScene1_3();
        }
        else if (_transitionScene._isGoal1_3 && transitionFlagCommon)
        {
            _sceneTransitionManager.EndScene();
        }

        if ((_transitionScene._isGoal1_1 || _transitionScene._isGoal1_2) && Input.GetKeyDown("joystick button 3"))
        {
            _isGoal = true;
        }

    }
}
