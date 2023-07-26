using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove3D : MonoBehaviour
{
    bool _isJumpNow;// ジャンプしているかどうか
    private Rigidbody _Rigid;// プレイヤーのリジットボディ
    float _jumpPower = 25.0f;// ジャンプ力
    private Vector3 _latestPos;// 前回のPosition
    float _topSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        _Rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //float hori = Input.GetAxis("Horizontal");
        //float vert = Input.GetAxis("Vertical");
        //float speedX = hori * 0.01f;// 速さ
        //float speedZ = vert * 0.01f;// 速さ
        ////float speedX = hori * 25.0f;// 速さ
        ////float speedZ = vert * 25.0f;// 速さ
        //Vector3 vec = new Vector3(speedX, 0, speedZ);

        //if (hori != 0 || vert != 0)
        //{
        //    //transform.position += new Vector3(hori / 10.0f, 0.0f, 0.0f);
        //    // スティックの方向け度合いで速度調整
        //    //rigid.transform.position += new Vector3(speed, 0.0f, 0.0f);
        //    //rigid.transform.position += new Vector3(0.1f, 0.0f, 0.0f);

        //    Vector3 diff = new Vector3(transform.position.x - _latestPos.x, 0.0f, transform.position.z - _latestPos.z);// 前回からどこに進んだかをベクトルで取得
        //    _latestPos = transform.position;

        //    // スティックの方向け度合いで速度調整
        //    _Rigid.transform.position += new Vector3(speedX, 0.0f, speedZ);

        //    if(diff.magnitude > 0.01f)
        //    {
        //        _Rigid.transform.rotation = Quaternion.LookRotation(diff);// 向きの変更
        //    }



        //    // 速度が10以下ならば力を加える
        //    if (_Rigid.velocity.x < _topSpeed && _Rigid.velocity.x > -_topSpeed &&
        //        _Rigid.velocity.z < _topSpeed && _Rigid.velocity.z > -_topSpeed)
        //    {
        //        //rigid.AddForce(vec);

        //        //rigid.velocity = new Vector3(speed, 0.0f, 0.0f);
        //    }

        //}

        if (Input.GetKeyDown("joystick button 0"))
        {
            //transform.position += new Vector3(0.0f, 1.0f, 0.0f);
            Jump();
        }

        // 移動
        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * 1);// 正面
        }

        // 向き
        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            transform.rotation = Quaternion.LookRotation(
                transform.position +
                (Vector3.right * Input.GetAxisRaw("Horizontal")) +
                (Vector3.forward * Input.GetAxisRaw("Vertical")) -
                transform.position);
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
        if (_isJumpNow)
        {
            _isJumpNow = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // 地面についたら
        if (!_isJumpNow)
        {
            _isJumpNow = true;
        }
    }

    // ジャンプ処理
    void Jump()
    {
        if (_isJumpNow)
        {
            return;
        }
        _Rigid.AddForce(transform.up * _jumpPower, ForceMode.Impulse);
        _isJumpNow = true;
    }
}
