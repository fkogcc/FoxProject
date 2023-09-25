using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickHand : MonoBehaviour
{
    const float kSpeed = 0.125f;

    public static string HitName;

    Vector3 _vec;

    SlideGimmickDirector _gimmickDirector;

    // 
    bool _isHitKey;

    void Start()
    {
        HitName = "";

        _vec = new Vector3();

        _gimmickDirector = GameObject.Find("GimmickDirector").GetComponent<SlideGimmickDirector>();

        _isHitKey = false;
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

        if (Input.GetKey(KeyCode.F) && !_isHitKey)
        {
            _gimmickDirector.EleCheck(int.Parse(HitName));

            _isHitKey = true;
        }
        else if (!Input.GetKey(KeyCode.F))
        {
            _isHitKey = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        HitName = other.name;

        Debug.Log("[SlideGmmick] nowNum:" + HitName);
    }
}
