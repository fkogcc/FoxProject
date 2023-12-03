using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset_Button : MonoBehaviour
{
    //それぞれのオブジェクト.
    //public GameObject _stage1_Blue_Container;
    //public GameObject _stage1_Red_Container;
    //public GameObject _stage1_Green_Container;
    //public GameObject _stage1_Yellow_Container;
    //public GameObject _stage2_Blue_Container;
    //public GameObject _stage2_Red_Container;
    //public GameObject _stage2_Green_Container;
    //public GameObject _stage2_Yellow_Container;
    [SerializeField] private GameObject[] _stageContainer;
    //それぞれのオブジェクトの位置.
    //public Vector3 _blue_InitialPosition;
    //public Vector3 _red_InitialPosition;
    //public Vector3 _green_InitialPosition;
    //public Vector3 _yellow_InitialPosition;
    [SerializeField] private Vector3[] _containeInitialPositionr;
    private int _count = 0;



    void Start()
    {
        //それぞれのオブジェクトの初期位置を保存.
        //_blue_InitialPosition = _stage2_Blue_Container.transform.position;
        //_red_InitialPosition = _stage2_Red_Container.transform.position;
        //_green_InitialPosition = _stage2_Green_Container.transform.position;
        //_yellow_InitialPosition = _stage2_Yellow_Container.transform.position;

        // 初期位置を取得する.
        for(int i = 0;i < _stageContainer.Length;i++) 
        {
            _containeInitialPositionr[i] = _stageContainer[i].transform.position;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        //このオブジェクトがプレイヤーに触れているとき.
        if (collision.gameObject.name == "3DPlayer")
        {
            //Aボタンを押したら
            if (Input.GetKeyDown("joystick button 2"))
            {
                ////それぞれのオブジェクトを初期位置へ移動.
                //_stage2_Blue_Container.transform.position = _blue_InitialPosition;
                //_stage2_Red_Container.transform.position = _red_InitialPosition;
                //_stage2_Green_Container.transform.position = _green_InitialPosition;
                //_stage2_Yellow_Container.transform.position = _yellow_InitialPosition;
                
            }
        }
    }
    public void ResetPush(bool isClear)
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown("joystick button 1"))
        {
            if (isClear)
            {
                _count = 4;
            }
            else
            {
                _count = 0;
            }
            for (int i = _count; i < _stageContainer.Length; i++)
            {
                _stageContainer[i].transform.position = _containeInitialPositionr[i];

            }
        }
    }

    private void Move()
    {
        //this.gameObject.transform.position += ;
    }
}
