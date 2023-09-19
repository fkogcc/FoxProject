using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDirector : MonoBehaviour
{
    // 置けるかのフラグ
    bool _isSetFlag;

    // 色用変数
    string _gimmickColor;

    void Start()
    {
        _isSetFlag = false;

        _gimmickColor = "";
    }

    // 引き始めた色の取得
    void SetGimmickColor(string color)
    {
        _gimmickColor = color;
    }

    // 引き始めた色と同じならばtrue返す
    bool IsSameColor(string color)
    {
        if (_gimmickColor == color)
        {
            return true;
        }

        return false;
    }
}
