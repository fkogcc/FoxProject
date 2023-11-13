using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    // スタートボタン押したらシーン切り替え動くよう.
    private bool _start;

    private void Start()
    {
        _start = false;
    }

    // スタートする処理.
    public void OnStart()
    {
        _start = true;
    }

    // オプション開く処理.
    public void OnOption()
    {
        Debug.Log("オプション開きます");
    }

    public bool GetResult()
    {
        return _start;
    }
}
