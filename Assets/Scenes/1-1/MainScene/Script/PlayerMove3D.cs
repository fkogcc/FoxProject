using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove3D : MonoBehaviour
{
    bool jumpNow;// ジャンプしているかどうか
    private Rigidbody rigid;// プレイヤーのリジットボディ
    float jumpPower = 25.0f;// ジャンプ力
    private Vector3 latestPos;// 前回のPosition
    float topSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float hori = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        float speedX = hori * 25.0f;// 速さ
        float speedZ = vert * 25.0f;// 速さ
        Vector3 vec = new Vector3(speedX, 0, speedZ);

        if (hori != 0 || vert != 0)
        {
            //transform.position += new Vector3(hori / 10.0f, 0.0f, 0.0f);
            // スティックの方向け度合いで速度調整
            //rigid.transform.position += new Vector3(speed, 0.0f, 0.0f);
            //rigid.transform.position += new Vector3(0.1f, 0.0f, 0.0f);

            Vector3 diff = new Vector3(transform.position.x - latestPos.x, 0.0f, transform.position.z - latestPos.z);// 前回からどこに進んだかをベクトルで取得
            latestPos = transform.position;

            // スティックの方向け度合いで速度調整
            //rigid.transform.position += new Vector3(speedX, 0.0f, speedZ);

            if(diff.magnitude > 0.01f)
            {
                rigid.transform.rotation = Quaternion.LookRotation(diff);// 向きの変更
            }



            // 速度が10以下ならば力を加える
            if (rigid.velocity.x < topSpeed && rigid.velocity.x > -topSpeed &&
                rigid.velocity.z < topSpeed && rigid.velocity.z > -topSpeed)
            {
                rigid.AddForce(vec);

                //rigid.velocity = new Vector3(speed, 0.0f, 0.0f);
            }

        }

        if (Input.GetKeyDown("joystick button 0"))
        {
            //transform.position += new Vector3(0.0f, 1.0f, 0.0f);
            Jump();
        }

    }

    private void FixedUpdate()
    {
        // 落ちたら初期位置に戻す
        if (transform.position.y < -10)
        {
            transform.position = new Vector3(0.0f, 1.0f, 0.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 地面から離れたら
        if (jumpNow)
        {
            jumpNow = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // 地面についたら
        if (!jumpNow)
        {
            jumpNow = true;
        }
    }

    // ジャンプ処理
    void Jump()
    {
        if (jumpNow)
        {
            return;
        }
        rigid.AddForce(transform.up * jumpPower, ForceMode.Impulse);
        jumpNow = true;
    }
}
