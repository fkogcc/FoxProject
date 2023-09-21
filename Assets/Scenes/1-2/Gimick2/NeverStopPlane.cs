using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeverStopPlane : MonoBehaviour
{
    GameObject player;
    float _planeAngle;
    void Start()
    {
        player = GameObject.Find("3DPlayer");
        _planeAngle = this.transform.localEulerAngles.y;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (_planeAngle == 0)
        {
            PlaneManager._moveAngle = 0;
        }
        else if (_planeAngle == 90)
        {
            PlaneManager._moveAngle = 1;
        }
        else if (_planeAngle == 180)
        {
            PlaneManager._moveAngle = 2;
        }
        else if (_planeAngle == 270)
        {
            PlaneManager._moveAngle = 3;
        }
    }
}
