using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlaneManager : MonoBehaviour
{
    private enum moveNum
    {
        up,
        right,
        down,
        left,
        empty,
    }
    private GameObject _player;
    private GameObject _planeManager;
    private int _moveAngle;
    private float _planeAngle;
    public bool _isExit;
    public bool _isWall;

    private void Start()
    {
        _player = GameObject.Find("3DPlayer");
        _planeManager = GameObject.Find("PlaneManager");
        _planeAngle = this.transform.localEulerAngles.y;
    }
    private void FixedUpdate()
    {
        if (_planeManager.GetComponent<PlaneBool>().GetMoving())
        {
            if (_planeManager.GetComponent<PlaneBool>().GetAngle() == (int)moveNum.up)
            {
                _player.transform.position += new Vector3(-0.001f, 0.0f, 0.0f);
            }
            else if (_planeManager.GetComponent<PlaneBool>().GetAngle() == (int)moveNum.right)
            {
                _player.transform.position += new Vector3(0.0f, 0.0f, 0.001f);
            }
            else if (_planeManager.GetComponent<PlaneBool>().GetAngle() == (int)moveNum.down)
            {
                _player.transform.position += new Vector3(0.001f, 0.0f, 0.0f);
            }
            else if (_planeManager.GetComponent<PlaneBool>().GetAngle() == (int)moveNum.left)
            {
                _player.transform.position += new Vector3(0.0f, 0.0f, -0.001f);
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!_isWall)
        {
            _planeManager.GetComponent<PlaneBool>().SetMoving(true);
            if (_planeAngle == 0)
            {
                _planeManager.GetComponent<PlaneBool>().SetAngle((int)moveNum.up);
            }
            else if (_planeAngle == 90)
            {
                _planeManager.GetComponent<PlaneBool>().SetAngle((int)moveNum.right);
            }
            else if (_planeAngle == 180)
            {
                _planeManager.GetComponent<PlaneBool>().SetAngle((int)moveNum.down);
            }
            else if (_planeAngle == 270)
            {
                _planeManager.GetComponent<PlaneBool>().SetAngle((int)moveNum.left);
            }
        }
        else
        {
            _planeManager.GetComponent<PlaneBool>().SetMoving(false);
            _moveAngle = 4;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (_isExit)
        {
            _planeManager.GetComponent<PlaneBool>().SetMoving(false);
            _moveAngle = 4;
        }
    }
}


