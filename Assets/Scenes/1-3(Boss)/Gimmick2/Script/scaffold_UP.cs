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
    void Start()
    {
        _count = 0;
        _myTransform = this.transform;
        _pos = _myTransform.position;
        _time = 150;
        _moveY = 0.05f;
        _isMoving = false;
        _player = GameObject.Find("3DPlayer");
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        //5秒経ったら.
        if (!_isMoving)
        {
            // y座標へ0.08減算.
            _pos.y += _moveY;
            //_player.transform.position.y +=_moveY;
            _player.transform.position += new Vector3(0.0f, _moveY, 0.0f);
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
        Debug.Log(_myTransform.position.y);

        if (_myTransform.position.y <= 15.0)
        {
            _isMoving = false;
        }
        if (_myTransform.position.y >= 27.0)
        {
            _isMoving = true;
        }
        Debug.Log(_myTransform.position.y);
    }

    void OnCollisionStay(Collision collision)
    {
        Debug.Log("HitOutSidee");
        if (collision.gameObject.tag == _player.tag)
        {
            Debug.Log("Hit");
            _player.transform.SetParent(gameObject.transform);
        }
    }
}
