using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestSceneTransition1_1_1 : MonoBehaviour
{
    private Gimick1_1_1Manager _Gimmick1_1_1;
    // 解いたかどうか.
    private bool _active = false;

    // Start is called before the first frame update
    void Start()
    {
        _Gimmick1_1_1 = GameObject.Find("Manager").GetComponent<Gimick1_1_1Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        // RBボタンでシーン遷移
        if(_Gimmick1_1_1.GetResult())
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
        GimmickManager1_1 gimmickManager1_1 = GameObject.FindWithTag("GimmickManager").GetComponent<GimmickManager1_1>();
        Player2DMove player2D = GameObject.FindWithTag("Player").GetComponent<Player2DMove>();

        // ギミックを解いたかのデータを渡す.
        gimmickManager1_1._operationGimmick[0] = _active;
        player2D.transform.position = new Vector3(22.0f, 0.0f, 0.0f);

        // 削除
        SceneManager.sceneLoaded -= GameSceneLoaded;
    }
}
