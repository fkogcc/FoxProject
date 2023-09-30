using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickHand : MonoBehaviour
{
    private string _hitName;

    void Start()
    {
        _hitName = "15";
    }

    void OnTriggerEnter(Collider other)
    {
        _hitName = other.name;
    }

    public int GetEleNum()
    {
        return int.Parse(_hitName);
    }
}
