using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteasiba : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {        
            Debug.Log("‚ ‘½");
            Destroy(this.gameObject);   
    }
}
