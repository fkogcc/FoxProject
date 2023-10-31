using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxClear8 : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "pCube59")
        {
            Debug.Log("クリア4");
        }
    }
}
