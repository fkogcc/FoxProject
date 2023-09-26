using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlane : MonoBehaviour
{
    private enum moveNum
    {
        up,
        down,
        left,
        right,
        empty,
    }
    private GameObject _player;
    private float _planeAngle;
    private moveNum _moveAngle;
    private bool _isMoving;
    

    void Start()
    {
        _player = GameObject.Find("3DPlayer");
        _planeAngle = this.transform.localEulerAngles.y;
        _isMoving = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
//        Debug.Log(_isMoving);
        if (_isMoving)
        {
            if (_moveAngle == moveNum.up)
            {
                _player.transform.position += new Vector3(-0.1f, 0.0f, 0.0f);
            }
            else if (_moveAngle == moveNum.down)
            {
                _player.transform.position += new Vector3(0.0f, 0.0f, 0.1f);
            }
            else if (_moveAngle == moveNum.left)
            {
                _player.transform.position += new Vector3(0.1f, 0.0f, 0.0f);
            }
            else if (_moveAngle == moveNum.right)
            {
                _player.transform.position += new Vector3(0.0f, 0.0f, -0.1f);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        PlaneManager._moveAngle = 4;
        Debug.Log("‚ ‚½‚Á‚½");

        if (_planeAngle == 0)
        {
            _moveAngle = moveNum.up;
        }
        else if (_planeAngle == 90)
        {
            _moveAngle = moveNum.down;
        }
        else if (_planeAngle == 180)
        {
            _moveAngle = moveNum.left;
        }
        else if (_planeAngle == 270)
        {
            _moveAngle = moveNum.right;
        }
        _isMoving = true;
    }
    private void OnTriggerExit(Collider other)
    {
        _isMoving = false;
    }
}
