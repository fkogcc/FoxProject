// 1-1-2から表世界へのシーン遷移テスト

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition1_1_2 : MonoBehaviour
{
    private GearRotation _Gimmick1_1_2;

    private FadeScene _fade;

    // 解いたかどうか.
    private bool _active = false;

    // Start is called before the first frame update
    void Start()
    {
        _Gimmick1_1_2 = GameObject.Find("GearHandle").GetComponent<GearRotation>();
        _fade = GameObject.FindWithTag("Fade").GetComponent<FadeScene>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_Gimmick1_1_2.GetResult())
        {
            _fade._isFadeOut = true;
        }

        if (_fade.GetAlphColor() >= 0.9f && _fade._isFadeOut)
        {
            _active = _Gimmick1_1_2.GetResult();
            SceneManager.sceneLoaded += GameSceneLoaded;
            SceneManager.LoadScene("MainScene1-1");
        }
    }

    // シーン切り替え時に呼ぶ.
    private void GameSceneLoaded(Scene next, LoadSceneMode mode)
    {
        // 切り替え後のスクリプト取得.
        //GimmickManager1_1 gimmickManager1_1 = GameObject.FindWithTag("GimmickManager").GetComponent<GimmickManager1_1>();
        SolveGimmickManager solveGimmickManager = 
            GameObject.FindWithTag("GimmickManager").GetComponent<SolveGimmickManager>();
        Player2DMove player2D = GameObject.FindWithTag("Player").GetComponent<Player2DMove>();

        // ギミックを解いたかのデータを渡す.
        //gimmickManager1_1._operationGimmick[1] = _active;
        solveGimmickManager._solve[1] = _active;
        player2D.transform.position = new Vector3(94.0f, 0.0f, 0.0f);

        // 削除
        SceneManager.sceneLoaded -= GameSceneLoaded;
    }
}
