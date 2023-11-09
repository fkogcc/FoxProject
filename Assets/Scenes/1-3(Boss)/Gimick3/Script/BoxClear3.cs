using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxClear3 : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Box3")
        {
            Debug.Log("クリア3");
        }
    }
}
