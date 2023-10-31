using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxClear7 : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "pCube57")
        {
            Debug.Log("クリア4");
        }
    }
}
