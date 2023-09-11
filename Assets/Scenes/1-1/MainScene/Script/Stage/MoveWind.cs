using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWind : MonoBehaviour
{
    [SerializeField]
    private float _windX = 0f;
    [SerializeField]
    private float _windY = 0f;
    [SerializeField]
    private float _windZ = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// トリガーの範囲に入っている間風の影響を受ける
    /// </summary>
    /// <param name="other">当たっている相手</param>
    private void OnTriggerStay(Collider other)
    {
        // 当たったオブジェクトのRigidBody取得
        Rigidbody rigidbody = other.GetComponent<Rigidbody>();

        // rigidbodyがnullではない時
        if(rigidbody != null)
        {
            // 相手のrigidbodyに力を加える
            rigidbody.AddForce(_windX, _windY, _windZ, ForceMode.Force);
        }

        Debug.Log(other.name);
    }
}
