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
    //public GameObject _stage2_Red_Container;

    // Start is called before the first frame update
    void Start()
    {
        _stage2_Blue_InitialPosition = _stage2_Blue_Container.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
