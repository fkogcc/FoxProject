using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Blue_Container : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "stage1_kontena_blue")
        {
            ContainerDirector._count++;
            Debug.Log("クリア1");
        }
    }
}
