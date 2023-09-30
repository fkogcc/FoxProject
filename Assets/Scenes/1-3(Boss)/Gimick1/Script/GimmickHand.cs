using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickHand : MonoBehaviour
{
    private string _hitNo;

    public int HitNo { get { return int.Parse(_hitNo); } }

    void Start()
    {
        _hitNo = "15";
    }

    void OnTriggerEnter(Collider other)
    {
        _hitNo = other.name;
    }
}
