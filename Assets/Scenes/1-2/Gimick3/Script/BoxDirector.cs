﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// Boxの情報(ギミック).
public class BoxDirector : MonoBehaviour
{
    public SoundManager SndManager;

    // ギミックの最大数.
    public int GimmickNum = 0;

    private GameObject _nowObj;

    // 次のステージに移るのかMainに戻るのか
    // true: 次のステージに
    // false : Mainに戻る
    public bool IsNext;
    // フェード用
    private FadeScene _fade;

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

    // 全てクリアしているかのフラグ.
    private bool _isAllClear;
    // クリアのテキスト.
    public GameObject ClearText;
    // Canvasを入れるよう
    public GameObject Canvas;

    Dictionary<string, GameObject> _lineObj;

    // 初期化処理
    private void Start()
    {
        _nowObj = new GameObject();

        _fade = GameObject.Find("Fade").GetComponent<FadeScene>();

        _clearCount = 0;
        _isSetFlag = false;
        _pullColor = "";
        _gimmickColor = "";
        _gimmickPos = new Vector3();

        _isAllClear = false;

        _lineObj = new Dictionary<string, GameObject>();
        _lineObj.Add("Pink", GameObject.Find("PinkLine"));
        _lineObj.Add("Bule", GameObject.Find("BuleLine"));
        _lineObj.Add("Green", GameObject.Find("GreenLine"));
        _lineObj.Add("Red", GameObject.Find("RedLine"));
        if (4 < GimmickNum)
        {
            _lineObj.Add("Yellow", GameObject.Find("YellowLine"));
            _lineObj.Add("YellowGreen", GameObject.Find("YellowGreenLine"));
            _lineObj.Add("SkyBule", GameObject.Find("SkyBuleLine"));
            _lineObj.Add("Orange", GameObject.Find("OrangeLine"));
        }
    }

    private void FixedUpdate()
    {
        SndManager.PlayBGM("1_2_3_BGM");
        if (_isAllClear && _fade.GetAlphColor() >= 0.85f)
        {
            SndManager.StopBgm();

            if (IsNext)
            {
                SceneManager.LoadScene("Gimmick1_2_3_2");
            }
        }
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
    public void SetObj(GameObject obj)
    {
        _nowObj = obj;
    }

    // 引き始めた色と同じならばtrue返す.
    public bool IsSameColor()
    {
        // 範囲外にいるならおけないようにする.
        if (!_isSetFlag) return false;

        if (_pullColor == _gimmickColor)
        {
            _clearCount++;
            _nowObj.GetComponent<ParticleSystem>().Play();
            Destroy(_lineObj[_gimmickColor]);

            if (GimmickNum <= _clearCount)
            {
                _isAllClear = true;

                if (IsNext)
                {
                    _fade._isFadeOut = true;
                }
                else
                {
                    GameObject clone = Instantiate(ClearText);
                    clone.transform.SetParent(Canvas.transform, false);
                }
            }
            return true;
        }
        return false;
    }

    public bool GetResult()
    {
        return _isAllClear;
    }
}
