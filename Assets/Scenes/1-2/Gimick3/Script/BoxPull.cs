using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPull : MonoBehaviour
{
    // ギミックブロックの長さ
    private const float kGimmickLength = 0.75f;

    // ブロックを追加する距離
    private float _longDis;
    // ブロックを減らす距離
    private float _shortDis;

    // ディレクター.
    private BoxDirector _director;
    // プレイヤーの位置情報.
    private Transform _player;

    // ギミックの色.
    public string Color;
    // ギミックオブジェ.
    private GameObject _gimmick;
    private List<GameObject> _gimmicks;
    // クリアオブジェ.

    // 引っ張れる範囲にいるかの.
    private bool _isPullRange;
    // 引っ張っているか.
    private bool _isPull;

    // ギミッククリアしているか.
    private bool _isClear;

    // 引っ張り始めたギミック位置.
    private Vector3 _startGimmickPos;
    // 引っ張り始めたプレイヤーの位置
    private Vector3 _startPlayerPos;

    // 移動ベクトル.
    private Vector3 _moveVec;
    // 角度を入れるよう
    private float _angle = 0.0f;

    void Start()
    {
        _director = GameObject.Find("GimmickDirector").GetComponent<BoxDirector>();

        _player = GameObject.Find("3DPlayer").GetComponent<Transform>();

        // クリア前までのオブジェ.
        _gimmick = (GameObject)Resources.Load(Color + "Cube");

        _gimmicks = new List<GameObject>();

        _longDis = 0.0f;
        _shortDis = 0.0f;

        // クリア後のオブジェ.
//        _clearObj = (GameObject)Resources.Load(Color + "Cylinder");

        // bool関係をすべてfalseに.
        _isPullRange = false;
        _isPull = false;
        _isClear = false;

        _startGimmickPos = new Vector3();
        _startPlayerPos = new Vector3();
        _moveVec = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        // ギミックをクリアしていたら処理をしない.
        if (_isClear) return;

        if ((Input.GetKeyDown("joystick button 1") || Input.GetKeyDown(KeyCode.F)) && _isPullRange)
        {
            // 引っ張り始めた位置の保存.
            _startPlayerPos = _player.position;

            _gimmicks.Add(Instantiate(_gimmick, this.transform.position, Quaternion.identity));
            _shortDis = 0;
            _longDis = kGimmickLength;

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
                //                Instantiate(_clearObj);

                //// 位置をきれいになるように整形.
                ObjPlacement(_director.GetGimmickPos(), _startGimmickPos);
            }
            else
            {
                // オブジェクトを削除する
                foreach (var temp in _gimmicks)
                {
                    Destroy(temp.gameObject);
                }
                _gimmicks.Clear();
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
            ObjPlacement(_player.position, _startPlayerPos);
        }
    }

    // 範囲内に入った場合引っ張れるようにする.
    void OnTriggerEnter(Collider other)
    {
        _isPullRange = true;
        _startGimmickPos = this.transform.position;
    }

    // 範囲外に出たら引っ張れないようにする.
    void OnTriggerExit(Collider other)
    {
        _isPullRange = false;
    }

    // 移動量分ずらしてオブジェクトの設置.
    void ObjPlacement(Vector3 targetPos, Vector3 startPos)
    {
        // 現在までのベクトルを計算.
        _moveVec = targetPos - startPos;

        float _nowLength = _moveVec.magnitude;
        // 距離が伸びたら追加する.
        while (true)
        {
            if (_longDis <= _nowLength)
            {
                // 判定距離の更新.
                _longDis += kGimmickLength;
                _shortDis += kGimmickLength;

                // ブロックの追加.
                _gimmicks.Add(Instantiate(_gimmick, this.transform.position, Quaternion.identity));
                continue;
            }
            // 距離が減ったら削除する.
            else if (_nowLength < _shortDis)
            {
                // 判定距離の更新.
                _longDis -= kGimmickLength;
                _shortDis -= kGimmickLength;

                // GameObjectを削除ののち、リストから削除.
                Destroy(_gimmicks[_gimmicks.Count - 1]);
                _gimmicks.RemoveAt(_gimmicks.Count - 1);
                continue;
            }
            break;
        }

        // 角度を求める.
        _angle = Mathf.Atan2(_moveVec.z, _moveVec.x) * Mathf.Rad2Deg * -1;

        // 出すオブジェクトの量で割る.
        _moveVec /= _gimmicks.Count;

        for (int i = 0; i < _gimmicks.Count; i++)
        {
            _gimmicks[i].transform.position = this.transform.position + _moveVec * (i + 1);
            _gimmicks[i].transform.rotation = Quaternion.AngleAxis(_angle, new Vector3(0.0f, 1.0f, 0.0f));
        }
    }
}
