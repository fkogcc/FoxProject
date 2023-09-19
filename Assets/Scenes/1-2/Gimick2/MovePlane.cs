using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlane : MonoBehaviour
{
    GameObject player;
    Quaternion _planeAngle;
    int _moveAngle;
    bool _isMoving;
    void Start()
    {
        player = GameObject.Find("3DPlayer");
        _planeAngle = this.transform.rotation;
        _isMoving = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
//        Debug.Log(_isMoving);
        if (_isMoving)
        {
            if (_moveAngle == 0)
            {
                player.transform.position += new Vector3(-1f, 0.0f, 0.0f);
            }
            else if (_moveAngle == 1)
            {
                player.transform.position += new Vector3(0.0f, 0.0f, 1f);
            }
            else if (_moveAngle == 2)
            {
                player.transform.position += new Vector3(1f, 0.0f, 0.0f);
            }
            else if (_moveAngle == 3)
            {
                player.transform.position += new Vector3(0.0f, 0.0f, -1f);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("‚ ‚½‚Á‚½");

        if (_planeAngle.y > 90)
        {
            _moveAngle = 0;
        }
        else if (_planeAngle.y > 180)
        {
            _moveAngle = 1;
        }
        else if (_planeAngle.y > 270)
        {
            _moveAngle = 2;
        }
        else if (_planeAngle.y > 360)
        {
            _moveAngle = 3;
        }

        _isMoving = true;
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("ŠO‚ê‚½");
        _isMoving = false;
    }
}
