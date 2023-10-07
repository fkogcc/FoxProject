using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPull : MonoBehaviour
{
    // ギミックブロックの長さ
    private const float kGimmickLength = 0.75f;

    // ディレクター.
    private BoxDirector _director;
    // ギミックの色.
    public string Color;
    // プレイヤーの位置情報.
    private Transform _player;
    // ギミックオブジェ.
    private GameObject _gimmick;
    private List<GameObject> _gimmicks;
    // ブロックを追加する距離
    private float _longDis;
    // ブロックを減らす距離
    private float _shortDis;
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

        if ((Input.GetKeyDown("joystick button 1") || Input.GetKeyDown(KeyCode.F)) && _isPullRange)
        {
            // 引っ張り始めた位置の保存.
            _startPos = _player.position;

            _gimmicks.Add(Instantiate(_gimmick, this.transform.position, Quaternion.identity));
            _shortDis = 0;
            _longDis = kGimmickLength;

            _director.SetGimmickOut(Color);

            _isPull = true;
        }

        if ((Input.GetKeyUp("joystick button 1") || Input.GetKeyUp(KeyCode.F)) && _isPull)
        {
            foreach (var temp in _gimmicks)
            {
                Destroy(temp.gameObject);
            }
            _gimmicks.Clear();

            // 離した色が引っ張り始めた色と同じか.
            // ギミッククリア範囲内にいるか.
            if (_director.IsSameColor())
            {
                // ギミックをクリアしたことにする.
                _isClear = true;

                // クリア後オブジェを生成.
                Instantiate(_clearObj);

                // 下はクリア後にオブジェクトを変えないでやる方法.
                //// 位置をきれいになるように整形.
                //_moveVec = _director.GetGimmickPos() - this.transform.position;


                //ObjPlacement();
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
        // 現在までのベクトルを計算.
        _moveVec = _player.position - _startPos;

        float _nowLength = _moveVec.magnitude;
        // 距離が伸びたら追加する.
        if (_longDis <= _nowLength)
        {
            // 判定距離の更新.
            _longDis += kGimmickLength;
            _shortDis += kGimmickLength;

            // ブロックの追加.
            _gimmicks.Add(Instantiate(_gimmick, this.transform.position, Quaternion.identity));
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
