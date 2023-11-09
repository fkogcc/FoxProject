using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickHand : MonoBehaviour
{
    private int _hitNo;
    private GameObject _directer;

    public int HitNo { get { return _hitNo; } }

    void Start()
    {
        _hitNo = 15;
        _directer = GameObject.Find("GameManager");
    }

    void OnTriggerEnter(Collider other)
    {
        _hitNo = int.Parse(other.name);

        _directer.GetComponent<SlideGimmickDirector>().ChangeNowSelectLight(_hitNo);
    }
}
