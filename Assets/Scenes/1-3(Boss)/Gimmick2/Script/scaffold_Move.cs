using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaffold_Move : MonoBehaviour
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
    private float _moveZ;

    public GameObject _player;

    private bool _isMove; 
    void Start()
    {
        _count = 0;
        _myTransform = this.transform;
        _pos = _myTransform.position;
        _time = 300;
        _moveZ = 0.08f;
        _isMove = false;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        

        //5秒経ったら.
        if (!_isMove)
        {
            // z座標へ0.08減算.
            _pos.z += _moveZ;
            // 座標を設定.
            _myTransform.position = _pos;  
        }
        //10秒経ったら.
        else
        {
            // z座標へ0.08加算.
            _pos.z -= _moveZ;
            // 座標を設定.
            _myTransform.position = _pos;  
        }
        if(_myTransform.position.z >= 15.0)
        {
            _isMove = true;
        }
        if (_myTransform.position.z <= -7.0)
        {
            _isMove = false;
        }
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

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == _player.tag)
        {
            _player.transform.parent = null;
        }
    }
}
