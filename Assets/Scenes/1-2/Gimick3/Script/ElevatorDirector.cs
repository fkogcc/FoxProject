using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDirector : MonoBehaviour
{
    private const int kChangeFrame = 50;

    private Vector3 _vec;

    private int _upCount;
    private int _downCount;
    private bool _isStay;
    private bool _isUp;
    private bool _isDown;

    private void Start()
    {
        _vec = new Vector3(0f, 0.125f, 0f);

        _upCount = 0;

        _isStay = false;
        _isUp = false;
        _isDown = false;

    }

    private void FixedUpdate()
    {
        if (_isStay)
        {
            _upCount++;
            if (kChangeFrame <= _upCount) _isUp = true;
        }
        else
        {
            _downCount++;
            if (kChangeFrame <= _downCount) _isDown = true;
        }

        // 上がる処理
        if (_isUp)
        {
            if (this.transform.position.y < 13f)
                this.transform.position += _vec;
        }
        // 降りる処理
        if (_isDown)
        {
            if (6.8f < this.transform.position.y)
                this.transform.position -= _vec;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _isStay = true;
        _upCount = 0;
    }

    private void OnTriggerExit(Collider other)
    {
        _isStay = false;
        _downCount = 0;
    }
}
