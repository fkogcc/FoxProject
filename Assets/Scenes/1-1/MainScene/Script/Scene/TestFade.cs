using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestFade : MonoBehaviour
{
    public Color _color;// 色

    private bool _isPush;// ゲートのボタンを押したかどうか

    // Start is called before the first frame update
    void Start()
    {
        // 初期化
        _isPush = false;
        _color = gameObject.GetComponent<Image>().color;
        _color.r = 0.0f;
        _color.g = 0.0f;
        _color.b = 0.0f;
        _color.a = 1.0f;
        gameObject.GetComponent<Image>().color = _color;
    }

    // Update is called once per frame
    void Update()
    {
        // フェード処理
        FadeUpdate();
        // シーン遷移関数
        SceneTransition();
    }

    // ゲートの前にいるかの状態
    bool SetGateFlag()
    {
        return testCol._instance._isGateGimmick1 || testCol._instance._isGateGimmick2;
    }

    // フェード処理
    void FadeUpdate()
    {
        // フェードインフラグ
        if (_color.a >= 1.0f)
        {
            _isPush = false;
        }

        // 透明度を固定化
        if (_color.a <= 0.0f)
        {
            _color.a = 0.0f;
        }

        // フェードイン
        if (!_isPush)
        {
            _color.a -= 0.01f;
            gameObject.GetComponent<Image>().color = _color;
        }
        else// フェードアウト
        {
            _color.a += 0.01f;
            gameObject.GetComponent<Image>().color = _color;
        }
    }

    // シーン遷移
    void SceneTransition()
    {
        // ボタン押したら(ボタン配置は仮)
        if (Input.GetKeyDown("joystick button 3"))
        {
            // ゲートの前にいないときはスキップ
            if (!SetGateFlag()) return;
            _isPush = true;
        }

        // シーン遷移
        if (testCol._instance._isGateGimmick1 && _color.a >= 0.9f)
        {
            SceneManager.LoadScene("Gimmick1Scene");
        }
        else if (testCol._instance._isGateGimmick2 && _color.a >= 0.9f)
        {
            SceneManager.LoadScene("Gimmick2Scene");
        }

    }
}
