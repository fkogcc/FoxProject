using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Red_Container : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "stage1_kontena_red")
        {
            ContainerDirector._count++;
            Debug.Log("クリア3");
        }
    }
}
