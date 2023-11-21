using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition1_2_2 : MonoBehaviour
{
    private FadeScene _fade;
    private Switch_1_2_2 _switch;
    private Player3DMove _Player3D;

    // 解いたかどうか.
    private bool _active = false;

    void Start()
    {
        _fade = GameObject.FindWithTag("Fade").GetComponent<FadeScene>();
        _switch = GameObject.Find("stage03_lever_02").GetComponent<Switch_1_2_2>();
        _Player3D = GameObject.FindWithTag("Player").GetComponent<Player3DMove>();
    }

    void Update()
    {
        if (_switch.GetResult())
        {
            _fade._isFadeOut = true;
        }
        if (_fade.GetAlphColor() >= 0.9f && _fade._isFadeOut)
        {
            _active = true;
            SceneManager.sceneLoaded += GameSceneLoaded;
            SceneManager.LoadScene("MainScene1-2");
        }

        // シーン切り替え時に呼ぶ.
        void GameSceneLoaded(Scene next, LoadSceneMode mode)
        {
            // 切り替え後のスクリプト取得.
            SolveGimmickManager solveGimmickManager = GameObject.FindWithTag("GimmickManager").GetComponent<SolveGimmickManager>();
            Player2DMove player2D = GameObject.FindWithTag("Player").GetComponent<Player2DMove>();

            // ギミックを解いたかのデータを渡す.
            solveGimmickManager._solve[1] = _active;
            player2D.transform.position = new Vector3(145.0f, 0.0f, 0.0f);
            player2D._hp = _Player3D._hp + 1;

            // 削除
            SceneManager.sceneLoaded -= GameSceneLoaded;
        }
    }
}
