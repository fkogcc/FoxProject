using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxClear2 : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Box2")
        {
            Debug.Log("クリア2");
        }
    }
}
