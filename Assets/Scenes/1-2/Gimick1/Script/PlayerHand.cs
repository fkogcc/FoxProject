using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    // 手の移動速度.
    private float _speed;
    // ボタンの名前を入れる用の変数.
    public string _buttonName;
    // ボタンの状態を入れるフラグ.
    public bool _isButtonState;
    // プレイヤーの手が判定内にいるかどうかを返すフラグ.
    private bool _isCollision;

    // Start is called before the first frame update
    void Start()
    {
        // 初期化処理.
        _speed = 2.5f;
        _isButtonState = false;
        _isCollision = false;
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーの手が判定内にいて、ボタンを押されたら.
        if (_isCollision && Input.GetKeyDown("joystick button 1"))
        {
            // ボタンが押されたフラグを返す.
            _isButtonState = true;
        }
        // 条件に当てはまらなかったら.
        else
        {
            // ボタンのフラグをfalseで返す.
            _isButtonState = false ;
        }
    }
    void FixedUpdate()
    {
        // HACK とりあえず手を動かす用の処理(後でもっといい方法に書き直したいな).
        if (Input.GetAxis("Vertical") > 0)
        {
            // 上.
            transform.position += transform.up * _speed * Time.deltaTime;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            // 下.
            transform.position -= transform.up * _speed * Time.deltaTime;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            // 右.
            transform.position += transform.right * _speed * Time.deltaTime;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            // 左.
            transform.position -= transform.right * _speed * Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // プレイヤーがコライダーに入ったとき.
        if (other.tag == "Button")
        {
            // 判定内にいるというフラグを返す.
            _isCollision = true;
            // 今触れているボタンを取得する
            _buttonName = other.gameObject.name;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // プレイヤーがコライダーから出たとき.
        if (other.tag == "Button")
        {
            // 判定外にいるというフラグを返す.
            _isCollision = false;
        }
    }
}
