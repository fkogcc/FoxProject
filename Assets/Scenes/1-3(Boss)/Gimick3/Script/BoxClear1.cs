using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxClear1 : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Box1")
        {
            Debug.Log("クリア1");
        }
    }
}
