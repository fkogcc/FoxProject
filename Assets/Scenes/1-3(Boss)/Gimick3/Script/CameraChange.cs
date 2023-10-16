using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CameraChange : MonoBehaviour
{
    private GameObject _subCamera;
    private GameObject _playerCamera;


    void Start()
    {
        _subCamera = GameObject.Find("3DPlayerCamera");
        _playerCamera = GameObject.Find("SubCamera");
        //_subCamera.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "3DPlayer")
        {
            Debug.Log("OK");
            // Aボタン押したらジャンプ.
            if (Input.GetKeyDown("joystick button 0"))
            {
               _playerCamera.SetActive(false);
               _subCamera.SetActive(true);
            }
        }
    }
}
