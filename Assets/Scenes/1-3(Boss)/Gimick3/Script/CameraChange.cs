using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraChange : MonoBehaviour
{
    private Camera _subCamera;
    private Camera _playerCamera;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "3DPlayer")
        {
            // A�{�^����������W�����v.
            if (Input.GetKeyDown("joystick button 0"))
            {
               
            }
        }
    }
}
