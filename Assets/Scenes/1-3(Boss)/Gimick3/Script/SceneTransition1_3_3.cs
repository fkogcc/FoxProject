﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition1_3_3 : MonoBehaviour
{
    private ContainerDirector _containerDirector;

    private FadeScene _fade;

    // 解いたかどうか.
    private bool _active = false;

    // Start is called before the first frame update
    void Start()
    {
        _containerDirector = GameObject.Find("Container Director").GetComponent<ContainerDirector>();
        _fade = GameObject.FindWithTag("Fade").GetComponent<FadeScene>();
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(_containerDirector.GetResult());

        if (_containerDirector.GetResult())
        {
            //Debug.Log("a");
            _fade._isFadeOut = true;
        }

        if (_fade.GetAlphColor() >= 0.9f && _fade._isFadeOut)
        {
            _active = _containerDirector.GetResult();
            SceneManager.sceneLoaded += GameSceneLoaded;
            SceneManager.LoadScene("MainScene1-3");
        }
    }

    // シーン切り替え時に呼ぶ.
    private void GameSceneLoaded(Scene next, LoadSceneMode mode)
    {
        // 切り替え後のスクリプト取得.
        SolveGimmickManager solveGimmickManager = GameObject.FindWithTag("GimmickManager").GetComponent<SolveGimmickManager>();

        // ギミックを解いたかのデータを渡す.
        solveGimmickManager._solve[0] = _active;

        // 削除
        SceneManager.sceneLoaded -= GameSceneLoaded;
    }
}
