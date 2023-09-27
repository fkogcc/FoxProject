using Microsoft.Cci;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideGimmickDirector : MonoBehaviour
{
    // プレイヤーの動く量
    private const float kSpeed = 0.125f;

    // 動かすブロックの数.
    private const int kNum = 16;

    // 現在の手の位置からの上下左右
    private const int kDirUp = -4;
    private const int kDirDown = 4;
    private const int kDirLeft = -1;
    private const int kDirRight = 1;

    // 横に並んでいるブロックの数
    private const int kRaw = 4;

    // プレイヤー
    private GameObject _player;

    // ギミック親オブジェ.
    private GameObject _parentObj;
    // ギミック子オブジェ.
    private GameObject[] _gimmickObj;

    // 要素の番号.
    private int[] _eles;

    // 現在の要素
    private int _nowEle;

    // 入れ替え用.
    private Vector3 _tempPos1;
    private Vector3 _tempPos2;
    private int _tempEle;

    // クリアしているかしていないか
    private bool _isCreal;

    private void Start()
    {
        // 初期化
        _player = new GameObject();

        _parentObj = new GameObject();
        _gimmickObj = new GameObject[kNum];

        _eles = new int[kNum];

        _nowEle = kNum - 1;

        _tempPos1 = new Vector3();
        _tempPos2 = new Vector3();
        _tempEle = 0;

        _isCreal = false;

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
            // todo: 現状のシャッフルではクリアできない積み配置になってしまうから修正する
            _nowEle = Random.Range(0, kNum);
            ChangeTrs(Random.Range(0, kNum));
        }
    }

    private void Update()
    {
        // クリアしていたら処理しない
        if (_isCreal) return;

        // プレイヤーの移動処理
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _player.transform.position += new Vector3(0.0f, kSpeed, 0.0f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            _player.transform.position += new Vector3(0.0f, -kSpeed, 0.0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _player.transform.position += new Vector3(kSpeed, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _player.transform.position += new Vector3(-kSpeed, 0.0f, 0.0f);
        }

        // 特定のボタンを押したらギミックの処理
        if (Input.GetKeyDown(KeyCode.F))
        {
            _nowEle = _player.GetComponent<GimmickHand>().GetEleNum();

            EleCheck();
        }
    }

    private void FixedUpdate()
    {
        // クリアしていたら処理しない
        if (_isCreal) return;

        // 要素が番号通りに並んでいるか確認
        for (int i = 0; i < kNum; i++)
        {
            // 要素番号通りでないならここでの処理終了
            if (_eles[i] != i) return;
        }

        // ここまで来たらクリアしているので完了とする
        _isCreal = true;
        Debug.Log("クリア");
    }

    private void EleCheck()
    {
        // 要素番号の位置が空白地なら何もしない
        if (_eles[_nowEle] == kNum - 1) return;

        // 上のチェック
        if (DirCheck(kDirUp)) return;
        // 下のチェック
        if (DirCheck(kDirDown)) return;
        // 左のチェック
        if (DirCheck(kDirLeft)) return;
        // 右のチェック
        if (DirCheck(kDirRight)) return;
    }

    private bool DirCheck(int dir)
    {
        // 要素数ないにいなければ確認しない
        if ((_nowEle + dir) < 0 ||
            kNum <= (_nowEle + dir))
        {
            return false;
        }
        // 左右の場合端にあれば確認しない
        if (dir == kDirLeft &&
            (_nowEle % kRaw) == 0)
        {
            return false;
        }
        if (dir == kDirLeft &&
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
    private void ChangeTrs(int ele)
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

        for (int i = 0; i < 4; i++)
        {
            Debug.Log(_eles[i * kRaw] + ", " + _eles[i * kRaw + 1] + ", " + _eles[i * kRaw + 2] + ", " + _eles[i * kRaw + 3]);
        }
    }
}
