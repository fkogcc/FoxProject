using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotationToPlayer : MonoBehaviour
{
    public GameObject _player;
    private bool _isHit = false;

    private void FixedUpdate()
    {
        if (_isHit)
        {
            _player.transform.SetParent(gameObject.transform);
            _isHit = false;
        }

        if(Input.anyKey)
        {
            _player.transform.parent = null;
        }
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _isHit = true;
        }
    }
}
