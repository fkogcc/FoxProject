using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickHand : MonoBehaviour
{
    private string _hitNo;
    private GameObject _directer;

    public int HitNo { get { return int.Parse(_hitNo); } }

    void Start()
    {
        _hitNo = "15";
        _directer = GameObject.Find("GameManager");
    }

    void OnTriggerEnter(Collider other)
    {
        _hitNo = other.name;

        _directer.GetComponent<SlideGimmickDirector>().ChangeNowSelectLight(HitNo);
    }
}
