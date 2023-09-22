using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimick1_1_1Manager : MonoBehaviour
{
    // ハンドルの位置を変更.
    [SerializeField] private GameObject[] _testHandle;
    // ハンドルの判定.
    [SerializeField] private GameObject[] _testCollHandle;

    // ハンドルの近くでボタンをおしたかどうか.
    private bool[] _isButtonHandle = {false,false};
    // 壁の近くでボタンをおしたかどうか.
    private bool[] _isButtonWall = { false, false };
    // 回転を始める.
    private bool[] _isRota = { false, false };
    // 最後まで回転を行った.
    private bool[] _isEndRota = { false, false };
    // 1フレーム隙を与える.
    private bool[] _isOneFrameStop = { false, false };
    // 壁の名前.
    private string[] _handleWallName = {"HandleWall0","HandleWall1"};
    // fot文に使用する最大数.
    private int _maxNum;
    // Start is called before the first frame update.
    void Start()
    {
        string objName = "3DPlayer";
        _testCollHandle[0].GetComponent<CollsionHandle>().SetNameColl(objName);
        _testCollHandle[1].GetComponent<CollsionHandle>().SetNameColl(objName);
        _maxNum = 2;
    }

    private void Update()
    {
        for (int i = 0; i < _maxNum; i++)
        {
            // ハンドルを入手していない場合.
            if (!_isButtonHandle[i])
            {
                // ハンドルに当たっていたら.
                if (_testCollHandle[i].GetComponent<CollsionHandle>().IsGetHit())
                {
                    // ボタンを押したら.
                    if (Input.GetKeyDown(KeyCode.JoystickButton1))
                    {
                        _isButtonHandle[i] = true;
                        _testCollHandle[i].GetComponent<CollsionHandle>().SetNameColl(_handleWallName[i]);
                        _testCollHandle[i].GetComponent<CollsionHandle>().SetHit(false);
                    }
                }
            }
            // ハンドルを入手した場合.
            if (_isButtonHandle[i] && !_isEndRota[i])
            {
                _testHandle[i].GetComponent<HandlePos>().HandlePosIsPlayer();
                if (_testCollHandle[i].GetComponent<CollsionHandle>().IsGetHit())
                {
                    // ボタンを押したら.
                    if (Input.GetKeyDown(KeyCode.JoystickButton1))
                    {
                        _isButtonWall[i] = true;
                    }
                }
            }
            // ハンドルを差し込んだ場合.
            if (_isButtonWall[i] && !_isEndRota[i])
            {
                _testHandle[i].GetComponent<HandlePos>().HandlePosIsHandleWall(i);
                // 回転を始める.
                if (Input.GetKeyDown(KeyCode.JoystickButton1) && _isOneFrameStop[i])
                {
                    // 回転指示
                    _isRota[i] = true;
                }
                // 回転開始.
                if (_isRota[i])
                {
                    // 回転速度.
                    _testHandle[i].GetComponent<HandlePos>().Rota(0.3f);
                    // 回転時間.
                    if (_testHandle[i].GetComponent<HandlePos>().IsGetRotaTimeOver(2000))
                    {
                        // 回転終了.
                        _isEndRota[i] = true;
                    }
                }
                // ボタンを一度とめる.
                _isOneFrameStop[i] = true;
            }
        }
        // 謎解きが終わったかどうか.
        if (_isEndRota[0] && _isEndRota[1])
        {
            //Debug.Log("シーンを切り替えてもいいよ？？？");
        }
    }
}
