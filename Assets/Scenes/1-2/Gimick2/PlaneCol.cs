using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCol : MonoBehaviour
{
    private float _planeAngle;
    public bool _isExit;
    public bool _isWall;
    // Start is called before the first frame update
    void Start()
    {
        _planeAngle = this.transform.localEulerAngles.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_isWall)
        {
            PlaneManager._isMoving = true;
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
        else
        {
            PlaneManager._moveAngle = 4;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (_isExit)
        {
            PlaneManager._isMoving = false;
        }
    }
}
