using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxClear5 : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "pCube56")
        {
            Debug.Log("クリア4");
        }
    }
}
