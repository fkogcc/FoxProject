using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var velocity= new Vector3(horizontal, 0, vertical).normalized;

        // 移動方向を向く.
        if (velocity.magnitude > 0.5f)
        {
            transform.rotation = Quaternion.LookRotation(velocity, Vector3.up);
        }
    }
}
