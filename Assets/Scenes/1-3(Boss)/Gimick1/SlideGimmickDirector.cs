using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideGimmickDirector : MonoBehaviour
{
    const int kNum = 16;

    GameObject[] _gimmickObj;

    bool[] _isPut;

    Vector3 _tempPos1;
    Vector3 _tempPos2;

    void Start()
    {
        _gimmickObj = new GameObject[kNum];

        _isPut = new bool[kNum];

        _tempPos1 = new Vector3();
        _tempPos2 = new Vector3();

        for (int i = 0; i < kNum - 1; i++)
        {
            _gimmickObj[i] = GameObject.Find((i).ToString());
            _isPut[i] = true;
        }

        _gimmickObj[kNum - 1] = GameObject.Find((kNum - 1).ToString());
        _isPut[kNum - 1] = false;
    }

    public void EleCheck(int ele)
    {
        // 配列要素ないかの判定

        Debug.Log("[SlideGmmick] checkNum : " + ele);

        // 上のチェック
        if (0 <= ele - 4 && ele - 4 < kNum)
        {
            Debug.Log("[SlideGmmick] 上チェック");

            if(!_isPut[ele - 4])
            {
                // 位置入れ替え
                ChangeTrs(ele, ele - 4);

                Debug.Log("[SlideGmmick] 入れ替えました");
                return;
            }
        }
        // 下のチェック
        if (0 <= ele + 4 && ele + 4 < kNum)
        {
            Debug.Log("[SlideGmmick] 下チェック");
            if (!_isPut[ele + 4])
            {
                ChangeTrs(ele, ele + 4);

                Debug.Log("[SlideGmmick] 入れ替えました");
                return;
            }
        }
        // 左のチェック
        if (0 <= ele - 1 && ele - 1 < kNum)
        {
            Debug.Log("[SlideGmmick] 左チェック");
            if (!_isPut[ele - 1])
            {
                ChangeTrs(ele, ele - 1);

                Debug.Log("[SlideGmmick] 入れ替えました");
                return;
            }
        }
        // 右のチェック
        if (0 <= ele + 1 && ele + 1 < kNum)
        {
            Debug.Log("[SlideGmmick] 右チェック");
            if (!_isPut[ele + 1])
            {
                ChangeTrs(ele, ele + 1);

                Debug.Log("[SlideGmmick] 入れ替えました");
                return;
            }
        }

        Debug.Log("[SlideGmmick] 入れ替えれませんでした");
    }

    /// 位置の変更
    void ChangeTrs(int ele1, int ele2)
    {
        Debug.Log("変更前");
        Debug.Log(_gimmickObj[ele1].transform.position);
        Debug.Log(_gimmickObj[ele2].transform.position);

        _tempPos1 = _gimmickObj[ele1].transform.position;
        _tempPos2 = _gimmickObj[ele2].transform.position;

        _gimmickObj[ele1].transform.position = _tempPos2;
        _gimmickObj[ele2].transform.position = _tempPos1;

        Debug.Log("変更後");
        Debug.Log(_gimmickObj[ele1].transform.position);
        Debug.Log(_gimmickObj[ele2].transform.position);

        _isPut[ele1] = false;
        _isPut[ele2] = true;
    }
}
