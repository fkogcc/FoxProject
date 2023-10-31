using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxClear6 : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "pCube58")
        {
            Debug.Log("クリア4");
        }
    }
}
