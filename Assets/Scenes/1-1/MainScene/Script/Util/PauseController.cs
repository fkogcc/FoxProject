// ポーズ画面を開く閉じる操作.
// HACK:ポーズ画面を雑に作ったのでコーディング規約だけ見てほしい.

using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    // 閉じるボタン.
    private Button _close;
    // テストボタン.
    private Button _test;

    void Start()
    {
        // それぞれのボタンのコンポーネント取得.
        _close = GameObject.Find("/PauseCanvs/BackGround/Close").GetComponent<Button>();
        _test = GameObject.Find("/PauseCanvs/BackGround/Test").GetComponent<Button>();

        _close.Select();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
