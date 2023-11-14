using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2_Red_Container : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "stage2_kontena_red")
        {
            ContainerDirector._count++;
            Debug.Log("クリア7");
        }
    }
}
