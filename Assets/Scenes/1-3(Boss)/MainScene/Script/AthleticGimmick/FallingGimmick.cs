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

    private Vector3 _initialPosition;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(_isFalling)
        {
            //_rigidbody.AddForce(_FallingSpeed);

            transform.position += _FallingSpeed;
        }

        if(transform.position.y <= -6.0f)
        {
            PositionReset();
            _isFalling = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //Debug.Log("通る");
            _isFalling = true;
        }
    }

    // 一番下まで落ち切った時に初期位置にリセット.
    private void PositionReset()
    {
        transform.position = _initialPosition;
    }
}
