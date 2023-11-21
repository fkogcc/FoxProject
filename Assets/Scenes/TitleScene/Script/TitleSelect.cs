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
    private const float kRangeY = 128.0f;
    // Mainなら追加の分
    private const float kAddRage = 64f;

    public bool IsMain;

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
    public void SelectUpdate()
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
    }

    private void MoveFrame()
    {
        if (_index == 0)
        {
            _move.y = kRangeY;
            if (IsMain)
            {
                _move.y += kAddRage;
            }
        }
        else
        {
            _move.y = -kRangeY;
            if (IsMain)
            {
                _move.y -= kAddRage;
            }
        }

        _rect.localPosition += _move;
    }

    public int GetIndex() 
    {
        return _index; 
    }
}
