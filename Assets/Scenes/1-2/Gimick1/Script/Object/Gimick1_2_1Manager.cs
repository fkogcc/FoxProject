using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimick1_2_1Manager : MonoBehaviour
{
    private GameObject _handObject;

    private GameObject _buttonObject;
    // Start is called before the first frame update
    void Start()
    {
        _handObject = GameObject.Find("FoxHand");
        

    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーの手がボタンを押したかどうか
        _handObject.GetComponent<PlayerHand>().ButtonPush();
        // モニターを変えるかどうかをチェックしている
        this.GetComponent<MonitorCamera>().MonitorChenge();
        // ボタンの状態
        this.GetComponent<ButtonState>().ButtonAcquisition();
    }
    void FixedUpdate()
    {
        // プレイヤーの手の移動処理
        _handObject.GetComponent<PlayerHand>().MovePlayerHand();
    }
}
