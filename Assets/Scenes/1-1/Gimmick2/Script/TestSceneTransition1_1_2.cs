// 1-1-2から表世界へのシーン遷移テスト
// TODO:後から改名、スクリプトの変更を行う

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestSceneTransition1_1_2 : MonoBehaviour
{
    // 解いたかどうかのテストのbool型
    private bool _active = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("joystick button 5"))
        {
            _active = true;
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
        gimmickManager1_1._operationGimmick[1] = _active;
        player2D.transform.position = new Vector3(94.0f, 0.0f, 0.0f);

        // 削除
        SceneManager.sceneLoaded -= GameSceneLoaded;
    }
}
