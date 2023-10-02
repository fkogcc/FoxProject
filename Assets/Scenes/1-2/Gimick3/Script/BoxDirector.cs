using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxDirector : MonoBehaviour
{
    // 次のシーンの名前.
    public string NextStageName;

    // クリア数カウント.
    private int _clearCount;
    // 置けるかのフラグ.
    private bool _isSetFlag;
    // 引き始めた時の色.
    private string _pullColor;
    // ギミック設置場所の色.
    private string _gimmickColor;
    // ギミック設置場所の座標.
    private Vector3 _gimmickPos;
    // ギミックの最大数.
    private int _gimmickNum;

    // 初期化処理
    void Start()
    {
        _clearCount = 0;
        _isSetFlag = false;
        _pullColor = "";
        _gimmickColor = "";
        _gimmickPos = new Vector3();
        _gimmickNum = 4;
    }

    // 引き始めた色の取得
    public void SetGimmickOut(string color)
    {
        _pullColor = color;
    }

    // ギミックに当たった時の処理.
    public void SetGimmickIn(string color, Vector3 temp)
    {
        // ギミック設置場所に当たったら色取得.
        _gimmickColor = color;
        // 座標の保持.
        _gimmickPos = temp;
        // ギミック範囲内にいるようにする.
        _isSetFlag = true;
    }
    // ギミックの位置を返す.
    public Vector3 GetGimmickPos()
    {
        return _gimmickPos;
    }

    // フラグを返す.
    public void IsSetFlag(bool flag)
    {
        _isSetFlag = flag;
    }

    // 引き始めた色と同じならばtrue返す.
    public bool IsSameColor()
    {
        // 範囲外にいるならおけないようにする.
        if (!_isSetFlag) return false;

        if (_pullColor == _gimmickColor)
        {
            _clearCount++;

            if (_gimmickNum <= _clearCount)
            {
                Debug.Log("[BoxGimmick]クリアしました");

                SceneManager.LoadScene(NextStageName);
            }
            return true;
        }
        return false;
    }
}
