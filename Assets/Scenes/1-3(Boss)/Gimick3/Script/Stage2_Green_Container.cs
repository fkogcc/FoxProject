using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2_Green_Container : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "stage2_kontena_green")
        {
            ContainerDirector._count++;
            Debug.Log("クリア6");
        }
    }
}
