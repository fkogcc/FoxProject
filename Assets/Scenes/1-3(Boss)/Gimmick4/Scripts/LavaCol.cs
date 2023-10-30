using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LavaCol : MonoBehaviour
{
    Vector3 kjumpForce = new Vector3(0, 30.0f, 0);
    Rigidbody _rb;

    private void Start()
    {
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("当たった");
            _rb = other.GetComponent<Rigidbody>();
            _rb.velocity = kjumpForce;
 //           _rb.AddForce(kjumpForce,ForceMode.Impulse);
        }
    }
}
