using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingGimmick : MonoBehaviour
{
    private Rigidbody _rigidbody;
    // 落ちるスピード.
    [SerializeField] private Vector3 _FallingSpeed = new Vector3(0.0f,-1.0f,0.0f);
    // 落ちているかどうか
    private bool _isFalling = false;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(_isFalling)
        {
            _rigidbody.AddForce(_FallingSpeed);
        }

        if(transform.position.y <= -30.0f)
        {
            _isFalling = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _isFalling = true;
        }
    }
}
