using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchFlag : MonoBehaviour
{
    bool _isGearTouch;
    // Start is called before the first frame update
    void Start()
    {
        _isGearTouch = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsGearTouch(bool touch)
    {
        _isGearTouch = touch;
        return _isGearTouch;
    }
}
