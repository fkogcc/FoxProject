using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    // 手の移動速度.
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // HACK とりあえず手を動かす用の処理(後でもっといい方法に書き直したいな).
        if (Input.GetAxis("Vertical") > 0)
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            transform.position -= transform.up * speed * Time.deltaTime;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
    }
}
