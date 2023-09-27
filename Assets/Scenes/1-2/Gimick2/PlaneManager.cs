using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlaneManager : MonoBehaviour
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
    public static int _moveAngle;
    public static bool _isMoving;

    private void Start()
    {
        _player = GameObject.Find("3DPlayer");
        _moveAngle = 4;
    }
    private void FixedUpdate()
    {
        if (_isMoving)
        {
            if (_moveAngle == 0)
            {
                _player.transform.position += new Vector3(-0.1f, 0.0f, 0.0f);
            }
            else if (_moveAngle == 1)
            {
                _player.transform.position += new Vector3(0.0f, 0.0f, 0.1f);
            }
            else if (_moveAngle == 2)
            {
                _player.transform.position += new Vector3(0.1f, 0.0f, 0.0f);
            }
            else if (_moveAngle == 3)
            {
                _player.transform.position += new Vector3(0.0f, 0.0f, -0.1f);
            }
        }
    }
}

