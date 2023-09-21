using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimick1_1_1Manager : MonoBehaviour
{

    // ハンドルの判定
    //   private GameObject _collHandle;
    // ハンドルの位置を変更
    //   private GameObject _posChangeHandle;

    [SerializeField] private GameObject[] _testHandle;
    [SerializeField] private GameObject[] _testCollHandle;

    // ハンドルの近くでボタンをおしたかどうか
    private bool[] _isButtonHandle;
    // 壁の近くでボタンをおしたかどうか
    private bool[] _isButtonWall;
    // 回転を始める
    private bool[] _isRota;
    // 最後まで回転を行った
    private bool[] _isEndRota;
    // 1フレーム隙を与える
    private bool[] _isOneFrameStop;
    // Start is called before the first frame update
    void Start()
    {
        //  _testCollHandle 　　 = GameObject.Find("Handle0");
        //  _posChangeHandle = GameObject.Find("Handle0");

        _isButtonHandle[0] = false;
        _isButtonHandle[1] = false;

        _isButtonWall[0] = false;
        _isButtonWall[1] = false;

        _isRota[0] = false;
        _isRota[1] = false;

        _isEndRota[0] = false;
        _isEndRota[1] = false;

        _isOneFrameStop[0] = false;
        _isOneFrameStop[1] = false;

        _testCollHandle[0].GetComponent<CollsionHandle>().SetNameColl("3DPlayer");
        _testCollHandle[1].GetComponent<CollsionHandle>().SetNameColl("3DPlayer");

        
    }



    private void Update()
    {
        for(int i = 0; i > 2; i++)
        {

            // ハンドルを入手していない場合
            if (!_isButtonHandle[i])
            {
                // ハンドルに当たっていたら
                if (_testCollHandle[0].GetComponent<CollsionHandle>().IsGetHit())
                {
                    // ボタンを押したら
                    if (Input.GetKeyDown(KeyCode.JoystickButton1))
                    {
                        _isButtonHandle[i] = true;
                        _testCollHandle[i].GetComponent<CollsionHandle>().SetNameColl("HandleWall0");
                        _testCollHandle[i].GetComponent<CollsionHandle>().SetHit(false);
                    }
                }
            }

            // ハンドルを入手した場合
            if (_isButtonHandle[i] && !_isEndRota[i])
            {
                _testHandle[0].GetComponent<HandlePos>().HandlePosIsPlayer();
                if (_testCollHandle[i].GetComponent<CollsionHandle>().IsGetHit())
                {
                    // ボタンを押したら
                    if (Input.GetKeyDown(KeyCode.JoystickButton1))
                    {
                        _isButtonWall[i] = true;
                    }
                }
            }
     
            // ハンドルを差し込んだ場合
            if (_isButtonWall[i] && !_isEndRota[i])
            {
                _testHandle[0].GetComponent<HandlePos>().HandlePosIsHandleWall();
                // 回転を始める
                if (Input.GetKeyDown(KeyCode.JoystickButton1) && _isOneFrameStop[i])
                {
                    _isRota[i] = true;
                }
                if (_isRota[i])
                {
                    _testHandle[i].GetComponent<HandlePos>().Rota(0.3f);
                    if (_testHandle[i].GetComponent<HandlePos>().IsGetRotaTimeOver(6000))
                    {
                        _isEndRota[i] = true;
                    }
                }
                _isOneFrameStop[i] = true;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    // 謎解きが終わったかどうか
    //public bool isEnd()
    //{
    //    return _isEndRota[;
    //}
}
