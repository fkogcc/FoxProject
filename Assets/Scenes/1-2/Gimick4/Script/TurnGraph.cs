using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurnGraph : MonoBehaviour
{
    // ‰ñ“]–½—ß
    private bool _connected = false;
    // ‰ñ“]—Ê
    private float _rota = 0.0f;
    // ‰ñ“]—Ê•Û‘¶
    private float _tempRota = 0.0f;

    void Update()
    {       
        if (_connected)
        {
            if (_rota >= _tempRota + 90.0f)
            {
                _connected = false;
                _tempRota = _rota;
            }
            else
            {
                _rota += 1.0f;
                this.transform.Rotate(0.0f, 0.0f, 1.0f);
            }
        }
    }

    public void Rota()
    {
        _connected = true;
    }
}
