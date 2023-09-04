using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWindmill : MonoBehaviour
{
    [SerializeField] private float _rotateMaxSpeed = 5.0f;
    private float _rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _rotateSpeed = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _rotateSpeed += 0.1f;

        if (_rotateSpeed >= _rotateMaxSpeed)
        {
            _rotateSpeed = _rotateMaxSpeed;
        }

        transform.Rotate(_rotateSpeed, 0.0f, 0.0f);

        Debug.Log(_rotateSpeed);
    }
}
