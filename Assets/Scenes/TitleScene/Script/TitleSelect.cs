using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TitleSelect : MonoBehaviour
{
    // GameStartとOption
    private const int kSelectNum = 2;
    // 上下の幅
    private const float kRangeY = 164.0f;

    public TitleManager Manager;

    private int _index;
    private bool _isUpPush;
    private bool _isDownPush;

    Vector3 _move;

    RectTransform _rect;
    
    void Start()
    {
        _index = 0;
        _isUpPush = false;

        _move = new Vector3();

        _rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Vertical") == 1)
        {
            if (!_isUpPush)
            {
                _isUpPush = true;
                _index = (kSelectNum + _index - 1) % kSelectNum;

                MoveFrame();
            }
        }
        else
        {
            _isUpPush = false;
        }

        if (Input.GetAxisRaw("Vertical") == -1)
        {
            if (!_isDownPush)
            {
                _isDownPush = true;
                _index = (_index + 1) % kSelectNum;

                MoveFrame();
            }
        }
        else
        {
            _isDownPush = false;
        }

        if (Input.GetKeyDown("joystick button 1"))
        {
            if (_index == 0)
            {
                Manager.OnStart();
            }
            else
            {
                Manager.OnOption();
            }
        }
    }

    private void MoveFrame()
    {
        if (_index == 0)
        {
            _move.y = kRangeY;
        }
        else
        {
            _move.y = -kRangeY;
        }

        _rect.position += _move;
    }
}
