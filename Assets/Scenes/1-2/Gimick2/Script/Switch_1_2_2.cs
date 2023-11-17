using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Switch_1_2_2 : MonoBehaviour
{

    // プレイヤーがオブジェクトに当たったかどうか.
    private bool _isHit = false;

    // レバーを倒すかどうか.
    private bool _isLabor = false;

    // レーバー取得用.
    private GameObject _LaborRota;

    // レーバーの角度記録.
    private bool _isMinusRota = false;

    // 画像クラスを取得.
    public Image _meter;

    // メーターの速度.
    public float _meterSpeed;

    // ギミックをクリアしたかどうか.
    private bool _isResult = false;

    void Start()
    {
        // オブジェクト取得. 
        _LaborRota = GameObject.Find("stage03_lever_02/locator1");
    }

    private void Update()
    {
        // ボタンを押したら.
        if (Input.GetKeyDown("joystick button 1") && _isHit)
        {
            _isLabor = true;
        }
    }

    private void FixedUpdate()
    {
        if (_isLabor)
        {
            // レーバーの角度を調整.
            if(_LaborRota.transform.localEulerAngles.x >= 310.0f)
            {
                _LaborRota.transform.Rotate(1.0f,0.0f, 0.0f); 
            }
            else
            {
                // 角度が0.0fになったら.
                _isMinusRota =true;
            }

            // レーバーの角度を調整.
            if (_isMinusRota)
            {
                if (_LaborRota.transform.localEulerAngles.x < 50.0f)
                {
                    _LaborRota.transform.Rotate(1.0f, 0.0f, 0.0f);
                }
                else
                {
                    // 角度が50.0fになったら.
                    _isResult = true;
                }
            }
            // メーターを動かす.
            _meter.fillAmount += _meterSpeed;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // プレイヤーだったら.
        if (other.gameObject.tag == "Player")
        {
            _isHit = true;
            return;            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // プレイヤーだったら.
        if (other.gameObject.tag == "Player")
        {
            _isHit = false;
            return;
        }
    }

    // ギミックをクリアしたかどうか.
    public bool GetResult()
    {
        return _isResult;
    }
}
