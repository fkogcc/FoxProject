using Microsoft.Cci;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideGimmickDirector : MonoBehaviour
{
    /* スティック情報 */
    // 垂直方向.
    private float _vertical;
    // 水平方向.
    private float _horizontal;
    // プレイヤーの動く量.
    private const float kSpeed = 0.125f;

    // 横に並んでいるブロックの数.
    private const int kRaw = 4;
    // 縦に並んでいるブロックの数.
    private const int kCol = 4;
    // ブロックの総数.
    private const int kBlockNum = kRaw * kCol;
    // 最後のブロックを空白とする.
    private const int kNoneBlockNo = kBlockNum - 1;
    // -1をひとつ前に戻るボタンとしておく
    private const int kBackOneStepNo = -1;
    // -2をリセットボタンとしておく
    private const int kResetNo = -2;

    // 現在の手の位置からの上下左右.
    private const int kDirUp = -kRaw;
    private const int kDirDown = kRaw;
    private const int kDirLeft = -1;
    private const int kDirRight = 1;
    // 上下左右の方向の数.
    private const int kDirNum = 4;

    // 入れ替えにかけるフレーム数.
    private const int kMoveFrame = 10;

    // プレイヤー.
    private GameObject _player;

    // ギミック親オブジェ.
    private GameObject _parentObj;
    // ギミック子オブジェ.
    private GameObject[] _gimmickObj;

    // 要素の番号.
    private int[] _eles;

    // 現在の要素.
    private int _nowEle;

    // はじめの要素情報を入れるよう.
    private int[] _startEles;
    // ひとつ前に動かした場所情報1
    Stack<int> _endEle1;
    // ひとつ前に動かした場所情報2
    Stack<int> _endEle2;

    // 入れ替え用.
    private Vector3 _tempPos1;
    private Vector3 _tempPos2;
    private int _tempEle;

    // 入れ替え時間カウント用.
    private int _moveCount;
    private int _moveEle;
    // 入れ替えをしているか.
    private bool _isChange;

    // クリアしているかしていないか.
    private bool _isCreal;

    private bool _isMove;

    private GameObject _lightGimmick;
    private MeshRenderer[] _render;
    float _alpha;
    Color _color;

    private void Start()
    {
        // 初期化
        _vertical = 0.0f;
        _horizontal = 0.0f;
        _player = new GameObject();

        _parentObj = new GameObject();
        _gimmickObj = new GameObject[kBlockNum];

        _eles = new int[kBlockNum];

        _nowEle = kNoneBlockNo;

        _startEles = new int[kBlockNum];
        _endEle1 = new Stack<int>();
        _endEle2 = new Stack<int>();

        _tempPos1 = new Vector3();
        _tempPos2 = new Vector3();
        _tempEle = 0;

        _moveCount = 0;
        _moveEle = 0;
        _isChange = false;

        _isCreal = false;
        _isMove = false;

        _lightGimmick = GameObject.Find("LightBox");
        _render = new MeshRenderer[kBlockNum];
        for (int i = 0; i < kBlockNum; i++)
        {
            _render[i] = _lightGimmick.transform.GetChild(i).GetComponent<MeshRenderer>();
        }
        

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

        int[] _dirNum = { kDirDown, kDirUp, kDirLeft, kDirRight };
        int _changeDir;

        // シャッフル.
        for (int i = 0; i < 48; i++)
        {
            // 0~空白地前までのブロックで動かすようにする.
            _nowEle = Random.Range(0, kNoneBlockNo);

            // 動かす位置が空白でない場合のみ動かす.
            // 動かせないor空白地である場合は
            // もう一度繰り返し処理を行うようにする.
            // 繰り返すのは奇数回しか動かしていない場合積み配置が出来てしまうため.
            _changeDir = _dirNum[Random.Range(0, kDirNum)];
            if (MoveCheck(_changeDir, true)) ChangeTrs(_nowEle + _changeDir, false);
            else i--;
        }

        // 初めの状態を保存
        for (int i = 0; i < kBlockNum; i++)
        {
            _startEles[i] = _eles[i];
        }
        _alpha = 0.02f;
        _color = Color.yellow;
    }

    private void Update()
    {
        if (Input.GetKeyDown("joystick button 1")) _isMove ^= true;

        if (!_isMove) return;

        // 垂直方向.
        _vertical = Input.GetAxis("Horizontal");
        // 水平方向.
        _horizontal = Input.GetAxis("Vertical");

        // プレイヤーの移動処理.
        if (0.0f < _horizontal)
        {
            _player.transform.position += Vector3.up * kSpeed;
        }
        if (_horizontal < 0.0f)
        {
            _player.transform.position += Vector3.down * kSpeed;
        }
        if (0.0f < _vertical)
        {
            _player.transform.position += Vector3.right * kSpeed;
        }
        if (_vertical < 0.0f)
        {
            _player.transform.position += Vector3.left * kSpeed;
        }

        // クリアしていたら移動以外処理しない.
        if (_isCreal) return;

        // 入れ替えしていたら処理しない.
        if (_isChange) return;

        // 特定のボタンを押したらギミックの処理.
        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown("joystick button 0"))
        {
            // 現在プレイヤーの手がある位置を保存.
            _nowEle = _player.GetComponent<GimmickHand>().HitNo;

            if (_nowEle == kBackOneStepNo)
            {
                Debug.Log("ひとつ前に戻る");
                BackOneStep();
            }
            else if (_nowEle == kResetNo)
            {
                ResetBlock();
            }
            else
            {
                // 動かせるかどうかの判定をしていく.
                EleCheck();
            }
        }
    }

    private void FixedUpdate()
    {
        // クリアしていたら光らせる処理のみする.
        if (_isCreal)
        {
            if (1.0f <= _color.r) _alpha *= -1;
            if (_color.r <= 0.0f) _alpha *= -1;

            _color.r += _alpha;
            _color.g += _alpha;

            for (int i = 0; i < kBlockNum; i++)
            {
                _render[i].material.EnableKeyword("_EMISSION");
                _render[i].material.SetColor("_EmissionColor", _color);
            }
            return;
        }

        if (_isChange)
        {
            _moveCount++;

            // 少しずつ動かしていく.
            _gimmickObj[_eles[_moveEle]].transform.position += _tempPos2;

            // 時間がたったら動かないようにする.
            if (kMoveFrame <= _moveCount) _isChange = false;

            // 動き終わるまで下の処理は行わないようする.
            return;
        }

        // 要素が番号通りに並んでいるか確認.
        for (int i = 0; i < kBlockNum; i++)
        {
            // 要素番号通りでないならここでの処理終了.
            if (_eles[i] != i) return;
        }

        // ここまで来たらクリアしているので完了とする.
        _isCreal = true;
        Debug.Log("クリア");
    }

    // 1つ前の情報に戻す
    private void BackOneStep()
    {
        // データが入ってない場合はやらない
        if (_endEle1.Count <= 0) return;

        Debug.Log("変えるよ");
        _nowEle = _endEle1.Pop();
        ChangeTrs(_endEle2.Pop(), false);
    }

    // はじめの状態に戻す
    private void ResetBlock()
    {
        for (int i = 0; i < kBlockNum; i++)
        {
            _nowEle = i;

            // 現在の位置の物がはじめと一緒の場合次のに移る
            if (_eles[i] == _startEles[_nowEle]) continue;

            // それ以外は探しだす
            for (int j = i + 1; j < kBlockNum; j++)
            {
                // 初めの場所を見つけたらそこと場所替え
                if (_eles[j] == _startEles[_nowEle])
                {
                    ChangeTrs(j, false);

                    // 探し作業終了
                    break;
                }
            }
        }

        // 1つ前に戻したという情報を全て消去
        _endEle1.Clear();
        _endEle2.Clear();
    }

    private void EleCheck()
    {
        // 要素番号の位置が空白地なら何もしない.
        if (_eles[_nowEle] == kNoneBlockNo) return;

        // 上のチェック.
        if (DirCheck(kDirUp)) return;
        // 下のチェック.
        if (DirCheck(kDirDown)) return;
        // 左のチェック.
        if (DirCheck(kDirLeft)) return;
        // 右のチェック.
        if (DirCheck(kDirRight)) return;
    }

    // その方向に動かせるかどうか.
    private bool DirCheck(int dir)
    {
        // その方向に動かせるかの確認.
        if (!MoveCheck(dir, false)) return false;
        
        ChangeTrs(_nowEle + dir, true);

        return true;
    }

    // 方向の細かいチェック.
    // 動かす向き、シャッフルかどうか.
    bool MoveCheck(int dir, bool isShuffle)
    {
        // 要素数ないにいなければ確認しない.
        if ((_nowEle + dir) < 0 ||
            kBlockNum <= (_nowEle + dir))
        {
            return false;
        }
        // 左右の場合端にあれば確認しない.
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

        // シャッフルの場合.
        if (isShuffle)
        {
            // dirの方向のものが空白以外の場合動かす.
            if (_eles[_nowEle + dir] != kNoneBlockNo)
            {
                return true;
            }
        }
        else
        // シャッフルでない場合.
        {
            // dirの方向のものが空白の場合動かす.
            if (_eles[_nowEle + dir] == kNoneBlockNo)
            {
                return true;
            }
        }

        return false;

    }

    // 位置の変更.
    // 動かす位置、シャッフルかどうか.
    private void ChangeTrs(int ele, bool isNormal)
    {
        // それぞれの位置を保存.
        _tempPos1 = _gimmickObj[_eles[_nowEle]].transform.position;
        _tempPos2 = _gimmickObj[_eles[ele]].transform.position;

        // 保存した位置を使い、位置の入れ替え.
        // 空白地はすぐに移動.
        _gimmickObj[_eles[ele]].transform.position = _tempPos1;
        // 通常の動き以外すぐに動かす.
        if (!isNormal) _gimmickObj[_eles[_nowEle]].transform.position = _tempPos2;
        // 通常の場合は動きを実装.
        else MoveEfeStart(ele);

        // 通常の動きの場合は動かした情報位置を保存する.
        if (isNormal)
        {
            _endEle1.Push(_nowEle);
            _endEle2.Push(ele);
        }
        // 要素の番号を変更.
        _tempEle = _eles[_nowEle];
        _eles[_nowEle] = _eles[ele];
        _eles[ele] = _tempEle;
    }

    void MoveEfeStart(int ele)
    {
        // 動く配列を選択する.
        _moveEle = ele;
        // カウントの初期化.
        _moveCount = 0;

        // 動く位置までベクトルを求め、移動時間で割る.
        _tempPos2 = _tempPos2 - _tempPos1;
        _tempPos2 /= kMoveFrame;

        // 動くようにする.
        _isChange = true;
    }
}
