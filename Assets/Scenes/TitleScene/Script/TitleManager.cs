using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    // スタートボタン押したらシーン切り替え動くよう.
    private bool _start;

    public TitleAnimDirector AnimDirector;

    private void Start()
    {
        _start = false;
    }

    // スタートする処理.
    public void OnStart()
    {
        Debug.Log("すたーとします");
        _start = true;
        AnimDirector.SetStart();
    }

    // オプション開く処理.
    public void OnOption()
    {
        Debug.Log("オプション開きます");
    }
}
