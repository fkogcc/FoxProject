using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullRope : MonoBehaviour
{
    Rigidbody _rb;
    GameObject _player;
    Vector3 _playerPos;
    bool _isFlag;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _player = GameObject.Find("3DPlayer");
        _isFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(_isFlag)
        {
            _playerPos = _player.transform.position;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        _isFlag = true;
    }
}
