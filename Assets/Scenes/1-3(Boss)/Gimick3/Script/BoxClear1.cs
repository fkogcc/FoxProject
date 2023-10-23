using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxClear1 : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "FirstBox")
        {
            Debug.Log("クリア1");
        }
    }
}
