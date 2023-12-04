using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsBotton : MonoBehaviour
{
    public bool _isA;
    public bool _isB;
    public bool _isX;
    public bool _isY;

    private bool _isHit = false;

    void Start()
    {
        
    }

    void Update()
    {
        if(_isHit)
        {
            Debug.Log("描画");
        }
    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerStay(Collider coll)
    {
        // プレイヤーに触れたら
        if (coll.gameObject.tag == "Player")
        {
            _isHit = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // プレイヤーに触れたら
        if (other.gameObject.tag == "Player")
        {
            _isHit = false;
        }
    }

}
