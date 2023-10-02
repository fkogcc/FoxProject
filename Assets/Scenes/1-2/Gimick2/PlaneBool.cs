using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBool : MonoBehaviour 
{
    private bool _isMoving;

    private int _MoveAngle;

    private int _lastCol;
    public bool GetMoving() { return _isMoving; }
    public void SetMoving(bool Moving) { _isMoving = Moving; }
    public int GetAngle() { return _MoveAngle; }
    public void SetAngle(int angle) { _MoveAngle = angle; }

    public int GetLastCol() { return _lastCol; }
    public void SetLastCol(int lastCol) { _lastCol += lastCol; }
    public void ResetLastCol() { _lastCol = 0; }

}
