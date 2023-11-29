// 2Dのフェードインアウト処理.
// TODO:マジックナンバーあり.

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    // 次のシーンへ行く時のカウント.
    private int _nextSceneCount = 0;
    // カウント開始しているかどうか.
    private bool _isCount = false;

    // シーン遷移で共通しているフラグ取得.
    public bool _transitionFlagCommon = false;

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
        // 共通フラグ.
        _transitionFlagCommon = _color.a >= 0.9f && !_player.GetIsMoveActive();

        // フェード処理.
        FadeUpdate();
        // ゲームオーバー.
        GameOverSceneTransition();
        // シーン遷移関数.
        SceneTransition();

        

        if ((_transitionScene._isGoal1_1 || _transitionScene._isGoal1_2) && Input.GetKeyDown("joystick button 3"))
        {
            _isGoal = true;
        }
    }

    // フェード処理.
    public void FadeUpdate()
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
            _color.a += 0.005f;
            gameObject.GetComponent<Image>().color = _color;
        }
    }

    // シーン遷移
    private void SceneTransition()
    {
        // ボタン押したら(ボタン配置は仮).
        if (Input.GetKeyDown("joystick button 3"))
        {
            Debug.Log("ボタン");
            // ゲートの前にいないときはスキップ.
            if (!_transitionScene.SetGateFlag()) return;

            // デバッグ用スキップ.
            if (_transitionScene._isGoal1_2)
            {
                _nextSceneCount = 120;
            }
            _isCount = true;
        }

        if(_isCount)
        {
            _nextSceneCount--;
        }

        if (_nextSceneCount <= 0 && _isCount)
        {
            _isPush = true;
        }

        

        if((_transitionScene._isGoal1_1 || _transitionScene._isGoal1_2) && _transitionFlagCommon)
        {
            SceneManager.sceneLoaded += GameSceneLoaded;
        }

        // シーン遷移.
        if (_transitionScene._isGateGimmick1_1 && _transitionFlagCommon)
        {
            _sceneTransitionManager.MainScene1_1_1();
        }
        else if (_transitionScene._isGateGimmick1_2 && _transitionFlagCommon)
        {
            _sceneTransitionManager.MainScene1_1_2();
        }
        else if (_transitionScene._isGateGimmick2_1 && _transitionFlagCommon)
        {
            _sceneTransitionManager.MainScene1_2_1();
        }
        else if (_transitionScene._isGateGimmick2_2 && _transitionFlagCommon)
        {
            _sceneTransitionManager.MainScene1_2_2();
        }
        else if (_transitionScene._isGateGimmick2_3 && _transitionFlagCommon)
        {
            _sceneTransitionManager.MainScene1_2_3();
        }
        else if (_transitionScene._isGateGimmick2_4 && _transitionFlagCommon)
        {
            _sceneTransitionManager.MainScene1_2_4();
        }
        else if(_transitionScene._isGateRoad3_1 && _transitionFlagCommon)
        {
            _sceneTransitionManager.GimmickRoad3_1();
        }
        else if(_transitionScene._isGateGimmick3_1 && _transitionFlagCommon)
        {
            _sceneTransitionManager.MainScene1_3_1();
        }
        else if (_transitionScene._isGateRoad3_2 && _transitionFlagCommon)
        {
            _sceneTransitionManager.GimmickRoad3_2();
        }
        else if (_transitionScene._isGateGimmick3_2 && _transitionFlagCommon)
        {
            _sceneTransitionManager.MainScene1_3_2();
        }
        else if (_transitionScene._isGateRoad3_3 && _transitionFlagCommon)
        {
            _sceneTransitionManager.GimmickRoad3_3();
        }
        else if (_transitionScene._isGateGimmick3_3 && _transitionFlagCommon)
        {
            _sceneTransitionManager.MainScene1_3_3();
        }
        else if (_transitionScene._isGateRoad3_4 && _transitionFlagCommon)
        {
            _sceneTransitionManager.GimmickRoad3_4();
        }
        else if (_transitionScene._isGateGimmick3_4 && _transitionFlagCommon)
        {
            _sceneTransitionManager.MainScene1_3_4();
        }
        else if(_transitionScene._isGoal1_1 && _transitionFlagCommon)
        {
            _sceneTransitionManager.MainScene1_2();
        }
        else if (_transitionScene._isGoal1_2 && _transitionFlagCommon)
        {
            _sceneTransitionManager.MainScene1_3();
        }
        else if (_transitionScene._isGoal1_3 && _transitionFlagCommon)
        {
            _sceneTransitionManager.EndScene();
        }

        

    }

    // 体力が0になった時の.
    private void GameOverSceneTransition()
    {
        // 生きていたらそもそも処理を通さない.
        if (_player._hp > 0) return;

        _nextSceneCount++;
        if(_nextSceneCount >= 300)
        {
            _isPush = true;
        }


        Debug.Log(_transitionFlagCommon);
        if(SceneManager.GetActiveScene().name == "MainScene1-1" && _color.a >= 0.9f)
        {
            _sceneTransitionManager.MainScene1_1();
        }
        else if(SceneManager.GetActiveScene().name == "MainScene1-2" && _color.a >= 0.9f)
        {
            _sceneTransitionManager.MainScene1_2();
        }
    }

    // シーン切り替え時に呼ぶ.
    private void GameSceneLoaded(Scene next, LoadSceneMode mode)
    {
        if(_transitionScene._isGoal1_1)
        {
            // 切り替え先のスクリプト取得
            Player2DMove player2D = GameObject.FindWithTag("Player").GetComponent<Player2DMove>();

            // 残機を一つ増やす.
            _player._hp = _player._hp + 1;

            // hpの引継ぎ.
            player2D._hp = _player.GetHp();
        }
        else if(_transitionScene._isGoal1_2)
        {
            // 切り替え先のスクリプト取得
            Player3DMove player3D = GameObject.FindWithTag("Player").GetComponent<Player3DMove>();

            // 残機を一つ増やす.
            _player._hp = _player._hp + 1;

            // hpの引継ぎ.
            player3D._hp = _player.GetHp();
        }
        

        // 削除
        SceneManager.sceneLoaded -= GameSceneLoaded;
    }
}
