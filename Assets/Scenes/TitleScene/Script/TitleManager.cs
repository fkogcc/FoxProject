using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    // スタートボタン押したらシーン切り替え動くよう.
    private bool _start;

    public TitleAnimDirector AnimDirector;
    public FadeScene FadeSrc;
    private TitleWindow _window;
    private TitleSelect _select;
    private TitleOption _option;

    private void Start()
    {
        _start = false;

        _window = GameObject.Find("windmill:windmill:polySurface132").GetComponent<TitleWindow>();
        _select = GameObject.Find("SeelctFrame").GetComponent<TitleSelect>();
        _option = GetComponent<TitleOption>();
    }

    private void Update()
    {
        _select.SelectUpdate();
        _option.OptionUpdate();
    }

    private void FixedUpdate()
    {
        _window.WindowUpdate();
        _option.FadeUpdate();

        if (FadeSrc._isFadeOut && FadeSrc.GetAlphColor() > 1.0f)
        {
            SceneManager.LoadScene("MainScene1-1");
        }
    }

    // スタートする処理.
    public void OnStart()
    {
        _start = true;
        AnimDirector.SetStart();
        FadeSrc._isFadeOut = true;
    }

    // オプション開く処理.
    public void OnOption()
    {
        Debug.Log("オプション開きます");
        _option.Indicate();
    }
}
