﻿// ギミックが作動中時のカメラの挙動

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationGimmickCamera : MonoBehaviour
{
    // ギミックの作動中のカメラの座標.
    [SerializeField] private GameObject[] _CameraPosition;
    // ギミックの真偽を統括しているオブジェクト名.
    [SerializeField] private string _GimmickManagerName;

    //[SerializeField] private 

    // ギミックの真偽を統括しているオブジェクト.
    private GameObject _GimmickManger;

    // Start is called before the first frame update
    void Start()
    {
        //_GimmickManger = GameObject.Find(_GimmickManagerName).GetComponent<>()
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
