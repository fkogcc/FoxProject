using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurnGraph : MonoBehaviour
{
    // ‰ñ“]–½—ß.
    private bool _connected = false;
    // ‰ñ“]—Ê.
    private int _rota = 0;
    // ‰ñ“]—Ê•Û‘¶.
    private float _tempRota = 0.0f;
    // ³‰ğ‚ÌŠp“x.
    public int _ansRota;
    // ³‰ğ‚ª–³‚¢‹U•¨‚Ìê‡.
    public bool _isFake;

    void Update()
    {
        // ƒ{ƒ^ƒ“‚ª‰Ÿ‚³‚ê‚½‚ç.
        if (_connected)
        {
            // 90“x‰ñ“]‚µ‚½‚ç~‚ß‚é.
            if (_rota >= _tempRota + 90.0f)
            {
                _connected = false;
                _tempRota = _rota;
            }
            else
            {
                // ‰ñ“]‚³‚¹‚é.
                _rota += 1;
                this.transform.rotation = Quaternion.Euler(90.0f, 0.0f, _rota);
            }
        }

        // 360“x‰ñ“]‚µ‚½‚ç0“x‚É–ß‚·.
        if (_tempRota >= 360.0f)
        {
            _rota = 0;
            _tempRota = 0.0f;
        }
    }

    // ‰ñ“]‚ğ—LŒø‚É‚·‚é.
    public void Rota()
    {
        _connected = true;
    }

    // ‰ñ“]Œ‹‰Ê‚ª³‰ğ‚¾‚Á‚½‚çtrue.
    public bool IsGetAns()
    {
        if (_isFake) return true;

            if (_ansRota == _tempRota)
        {
            return true;
        }

        return false;
    }
}
