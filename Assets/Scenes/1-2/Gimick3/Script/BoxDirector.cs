using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDirector : MonoBehaviour
{
    // クリア数カウント
    int _clearCount;

    // 置けるかのフラグ
    bool _isSetFlag;

    // 引き始めた時の色
    string _pullColor;

    // ギミック設置場所の色
    string _gimmickColor;
    // ギミック設置場所の座標
    Vector3 _gimmickPos;

    void Start()
    {
        _clearCount = 0;

        _isSetFlag = false;

        _pullColor = "";

        _gimmickColor = "";
        _gimmickPos = new Vector3();
    }

    // 引き始めた色の取得
    public void SetGimmickOut(string color)
    {
        _pullColor = color;
    }

    // ギミック設置場所に当たったら色取得
    // 座標の保持
    // ギミック範囲内にいるようにする
    public void SetGimmickIn(string color, Vector3 temp)
    {
        _gimmickColor = color;

        _gimmickPos = temp;

        _isSetFlag = true;
    }

    public Vector3 GetGimmickPos()
    {
        return _gimmickPos;
    }

    public void IsSetFlag()
    {
        _isSetFlag = false;
    }

    // 引き始めた色と同じならばtrue返す
    public bool IsSameColor()
    {
        // 範囲外にいるならおけないようにする
        if (!_isSetFlag) return false;

        if (_pullColor == _gimmickColor)
        {
            _clearCount++;

            return true;
        }

        return false;
    }
}
