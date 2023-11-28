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
    //それぞれのオブジェクトの位置.
    public Vector3 _stage2_Blue_InitialPosition;
    public Vector3 _stage2_Red_InitialPosition;
    public Vector3 _stage2_Green_InitialPosition;
    public Vector3 _stage2_Yellow_InitialPosition;

    
    void Start()
    {
        //それぞれのオブジェクトの初期位置を保存.
        _stage2_Blue_InitialPosition = _stage2_Blue_Container.transform.position;
        _stage2_Red_InitialPosition = _stage2_Red_Container.transform.position;
        _stage2_Green_InitialPosition = _stage2_Green_Container.transform.position;
        _stage2_Yellow_InitialPosition = _stage2_Yellow_Container.transform.position;
    }

    void OnCollisionStay(Collision collision)
    {
        //このオブジェクトがプレイヤーに触れているとき.
        if (collision.gameObject.name == "3DPlayer")
        {
            //Aボタンを押したら
            if (Input.GetKeyDown("joystick button 2"))
            {
                //それぞれのオブジェクトを初期位置へ移動.
                _stage2_Blue_Container.transform.position = _stage2_Blue_InitialPosition;
                _stage2_Red_Container.transform.position = _stage2_Red_InitialPosition;
                _stage2_Green_Container.transform.position = _stage2_Green_InitialPosition;
                _stage2_Yellow_Container.transform.position = _stage2_Yellow_InitialPosition;
                
            }
        }
    }

    private void Move()
    {
        //this.gameObject.transform.position += ;
    }
}
