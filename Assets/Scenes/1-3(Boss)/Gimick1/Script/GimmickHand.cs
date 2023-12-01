using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class GimmickHand : MonoBehaviour
{
    // 手の動く速度
    private const float kSpeed = 0.125f;
    // 上下左右の上限
    private const float kRightLimit = 9.0f;
    private const float kLeftLimit = -8.0f;
    private const float kUpLimit = 12.5f;
    private const float kDownLimit = 2.0f;

    private int _hitNo;
    private GameObject _directer;
    // スティック情報
    private float _horizontal;
    private float _vertical;

    public int HitNo { get { return _hitNo; } }

    void Start()
    {
        _hitNo = 15;
        _directer = GameObject.Find("GameManager");
    }

    void OnTriggerEnter(Collider other)
    {
        _hitNo = int.Parse(other.name);

        _directer.GetComponent<SlideGimmickDirector>().ChangeNowSelectLight(_hitNo);
    }

    public void HandUpdate()
    {
        // 垂直方向.
        _horizontal = Input.GetAxis("Horizontal");
        // 水平方向.
        _vertical = Input.GetAxis("Vertical");

        // プレイヤーの移動処理.
        if (0.0f < _horizontal)
        {
            transform.position += Vector3.right * kSpeed;
            if (transform.position.x > kRightLimit)
            {
                transform.position =
                    new Vector3(kRightLimit, transform.position.y, transform.position.z);
            }
        }
        if (_horizontal < 0.0f)
        {
            transform.position += Vector3.left * kSpeed;
            if (transform.position.x < kLeftLimit)
            {
                transform.position = 
                    new Vector3(kLeftLimit, transform.position.y, transform.position.z);
            }
        }
        if (0.0f < _vertical)
        {
            transform.position += Vector3.up * kSpeed;
            if (transform.position.y > kUpLimit)
            {
                transform.position =
                    new Vector3(transform.position.x, kUpLimit, transform.position.z);
            }
        }
        if (_vertical < 0.0f)
        {
            transform.position += Vector3.down * kSpeed;
            if (transform.position.y < kDownLimit)
            {
                transform.position =
                    new Vector3(transform.position.x, kDownLimit, transform.position.z);
            }
        }
    }
}
