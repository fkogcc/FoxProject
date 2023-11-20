using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAnimePlayer : MonoBehaviour
{
    // 動くフレーム
    private const int kMoveFrame = 50 * 2;
    // 初めのダッシュフレーム
    private const int kRunFrame = kMoveFrame;
    // 正面向かせるフレーム
    private const int kRotFrontFrame = kRunFrame + 50 * 1;
    // 座り込んでる(Deadの)フレーム
    private const int kDeadFrame = kRotFrontFrame + 50 * 10;
    // 戻る方向向くフレーム
    private const int kRotOutRageFrame = kDeadFrame + 50 * 1;
    // まえに進むフレーム
    private const int kMoveFrontFrame = kRotOutRageFrame + kMoveFrame;
    // 画面内にダッシュするほうを向くフレーム
    private const int kRotStartFrame = kMoveFrontFrame + 50 * 1;
    // プレイヤーの待機時間
    private const int kWaitFrame = kRotStartFrame + 50 * 10;

    private int _frame;
    private PlayerAnim _anim;

    private Vector3 _move;

    private Quaternion _rotFront;
    private Quaternion _rotOutRage;
    private Quaternion _rotStart;

    void Start()
    {
        _frame = 0;
        _anim = GetComponent<PlayerAnim>();

        _move = new Vector3(10f / kMoveFrame, 0, 0);

        float angle = -60.0f / (kRotFrontFrame - kRunFrame);
        _rotFront = Quaternion.AngleAxis(angle, new Vector3(0, 1.0f, 0)); ;
        angle = -90.0f / (kRotOutRageFrame - kDeadFrame);
        _rotOutRage = Quaternion.AngleAxis(angle, new Vector3(0, 1.0f, 0));
        angle = 150f / (kRotStartFrame - kMoveFrontFrame);
        _rotStart = Quaternion.AngleAxis(angle, new Vector3(0, 1.0f, 0));
    }

    public void Update()
    {
        _frame++;

        // 画面外から画面内にダッシュ
        if (_frame < kRunFrame)
        {
            _anim._run = true;
            this.transform.position += -_move;
        }
        // 正面向かる
        else if (_frame < kRotFrontFrame)
        {
            _anim._run = false;
            this.transform.rotation = this.transform.rotation * _rotFront;
        }
        // 座り込む
        else if (_frame < kDeadFrame)
        {
            _anim._isDead = true;
        }
        // 画面外に向かせる
        else if (_frame < kRotOutRageFrame)
        {
            _anim._isDead = false;
            this.transform.rotation = this.transform.rotation * _rotOutRage;
        }
        // 画面外にダッシュ
        else if (_frame < kMoveFrontFrame)
        {
            _anim._run = true;
            this.transform.position += _move;
        }
        // 元の方向を向かせる
        else if (_frame < kRotStartFrame)
        {
            _anim._run = false;
            this.transform.rotation = this.transform.rotation * _rotStart;
        }
        // 何もしない
        else if (_frame < kWaitFrame)
        {
        }
        else
        {
            _frame = 0;
        }
    }
}
