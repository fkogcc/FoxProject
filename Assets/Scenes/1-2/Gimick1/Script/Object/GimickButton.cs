using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimickButton : MonoBehaviour
{
    // ボタンの状態を渡すためにオブジェクトを取得.
    private GameObject _playerObject;
    private GameObject _gameManager;
    // プレイヤーが触れいているボタンの名前をいれるための変数.
    private string _name;
    // マテリアルの配列の番号
    private int _materialNum;
    // Start is called before the first frame update
    void Start()
    {
        // オブジェクトを取得.
        _gameManager = GameObject.Find("GameManager");
        _playerObject = null;
        _materialNum = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameManager.GetComponent<Gimick1_2_1Manager>().SetHandObject() != null)
        {
            _playerObject = _gameManager.GetComponent<Gimick1_2_1Manager>().SetHandObject();
            ButtonChengeColor();
        }
    }
    public void ButtonChengeColor()
    {
        // 自身の名前とプレイヤーが触れているボタンの名前が一緒だったら.
        if (_name == this.gameObject.name)
        {
            // みどりに色を変える.
            this.GetComponent<Renderer>().materials[_materialNum].color = Color.green;
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

    public Color IsCheckColor()
    {
        Color color = this.GetComponent<Renderer>().materials[_materialNum].color;
        return color;
    }

    public void ChengeColor(bool ischange)
    {
        if(ischange)
        {
            // しろ色を変える.
            GetComponent<Renderer>().materials[_materialNum].color = Color.white;
        }
    }
}
