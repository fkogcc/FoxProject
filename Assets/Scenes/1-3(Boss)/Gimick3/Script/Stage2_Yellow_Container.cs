using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2_Yellow_Container : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "stage2_kontena_yellow")
        {
            ContainerDirector._count++;
            Debug.Log("クリア8");
        }
    }
}
