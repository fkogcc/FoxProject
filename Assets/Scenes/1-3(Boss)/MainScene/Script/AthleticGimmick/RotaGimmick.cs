using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaGimmick : MonoBehaviour
{
    // 回転スピード.
    [SerializeField] private Vector3 _rotateSpeed = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Rotate(_rotateSpeed);
    }
}
