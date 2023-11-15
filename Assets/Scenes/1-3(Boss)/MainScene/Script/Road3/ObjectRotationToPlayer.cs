using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotationToPlayer : MonoBehaviour
{
    public GameObject _player;
    private bool _isHit = false;
   
    void Update()
    {
        if(_isHit)
        {
            //_player.transform.parent = gameObject.transform;
            _player.transform.SetParent(gameObject.transform);
            _isHit = false;

        }
        else
        {
            _player.transform.parent = null;
        }

        Debug.Log(_isHit);
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _isHit = true;  
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        _isHit = true;
    //    }
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        _isHit = false;
    //    }
    //}
}
