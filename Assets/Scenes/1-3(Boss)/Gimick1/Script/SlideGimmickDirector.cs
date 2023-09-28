using Microsoft.Cci;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideGimmickDirector : MonoBehaviour
{
    // プレイヤーの動く量
    private const float kSpeed = 0.25f;

    // 動かすブロックの数.
    private const int kBlockNum = 16;

    // 現在の手の位置からの上下左右
    private const int kDirUp = -4;
    private const int kDirDown = 4;
    private const int kDirLeft = -1;
    private const int kDirRight = 1;
    // 上下左右の方向の数
    private const int kDirNum = 4;

    // 横に並んでいるブロックの数
    private const int kRaw = 4;

    // 入れ替えにかけるフレーム数
    private const int kMoveFrame = 25;

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

    // 入れ替え時間カウント用
    private int _moveCount;
    private int _moveEle;
    // 入れ替えをしているか
    private bool _isChange;

    // クリアしているかしていないか
    private bool _isCreal;

    private void Start()
    {
        // 初期化
        _player = new GameObject();

        _parentObj = new GameObject();
        _gimmickObj = new GameObject[kBlockNum];

        _eles = new int[kBlockNum];

        _nowEle = kBlockNum - 1;

        _tempPos1 = new Vector3();
        _tempPos2 = new Vector3();
        _tempEle = 0;

        _moveCount = 0;
        _moveEle = 0;
        _isChange = false;

        _isCreal = false;

        // プレイヤーを探す
        _player = GameObject.Find("Hand");

        // 親オブジェを探す.
        _parentObj = GameObject.Find("Box");

        for (int i = 0; i < kBlockNum; i++)
        {
            // 子オブジェを探す.
            _gimmickObj[i] = _parentObj.transform.GetChild(i).gameObject;
            // 要素番号の代入.
            _eles[i] = i;
        }

        // シャッフル
        for(int i = 0; i < 32; i++)
        {
            _nowEle = Random.Range(0, kBlockNum);
            
            switch(Random.Range(0, kDirNum))
            {
                case 0:// 上
                    // 動かせたら位置を変える
                    if (MoveCheck(kDirUp))  ChangeTrs(_nowEle + kDirUp);
                    // 動かせなかったらもう一度
                    // もう一度しないと奇数回シャッフルの時があり、クリア不可になる
                    else                    i--;
                    break;
                case 1:// 下
                    if (MoveCheck(kDirDown))    ChangeTrs(_nowEle + kDirDown);
                    else                        i--;
                    break;
                case 2:// 右
                    if (MoveCheck(kDirRight))   ChangeTrs(_nowEle + kDirRight);
                    else                        i--;
                    break;
                case 3:// 左
                    if (MoveCheck(kDirLeft))    ChangeTrs(_nowEle + kDirLeft);
                    else                        i--;
                    break;
                default:
                    // ここには来ない
                    break;
            }
        }
    }

    private void Update()
    {
        // プレイヤーの移動処理
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _player.transform.position += Vector3.up * kSpeed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            _player.transform.position += Vector3.down * kSpeed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _player.transform.position += Vector3.right * kSpeed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _player.transform.position += Vector3.left * kSpeed;
        }

        // クリアしていたら移動以外処理しない
        if (_isCreal) return;


        // 特定のボタンを押したらギミックの処理
        // その時入れ替え処理をしていない
        if (Input.GetKeyDown(KeyCode.F) && !_isChange)
        {
            // 現在プレイヤーの手がある位置を保存
            _nowEle = _player.GetComponent<GimmickHand>().GetEleNum();

            // 動かせるかどうかの判定をしていく
            EleCheck();
        }
    }

    private void FixedUpdate()
    {
        // クリアしていたら処理しない
        if (_isCreal) return;

        if (_isChange)
        {
            _moveCount++;

            // 少しずつ動かしていく
            _gimmickObj[_eles[_moveEle]].transform.position += _tempPos2;

            // 時間がたったら動かないようにする
            if (kMoveFrame <= _moveCount) _isChange = false;

            // 動き終わるまで下の処理は行わないようする
            return;
        }

        // 要素が番号通りに並んでいるか確認
        for (int i = 0; i < kBlockNum; i++)
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
        if (_eles[_nowEle] == kBlockNum - 1) return;

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
        // その方向に動かせるかの確認
        if (!MoveCheck(dir)) return false;

        // dirの方向のものが空白の場合動かす
        if (_eles[_nowEle + dir] == kBlockNum - 1)
        {
            ChangeTrs(_nowEle + dir, false);

            return true;
        }

        return false;
    }

    bool MoveCheck(int dir)
    {
        // 要素数ないにいなければ確認しない
        if ((_nowEle + dir) < 0 ||
            kBlockNum <= (_nowEle + dir))
        {
            return false;
        }
        // 左右の場合端にあれば確認しない
        if (dir == kDirLeft &&
            (_nowEle % kRaw) == 0)
        {
            return false;
        }
        if (dir == kDirRight &&
            (_nowEle % kRaw) == (kRaw - 1))
        {
            return false;
        }

        // ここまで来たら動かせる位置にいる
        return true;
    }

    // 位置の変更
    // 要素一つ目、要素二つ目
    private void ChangeTrs(int ele, bool isShuffle = true)
    {
        // それぞれの位置を保存.
        _tempPos1 = _gimmickObj[_eles[_nowEle]].transform.position;
        _tempPos2 = _gimmickObj[_eles[ele]].transform.position;

        // 保存した位置を使い、位置の入れ替え
        // 空白地はすぐに移動
        _gimmickObj[_eles[ele]].transform.position = _tempPos1;
        if (isShuffle) _gimmickObj[_eles[_nowEle]].transform.position = _tempPos2;
        else MoveEfeStart(ele);

        // 要素の番号を変更.
        _tempEle = _eles[_nowEle];
        _eles[_nowEle] = _eles[ele];
        _eles[ele] = _tempEle;
    }

    void MoveEfeStart(int ele)
    {
        // 動く配列を選択する
        _moveEle = ele;
        // カウントの初期化
        _moveCount = 0;

        // 動く位置までベクトルを求め、移動時間で割る
        _tempPos2 = _tempPos2 - _tempPos1;
        _tempPos2 /= kMoveFrame;

        // 動くようにする
        _isChange = true;
    }
}
