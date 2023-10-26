using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LavaCol : MonoBehaviour
{
    Vector3 kjumpForce = new Vector3(0,1500.0f,0);
    Rigidbody _rb;
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _rb = other.GetComponent<Rigidbody>();
            _rb.AddForce(kjumpForce,ForceMode.Impulse);
        }
    }
}
