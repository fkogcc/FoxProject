using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxClear4 : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Box4")
        {
            Debug.Log("クリア4");
        }
    }
}
