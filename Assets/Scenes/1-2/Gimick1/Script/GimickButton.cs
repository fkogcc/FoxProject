using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimickButton : MonoBehaviour
{
    // 当たり判定内にいるかどうか保存するフラグ.
    public bool _isCollision;
    // ボタンの押した状態を保存するフラグ.
    public bool _isButtonState;
    // ボタンの状態を渡すためにオブジェクトを取得.
    private GameObject _gameObject;
    // scriptを取得.
    PlayerHand _player;
    // プレイヤーが触れいているボタンの名前をいれるための変数.
    private string _name;

    // Start is called before the first frame update
    void Start()
    {
        // フラグの初期化.
        _isCollision = false;

        // オブジェクトを取得.
        _gameObject = GameObject.Find("FoxHand");
        // オブジェクトの中にあるscriptを取得.
        _player = _gameObject.GetComponent<PlayerHand>();
    }

    // Update is called once per frame
    void Update()
    {
        // 自身の名前とプレイヤーが触れているボタンの名前が一緒だったら.
        if (_name == this.gameObject.name)
        {
            // みどりに色を変える.
            GetComponent<Renderer>().material.color = Color.green;
        }
        // プレイヤーがボタンを押した状態であったら.
        if (_player._isButtonState)
        {
            // 今触れているボタンの名前を取得する.
            _name = _player._buttonName;
        }
        // 押した状態でなければ.
        else
        {
            // 名前には何も入れない
            _name = "";
        }

    }
    void FixedUpdate()
    {
        
    }
}
