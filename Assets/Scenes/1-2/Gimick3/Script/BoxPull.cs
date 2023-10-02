using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPull : MonoBehaviour
{
    // ギミックのコードをつなぐ途中のキューブの数
    private const int kNum = 20;

    // ディレクター.
    private BoxDirector _director;
    // ギミックの色.
    public string Color;
    // プレイヤーの位置情報.
    private Transform _player;
    // ギミックオブジェ.
    private GameObject _gimmick;
    private GameObject[] _gimmicks = new GameObject[kNum];
    // クリアオブジェ.
    private GameObject _clearObj;
    // 引っ張れる範囲にいるかの.
    private bool _isPullRange;
    // 引っ張っているか.
    private bool _isPull;
    // ギミッククリアしているか.
    private bool _isClear;
    // 引っ張り始めた位置.
    private Vector3 _startPos;
    // 移動ベクトル.
    private Vector3 _moveVec;

    void Start()
    {
        _director = GameObject.Find("GimmickDirector").GetComponent<BoxDirector>();

        _player = GameObject.Find("3DPlayer").GetComponent<Transform>();

        // クリア前までのオブジェ.
        _gimmick = (GameObject)Resources.Load("Cube");

        for (int i = 0; i < kNum; i++)
        {
            _gimmicks[i] = Instantiate(_gimmick, this.transform.position, Quaternion.identity);
        }

        // クリア後のオブジェ.
        _clearObj = (GameObject)Resources.Load(Color + "Cylinder");

        // bool関係をすべてfalseに.
        _isPullRange = false;
        _isPull = false;
        _isClear = false;

        _startPos = new Vector3();
        _moveVec = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        // ギミックをクリアしていたら処理をしない.
        if (_isClear) return;

        if ((Input.GetKeyDown("joystick button 1") || Input.GetKeyUp(KeyCode.F)) && _isPullRange)
        {
            // 引っ張り始めた位置の保存.
            _startPos = _player.position;

            _director.SetGimmickOut(Color);

            _isPull = true;
        }

        if ((Input.GetKeyUp("joystick button 1") || Input.GetKeyUp(KeyCode.F)) && _isPull)
        {
            // 離した色が引っ張り始めた色と同じか.
            // ギミッククリア範囲内にいるか.
            if (_director.IsSameColor())
            {
                // ギミックをクリアしたことにする.
                _isClear = true;

                // クリア後オブジェを生成.
                Instantiate(_clearObj);

                // クリア前オブジェの削除.
                for (int i = 0; i < kNum; i++)
                {
                    Destroy(_gimmicks[i]);
                }

                // 下はクリア後にオブジェクトを変えないでやる方法.
                //// 位置をきれいになるように整形.
                //_moveVec = _director.GetGimmickPos() - this.transform.position;


                //ObjPlacement();
            }
            else
            {
                // 元の位置に戻す.
                for (int i = 0; i < kNum; i++)
                {
                    _gimmicks[i].transform.position = this.transform.position;
                }
            }

            _isPull = false;
        }
    }

    void FixedUpdate()
    {
        // ギミックをクリアしていたら処理をしない.
        if (_isClear) return;

        if (_isPull)
        {
            // 現在までのベクトルを計算.
            _moveVec = _player.position - _startPos;

            ObjPlacement();
        }
    }

    // 範囲内に入った場合引っ張れるようにする.
    void OnTriggerEnter(Collider other)
    {
        _isPullRange = true;
    }

    // 範囲外に出たら引っ張れないようにする.
    void OnTriggerExit(Collider other)
    {
        _isPullRange = false;
    }

    // 移動量分ずらしてオブジェクトの設置.
    void ObjPlacement()
    {
        // 出すオブジェクトの量で割る.
        _moveVec /= kNum;

        // 少しずつずらして位置を置く.
        for (int i = 0; i < kNum; i++)
        {
            _gimmicks[i].transform.position = this.transform.position + _moveVec * (i + 1);
        }
    }
}
