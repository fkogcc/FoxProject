﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmck1_2_4_SetActiveManager : MonoBehaviour
{
    // ステージのオブジェクトを取得.
    public GameObject _stageOne; 
    public GameObject _stageTwo; 

    // ステージ2のライトのオブジェクトを取得.
    public GameObject _stageTwoLight; 

    // カウントダウンするオブジェクトを取得
    public GameObject _countDown; 

    void Start()
    {
        _stageTwo.SetActive(false);
        _stageTwoLight.SetActive(false);
    }

    void Update()
    {
        // ステージ1をクリアしていて.
        // ステージ2をクリアしていない場合.
        if(_stageOne.GetComponent<Gimick1_2_4_Manager>().GetResult() &&
            !_stageTwo.GetComponent<Gimick1_2_4_Manager1Mk2>().GetResult())
        {
            _stageOne.SetActive(false);

            _stageTwo.SetActive(true);

            _countDown.SetActive(true);

            // ライトを光らす場合.
            if (_stageTwo.GetComponent<Gimick1_2_4_Manager1Mk2>().IsLight())
            {
                _stageTwoLight.SetActive(true);
            }
        }

        // ステージ2をクリアしている場合.
        if (_stageTwo.GetComponent<Gimick1_2_4_Manager1Mk2>().GetResult())
        {
            _stageTwo.SetActive(false);
        }

        // ステージ1をクリアしていなくて
        if(!_stageOne.GetComponent<Gimick1_2_4_Manager>().GetResult())
        {
            // カウントダウンをしない場合
            if(_stageOne.GetComponent<Gimick1_2_4_Manager>().IsCountDown())
            {
                _countDown.SetActive(false);
            }
        }
        // ステージ1をクリアしていなくて
        if (!_stageOne.GetComponent<Gimick1_2_4_Manager1Mk2>().GetResult())
        {
            // カウントダウンをしない場合
            if (_stageOne.GetComponent<Gimick1_2_4_Manager1Mk2>().IsCountDown())
            {
                _countDown.SetActive(false);
            }
        }
    }
}
