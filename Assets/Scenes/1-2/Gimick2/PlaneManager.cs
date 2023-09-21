using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneManager: MonoBehaviour
{
    GameObject player;
    public static int _moveAngle;

    private void Start()
    {
        player = GameObject.Find("3DPlayer");
        _moveAngle = 4;
    }
    private void FixedUpdate()
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
