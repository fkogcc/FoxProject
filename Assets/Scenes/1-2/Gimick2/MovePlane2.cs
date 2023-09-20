using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlane2 : MonoBehaviour
{
    GameObject player;
    float _planeAngle;
    int _moveAngle = 5;
    public static bool _isMoving;//別のスクリプトから干渉できるようにパブリックにしておく
    void Start()
    {
        player = GameObject.Find("3DPlayer");
        _planeAngle = this.transform.localEulerAngles.y;
        _isMoving = false;
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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(transform.localEulerAngles.y);
        if (_isMoving)
        {
            //Debug.Log(_moveAngle);
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
        //Debug.Log("あたった");
        //Debug.Log(_planeAngle);

        //if (other.name == "3DPlayer")
        //{
        //    Debug.Log("あ");
        //    _moveAngle = 0;
        //}

        _isMoving = true;
    }
}
