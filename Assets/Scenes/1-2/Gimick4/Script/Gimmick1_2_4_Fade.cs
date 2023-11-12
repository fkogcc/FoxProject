using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gimmick1_2_4_Fade : MonoBehaviour
{
    public GameObject _timeCountDown;
    private Gimmick1_2_4_CountDown _time;
    private Image _image;

    private Color _color;
    void Start()
    {
        _time = _timeCountDown.GetComponent<Gimmick1_2_4_CountDown>();
        _image = GetComponent<Image>();

        _color.r = 0.0f;
        _color.g = 0.0f;
        _color.b = 0.0f;
        _color.a = 1.0f;
    }
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if(!_time.IsCount())
        {
            _color.a -= 0.1f;
        }

        if(_time.GetCountTime() == 0)
        {
            _color.a += 0.1f;
        }

        if(_color.a > 1)
        {
            _color.a = 1;
        }
        if(_color.a < 0)
        {
            _color.a = 0;
        }
        _image.color = _color;
    }
}
