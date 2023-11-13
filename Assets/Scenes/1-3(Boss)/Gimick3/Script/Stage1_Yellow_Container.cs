using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Yellow_Container : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "stage1_kontena_yellow")
        {
            ContainerDirector._count++;
            Debug.Log("クリア4");
        }
    }
}
