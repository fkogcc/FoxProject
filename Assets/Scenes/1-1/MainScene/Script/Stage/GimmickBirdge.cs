using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickBirdge : MonoBehaviour
{
    // 橋の通路
    // 左
    [SerializeField] private GameObject _birdgeLeft;
    // 右
    [SerializeField] private GameObject _birdgeRight;
    // ギミックを解いたかどうかのデバッグ用処理
    [SerializeField] private bool _isSuccessGimmick;

    // Start is called before the first frame update
    void Start()
    {
        _isSuccessGimmick = false;
    }

    // Update is called once per frame
    void Update()
    {
        // 橋が架かると以降処理しない
        if (_birdgeLeft.transform.localEulerAngles == new Vector3(0.0f, 0.0f, 0.0f) ||
           _birdgeRight.transform.localEulerAngles == new Vector3(0.0f, 0.0f, 0.0f))
            return;

        // ギミックを解いていないと処理しない
        if(!_isSuccessGimmick) return;

        RotateBirdgeAisleLeft();
        RotateBirdgeAisleRight();
    }

    private void RotateBirdgeAisleLeft()
    {
        _birdgeLeft.transform.Rotate(0,0,-1);

        if(_birdgeLeft.transform.localEulerAngles  == new Vector3(0.0f,0.0f,0.0f))
        {
            _isSuccessGimmick = false;
        }
    }

    private void RotateBirdgeAisleRight()
    {
        _birdgeRight.transform.Rotate(0, 0, 1);

        if (_birdgeRight.transform.localEulerAngles == new Vector3(0.0f, 0.0f, 0.0f))
        {
            _isSuccessGimmick = false;
        }
    }
}
