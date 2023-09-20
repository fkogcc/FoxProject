using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlane : MonoBehaviour
{
    GameObject player;
    float _planeAngle;
    int _moveAngle;
    bool _isMoving;
    void Start()
    {
        player = GameObject.Find("3DPlayer");
        _planeAngle = this.transform.localEulerAngles.y;
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
                player.transform.position += new Vector3(-0.1f, 0.0f, 0.0f);
            }
            else if (_moveAngle == 1)
            {
                player.transform.position += new Vector3(0.0f, 0.0f, 0.1f);
            }
            else if (_moveAngle == 2)
            {
                player.transform.position += new Vector3(0.1f, 0.0f, 0.0f);
            }
            else if (_moveAngle == 3)
            {
                player.transform.position += new Vector3(0.0f, 0.0f, -0.1f);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("あたった");

        if (_planeAngle == 0)
        {
            _moveAngle = 0;
        }
        else if (_planeAngle == 90)
        {
            _moveAngle = 1;
        }
        else if (_planeAngle == 180)
        {
            _moveAngle = 2;
        }
        else if (_planeAngle == 270)
        {
            _moveAngle = 3;
        }
        MovePlane2._isMoving = false;//動き続ける処理を止める
        _isMoving = true;
    }
    private void OnTriggerExit(Collider other)
    {
        _isMoving = false;
    }
}
