using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideGimmickDirector : MonoBehaviour
{
    // 動かすブロックの数.
    const int kNum = 16;

    // 親オブジェ.
    GameObject _parentObj;
    // 子オブジェ.
    GameObject[] _gimmickObj;

    // 入れられているか.
    bool[] _isPut;
    // 要素の番号.
    int[] _eles;

    // 入れ替え用.
    Vector3 _tempPos1;
    Vector3 _tempPos2;
    int _tempEle;

    void Start()
    {
        _parentObj = new GameObject();
        _gimmickObj = new GameObject[kNum];

        _isPut = new bool[kNum];
        _eles = new int[kNum];

        _tempPos1 = new Vector3();
        _tempPos2 = new Vector3();

        // 親オブジェを探す.
        _parentObj = GameObject.Find("Box");

        for (int i = 0; i < kNum; i++)
        {
            // 子オブジェを探す.
            _gimmickObj[i] = _parentObj.transform.GetChild(i).gameObject;
            // 入れられていることにする.
            _isPut[i] = true;
            // 初期番号の代入.
            _eles[i] = i;
        }

        // 最後のは空白地のため入れられていないにする.
        _isPut[kNum - 1] = false;


        // シャッフル
        for(int i = 0; i < 32; i++)
        {
            ChangeTrs(Random.Range(0, kNum), Random.Range(0, kNum));
        }
    }

    public void EleCheck(int ele)
    {
        // 要素番号の位置が空白地なら何もしない
        if (!_isPut[ele]) return;

        // 上のチェック
        if (0 <= ele - 4 && ele - 4 < kNum)
        {
            if(!_isPut[ele - 4])
            {
                // 位置入れ替え
                ChangeTrs(ele, ele - 4);

                return;
            }
            Debug.Log("上違う");
        }
        // 下のチェック
        if (0 <= ele + 4 && ele + 4 < kNum)
        {
            if (!_isPut[ele + 4])
            {
                ChangeTrs(ele, ele + 4);

                return;
            }
            Debug.Log("下違う");
        }
        // 左のチェック
        if (0 <= ele - 1 && ele - 1 < kNum && ele % 4 != 0)
        {
            if (!_isPut[ele - 1])
            {
                ChangeTrs(ele, ele - 1);

                return;
            }
            Debug.Log("左違う");
        }
        // 右のチェック
        if (0 <= ele + 1 && ele + 1 < kNum && ele % 4 != 3)
        {
            if (!_isPut[ele + 1])
            {
                ChangeTrs(ele, ele + 1);

                return;
            }
            Debug.Log("右違う");
        }
    }

    /// 位置の変更
    // 要素一つ目、要素二つ目
    void ChangeTrs(int ele1, int ele2)
    {
        // それぞれの位置を保存.
        _tempPos1 = _gimmickObj[_eles[ele1]].transform.position;
        _tempPos2 = _gimmickObj[_eles[ele2]].transform.position;

        // 保存した位置を使い、位置の入れ替え.
        _gimmickObj[_eles[ele1]].transform.position = _tempPos2;
        _gimmickObj[_eles[ele2]].transform.position = _tempPos1;

        // 要素の番号を変更.
        _tempEle = _eles[ele1];
        _eles[ele1] = _eles[ele2];
        _eles[ele2] = _tempEle;

        // boolの変更.
        if (!_isPut[ele2])
        {
            _isPut[ele1] = false;
            _isPut[ele2] = true;
        }
        else if (!_isPut[ele1])
        {
            _isPut[ele1] = true;
            _isPut[ele2] = false;
        }
        
        // デバッグ表記用
        Debug.Log("現在の情報");
        for (int i = 0; i < 4; i++)
        {
            Debug.Log(_isPut[i * 4] + ", " + _isPut[i * 4 + 1] + ", " + _isPut[i * 4 + 2] + ", " + _isPut[i * 4 + 3] + ", ");
        }
        for (int i = 0; i < 4; i++)
        {
            Debug.Log(_eles[i * 4] + ", " + _eles[i * 4 + 1] + ", " + _eles[i * 4 + 2] + ", " + _eles[i * 4 + 3] + ", ");
        }
    }
}
