using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestSceneTransition1_1_1 : MonoBehaviour
{
    private Gimick1_1_1Manager _Gimmick1_1_1;

    private FadeScene _fade;

    // 解いたかどうか.
    private bool _active = false;

    // Start is called before the first frame update
    void Start()
    {
        _Gimmick1_1_1 = GetComponent<Gimick1_1_1Manager>();
        _fade = GameObject.FindWithTag("Fade").GetComponent<FadeScene>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_Gimmick1_1_1.GetResult())
        {
            _fade._isFadeOut = true;
        }

        if(_fade.GetAlphColor() >= 0.9f && _fade._isFadeOut)
        {
            _active = _Gimmick1_1_1.GetResult();
            SceneManager.sceneLoaded += GameSceneLoaded;
            SceneManager.LoadScene("MainScene1-1");
        }
    }

    // シーン切り替え時に呼ぶ.
    private void GameSceneLoaded(Scene next, LoadSceneMode mode)
    {
        // 切り替え後のスクリプト取得.
        //GimmickManager1_1 gimmickManager1_1 = GameObject.FindWithTag("GimmickManager").GetComponent<GimmickManager1_1>();
        Player2DMove player2D = GameObject.FindWithTag("Player").GetComponent<Player2DMove>();

        // ギミックを解いたかのデータを渡す.
        //gimmickManager1_1._operationGimmick[0] = _active;
        player2D.transform.position = new Vector3(22.0f, 0.0f, 0.0f);

        // 削除
        SceneManager.sceneLoaded -= GameSceneLoaded;
    }
}
