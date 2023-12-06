using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaffold_UP : MonoBehaviour
{
    // 秒数を数えるカウント.
    private int _count;
    //Transformを取得.
    private Transform _myTransform;
    // 座標を取得.
    private Vector3 _pos;
    // 5秒の時間.
    private int _time;
    // ギミックの移動量
    private float _moveY;

    private bool _isMoving;

    public GameObject _player;

    // それぞれの最大値.
    private Vector3 _upPosition;
    private Vector3 _downPosition;

    // 一番上か一番下に行った時の処理.
    private int _waitTimer = 0;
    // 待つ最大フレーム
    [SerializeField] private int _waitTimeMax = 75;
    private Vector3 _playerScale = Vector3.zero;
    // プレイヤーが乗っているかどうか.
    //private bool _isPlayerCol;
    void Start()
    {

        _count = 0;
        _myTransform = this.transform;
        _pos = _myTransform.position;
        _time = 150;
        _moveY = 0.05f;
        _isMoving = false;
        _player = GameObject.Find("3DPlayer");
        _upPosition = new Vector3(this._myTransform.position.x, 14, this._myTransform.position.z);
        _downPosition = new Vector3(this._myTransform.position.x, 6, this._myTransform.position.z);
        _playerScale = new Vector3(_player.transform.localScale.x, _player.transform.localScale.y, _player.transform.localScale.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //5秒経ったら.
        if (!_isMoving)
        {
            // y座標へ0.08減算.
            _pos.y += _moveY;
            // 座標を設定.
            _myTransform.position = _pos;  
        }
        //10秒経ったら.
        else
        {
            // z座標へ0.08加算.
            _pos.y -= _moveY;
            // 座標を設定.
            _myTransform.position = _pos;  
        }
        MoveOverControl();
    }
    private void MoveOverControl()
    {
        // 最大値より上に行かないようにする処理.
        if (_myTransform.position.y <= _downPosition.y)
        {
            _myTransform.position = _downPosition;
            if (TimerWait())
            {
                _isMoving = false;
            }
        }
        // 最大値より下に行かないようにする処理.
        if (_myTransform.position.y >= _upPosition.y)
        {
            _myTransform.position = _upPosition;
            if (TimerWait())
            {
                _isMoving = true;
            }
        }
    }
    // 一番下か一番上に行ったとき数秒待つ処理.
    private bool TimerWait()
    {
        _waitTimer++;
        if(_waitTimer > _waitTimeMax)
        {
            _waitTimer = 0;
            return true;
        }
        return false;
        
    }
    // 中に入った判定.
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == _player.tag)
        {
            _player.transform.SetParent(gameObject.transform);
        }
    }
    // 外に出た判定.
    private void OnCollisionExit(Collision collision)
    {
        _player.transform.localScale = _playerScale;
        // 外に出た判定
        _player.transform.SetParent(null);
    }
}
