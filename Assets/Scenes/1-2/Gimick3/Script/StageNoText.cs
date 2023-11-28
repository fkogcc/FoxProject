using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageNoText : MonoBehaviour
{
    private int kStayFrame = 50;
    private float kAlpha = 0.0625f;

    private int _stayFrame;
    private Color _color;

    private void Start()
    {
        _color = GetComponent<Image>().color;
        _stayFrame = kStayFrame;
    }

    private void FixedUpdate()
    {
        _stayFrame--;
        if (_stayFrame < 0)
        {
            _color.a -= kAlpha;
            GetComponent<Image>().color = _color;
            if (_color.a < 0.0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
