using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullRope : MonoBehaviour
{
    // ギミックブロックの長さ
    private const float kGimmickLength = 0.75f;
    // プレイヤーの位置情報.
    private Transform _player;
    // ギミックオブジェ.
    public GameObject _gimmick;
    private List<GameObject> _gimmicks;
    // ブロックを追加する距離
    private float _longDis;
    // ブロックを減らす距離
    private float _shortDis;
    // 引っ張っているか.
    private bool _isPull;
    // 引っ張り始めた位置.
    private Vector3 _startPos;
    // 移動ベクトル.
    private Vector3 _moveVec;
    // 移動ベクトルを距離に変換
    private float _nowLength;
    // 角度を入れるよう
    private float _angle = 0.0f;
    // 引っ張れる範囲にいるか
    private bool _isFlag;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("3DPlayer").GetComponent<Transform>();

        _gimmicks = new List<GameObject>();

        _longDis = 0.0f;

        _shortDis = 0.0f;
        _isPull = false;
        _isFlag = false;
        _startPos = new Vector3();
        _moveVec = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown("joystick button 1") || Input.GetKeyDown(KeyCode.F)) && _isFlag)
        {
            // 引っ張り始めた位置の保存.
            _startPos = _player.position;

            _gimmicks.Add(Instantiate(_gimmick, this.transform.position, Quaternion.identity));
            _shortDis = 0;
            _longDis = kGimmickLength;

            _isPull = true;
        }
        if ((Input.GetKeyUp("joystick button 1") || Input.GetKeyUp(KeyCode.F)) && _isPull)
        {
            foreach (var temp in _gimmicks)
            {
                Destroy(temp.gameObject);
            }
            _gimmicks.Clear();
            _isPull = false;
        }
    }

    private void FixedUpdate()
    {
        if (_isPull)
        {
            ObjPlacement();
        }
    }
    public float GetNowLength() { return _nowLength; }

    void ObjPlacement()
    {
        // 現在までのベクトルを計算.
        _moveVec = _player.position - _startPos;

        _nowLength = _moveVec.magnitude;
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
    void OnTriggerEnter(Collider other)
    {
        _isFlag = true;
    }
    private void OnTriggerExit(Collider other)
    {
        _isFlag = false;
    }

}
