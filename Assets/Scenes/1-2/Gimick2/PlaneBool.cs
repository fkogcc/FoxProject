using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBool : MonoBehaviour 
{
    private bool _isMoving = false;
    private int _tempMoveAngle = 4;

    public bool GetMoving() { return _isMoving; }
    public void SetMoving(bool Moving) { _isMoving = Moving; }
    public int GetAngle() { return _tempMoveAngle; }
    public void SetAngle(int angle) { _tempMoveAngle = angle; }
}
