using System.Collections;
using UnityEngine;
using UnityEngine.UI;// UIコンポーネント仕様

public class PauseController : MonoBehaviour
{
    // 閉じるボタン
    private Button _close;
    // テストボタン
    private Button _test;

    // Start is called before the first frame update
    void Start()
    {
        _close = GameObject.Find("/PauseCanvs/BackGround/Close").GetComponent<Button>();
        _test = GameObject.Find("/PauseCanvs/BackGround/Test").GetComponent<Button>();

        _close.Select();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
