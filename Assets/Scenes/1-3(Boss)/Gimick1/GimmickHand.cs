using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickHand : MonoBehaviour
{
    const float kSpeed = 0.125f;

    public static string HitName;

    Vector3 _vec;

    void Start()
    {
        HitName = "";

        _vec = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        // ˆÚ“®‚ÉŠÖ‚µ‚Ä
        _vec = Vector3.zero;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            _vec.x = kSpeed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _vec.x = -kSpeed;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _vec.y = kSpeed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            _vec.y = -kSpeed;
        }

        this.transform.position += _vec;
    }

    void OnTriggerEnter(Collider other)
    {
        HitName = other.name;
    }
}
