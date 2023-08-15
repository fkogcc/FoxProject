using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class TestFade : MonoBehaviour
{
    
    private Color _color;
    private byte _a;// color‚ÌA

    // Start is called before the first frame update
    void Start()
    {
        _color = gameObject.GetComponent<Image>().color;
        _color.r = 0.0f;
        _color.g = 0.0f;
        _color.b = 0.0f;
        _color.a = 1.0f;
        gameObject.GetComponent<Image>().color = _color;
    }

    // Update is called once per frame
    void Update()
    {
        if(_color.a > 0)
        {
            _color.a -= 0.01f;
            gameObject.GetComponent<Image>().color = _color;
        }
        
        //
    }
}
