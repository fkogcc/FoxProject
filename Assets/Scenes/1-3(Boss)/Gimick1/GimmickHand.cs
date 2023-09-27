using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickHand : MonoBehaviour
{
    private string HitName;

    void Start()
    {
        HitName = "15";
    }

    void OnTriggerEnter(Collider other)
    {
        HitName = other.name;
    }

    public int GetEleNum()
    {
        return int.Parse(HitName);
    }
}
