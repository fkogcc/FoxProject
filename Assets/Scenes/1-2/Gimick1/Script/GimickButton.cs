using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimickButton : MonoBehaviour
{
    // ボタンの状態を渡すためにオブジェクトを取得.
    private GameObject _playerObject;
    // プレイヤーが触れいているボタンの名前をいれるための変数.
    private string _name;

    // Start is called before the first frame update
    void Start()
    {
        // オブジェクトを取得.
        _playerObject = GameObject.Find("FoxHand");
    }

    // Update is called once per frame
    void Update()
    {
        // 自身の名前とプレイヤーが触れているボタンの名前が一緒だったら.
        if (_name == this.gameObject.name)
        {
            // みどりに色を変える.
            this.GetComponent<Renderer>().material.color = Color.green;
        }

        // プレイヤーがボタンを押した状態であったら.
        if (_playerObject.GetComponent<PlayerHand>().IsGetButtonState())
        {
            // 今触れているボタンの名前を取得する.
            _name = _playerObject.GetComponent<PlayerHand>().IsGetButtonName();
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
  
    public Color IsCheckColor()
    {
        Color color = this.GetComponent<Renderer>().material.color;
        return color;
    }

    public void ChengeColor(bool ischange)
    {
        if(ischange)
        {
            // しろ色を変える.
            this.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
