using Microsoft.Cci;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideGimmickDirector : MonoBehaviour
{
    // 動かすブロックの数.
    const int kNum = 16;

    // 現在の手の位置からの上下左右
    const int kUp = -4;
    const int kDown = 4;
    const int kLeft = -1;
    const int kRight = 1;

    // 横に並んでいるブロックの数
    const int kRaw = 4;

    // プレイヤー
    GameObject _player;

    // ギミック親オブジェ.
    GameObject _parentObj;
    // ギミック子オブジェ.
    GameObject[] _gimmickObj;

    // 要素の番号.
    int[] _eles;

    // 押したかのフラグ
    bool _isHitKey;

    // 現在の要素
    int _nowEle;

    // 入れ替え用.
    Vector3 _tempPos1;
    Vector3 _tempPos2;
    int _tempEle;

    void Start()
    {
        // 初期化
        _player = new GameObject();

        _parentObj = new GameObject();
        _gimmickObj = new GameObject[kNum];

        _eles = new int[kNum];

        _isHitKey = false;

        _nowEle = 0;

        _tempPos1 = new Vector3();
        _tempPos2 = new Vector3();
        _tempEle = 0;

        // プレイヤーを探す
        _player = GameObject.Find("Hand");

        // 親オブジェを探す.
        _parentObj = GameObject.Find("Box");

        for (int i = 0; i < kNum; i++)
        {
            // 子オブジェを探す.
            _gimmickObj[i] = _parentObj.transform.GetChild(i).gameObject;
            // 要素番号の代入.
            _eles[i] = i;
        }

        // シャッフル
        for(int i = 0; i < 32; i++)
        {
            // todo: したのを復活
            //ChangeTrs(Random.Range(0, kNum), Random.Range(0, kNum));
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.F) && !_isHitKey)
        {
            _nowEle = _player.GetComponent<GimmickHand>().GetEleNum();

            EleCheck();

            _isHitKey = true;
        }
        else if (!Input.GetKey(KeyCode.F))
        {
            _isHitKey = false;
        }
    }

    public void EleCheck()
    {
        // 要素番号の位置が空白地なら何もしない
        if (_eles[_nowEle] == kNum - 1) return;

        // 上のチェック
        if (DirCheck(kUp)) return;
        Debug.Log("上違う");
        // 下のチェック
        if (DirCheck(kDown)) return;
        Debug.Log("下違う");
        // 左のチェック
        if (DirCheck(kLeft)) return;
        Debug.Log("左違う");
        // 右のチェック
        if (DirCheck(kRight)) return;
    }

    bool DirCheck(int dir)
    {
        // 左右の場合端にあれば確認しない
        if (dir == kLeft &&
            (_nowEle % kRaw) == 0)
        {
            return false;
        }
        if (dir == kLeft &&
            (_nowEle & kRaw) == (kRaw - 1))
        {
            return false;
        }

        // dirの方向のものが空白の場合動かす
        if (_eles[_nowEle + dir] == kNum - 1)
        {
            ChangeTrs(_nowEle + dir);

            return true;
        }

        return false;
    }

    /// 位置の変更
    // 要素一つ目、要素二つ目
    void ChangeTrs(int ele)
    {
        // それぞれの位置を保存.
        _tempPos1 = _gimmickObj[_eles[_nowEle]].transform.position;
        _tempPos2 = _gimmickObj[_eles[ele]].transform.position;

        // 保存した位置を使い、位置の入れ替え.
        _gimmickObj[_eles[_nowEle]].transform.position = _tempPos2;
        _gimmickObj[_eles[ele]].transform.position = _tempPos1;

        // 要素の番号を変更.
        _tempEle = _eles[_nowEle];
        _eles[_nowEle] = _eles[ele];
        _eles[ele] = _tempEle;
        
        // デバッグ表記用
        Debug.Log("現在の情報");
        for (int i = 0; i < 4; i++)
        {
            Debug.Log(_eles[i * 4] + ", " + _eles[i * 4 + 1] + ", " + _eles[i * 4 + 2] + ", " + _eles[i * 4 + 3] + ", ");
        }
    }
}
