using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition1_2_1 : MonoBehaviour
{
    private GameObject _effeect;
    private EffectLine _effectLine;

    private FadeScene _fade;

    // 解いたかどうか.
    private bool _active = false;

    // Start is called before the first frame update
    void Start()
    {
        _effeect = GameObject.Find("EffectCreate");
        _effectLine = _effeect.GetComponent<EffectLine>();
        _fade = GameObject.FindWithTag("Fade").GetComponent<FadeScene>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_effectLine.GetResult())
        {
            _fade._isFadeOut = true;
        }

        if (_fade.GetAlphColor() >= 0.9f && _fade._isFadeOut)
        {
            _active = _effectLine.GetResult();
            SceneManager.sceneLoaded += GameSceneLoaded;
            SceneManager.LoadScene("MainScene1-2");
        }
    }

    // シーン切り替え時に呼ぶ.
    private void GameSceneLoaded(Scene next, LoadSceneMode mode)
    {
        // 切り替え後のスクリプト取得.
        SolveGimmickManager solveGimmickManager = GameObject.FindWithTag("GimmickManager").GetComponent<SolveGimmickManager>();
        Player2DMove player2D = GameObject.FindWithTag("Player").GetComponent<Player2DMove>();

        // ギミックを解いたかのデータを渡す.
        solveGimmickManager._solve[0] = _active;
        player2D.transform.position = new Vector3(60.0f, 0.0f, 0.0f);

        // 削除
        SceneManager.sceneLoaded -= GameSceneLoaded;
    }
}
