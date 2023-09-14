using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.Rotate(0, 10, 0);
        }
        else if(Input.GetMouseButton(1))
        {
            transform.Rotate(0, 10, 0);
        }
    }
}
