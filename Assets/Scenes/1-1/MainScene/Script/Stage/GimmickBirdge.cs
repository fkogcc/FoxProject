// 橋の処理.
// HACK:橋の回転処理をもっとスマートにできそう.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickBirdge : MonoBehaviour
{
    // 橋の通路.
    // 左.
    [SerializeField] private GameObject _birdgeLeft;
    // 右.
    [SerializeField] private GameObject _birdgeRight;
    // ギミックを解いたかどうかのデバッグ用処理.
    [SerializeField] private bool _isSuccessGimmick;

    void Start()
    {
        _isSuccessGimmick = false;
    }

    void Update()
    {
        // 橋が架かると以降処理しない.
        if (_birdgeLeft.transform.localEulerAngles == new Vector3(0.0f, 0.0f, 0.0f) ||
           _birdgeRight.transform.localEulerAngles == new Vector3(0.0f, 0.0f, 0.0f))
            return;

        // ギミックを解いていないと処理しない.
        if(!_isSuccessGimmick) return;
        // 橋の回転.
        RotateBirdgeAisleLeft();
        RotateBirdgeAisleRight();
    }

    // 橋の回転.
    // 左.
    private void RotateBirdgeAisleLeft()
    {
        _birdgeLeft.transform.Rotate(0,0,-1);

        if(_birdgeLeft.transform.localEulerAngles  == new Vector3(0.0f,0.0f,0.0f))
        {
            _isSuccessGimmick = false;
        }
    }

    // 右.
    private void RotateBirdgeAisleRight()
    {
        _birdgeRight.transform.Rotate(0, 0, 1);

        if (_birdgeRight.transform.localEulerAngles == new Vector3(0.0f, 0.0f, 0.0f))
        {
            _isSuccessGimmick = false;
        }
    }
}
