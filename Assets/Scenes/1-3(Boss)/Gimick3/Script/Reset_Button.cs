using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset_Button : MonoBehaviour
{
    //それぞれのオブジェクト.
    public GameObject _stage2_Blue_Container;
    public GameObject _stage2_Red_Container;
    public GameObject _stage2_Green_Container;
    public GameObject _stage2_Yellow_Container;

    public Vector2 _stage2_Blue_InitialPosition;
    public Vector2 _stage2_Red_InitialPosition;
    public Vector2 _stage2_Green_InitialPosition;
    public Vector2 _stage2_Yellow_InitialPosition;
    //public GameObject _stage2_Red_Container;

    // Start is called before the first frame update
    void Start()
    {
        _stage2_Blue_InitialPosition = _stage2_Blue_Container.transform.position;
        _stage2_Red_InitialPosition = _stage2_Red_Container.transform.position;
        _stage2_Green_InitialPosition = _stage2_Green_Container.transform.position;
        _stage2_Yellow_InitialPosition = _stage2_Yellow_Container.transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "3DPlayer")
        {
            if (Input.GetKeyDown("joystick button 2"))
            {
                Debug.Log("OK");
                _stage2_Blue_Container.transform.position = _stage2_Blue_InitialPosition;
                _stage2_Red_Container.transform.position = _stage2_Red_InitialPosition;
                _stage2_Green_Container.transform.position = _stage2_Green_InitialPosition;
                _stage2_Yellow_Container.transform.position = _stage2_Yellow_InitialPosition;
            }
        }
    }
}
