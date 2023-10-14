using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickHand : MonoBehaviour
{
    private string _hitNo;
    private bool _isHit;

    public int HitNo { get { return int.Parse(_hitNo); } }

    void Start()
    {
        _hitNo = "15";
        _isHit = false;
    }

    void OnTriggerEnter(Collider other)
    {
        _hitNo = other.name;
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    Debug.Log("当たっている");
    //    if (!_isHit)
    //    {
    //        Debug.Log("番号変更");

    //        _isHit = true;

    //        _hitNo = other.name;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    _isHit = false;
    //}
}
