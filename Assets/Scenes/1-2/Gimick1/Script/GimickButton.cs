using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimickButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // ボタンがコライダーに入ったとき.
            Debug.Log("触れている");
            //_isPlayerCollider = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            // ボタンがコライダーから出たとき.
            Debug.Log("はなした");
            //_isPlayerCollider = false;
        }
    }
}
