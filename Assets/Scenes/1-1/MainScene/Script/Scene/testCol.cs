using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class testCol : MonoBehaviour
{
    // シーン遷移の真偽
    bool _isGateGimmick1;
    bool _isGateGimmick2;
    // Start is called before the first frame update
    void Start()
    {
        // 初期化
        _isGateGimmick1 = false;
        _isGateGimmick2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Yボタンを押したらシーン遷移
        if (Input.GetKeyDown("joystick button 3"))
        {
            if (_isGateGimmick1)
            {
                SceneManager.LoadScene("Gimmick1Scene");
            }
            if (_isGateGimmick2)
            {
                SceneManager.LoadScene("Gimmick2Scene");
            }
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        // 扉の当たり判定に入ったらture
        if(other.tag == "Gimmick1")
        {
            _isGateGimmick1 = true;
        }
        else if(other.tag == "Gimmick2")
        {
            _isGateGimmick2 = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 扉の当たり判定を出たらfalse
        if(other.tag =="Gimmick1")
        {
            _isGateGimmick1 = false;
        }
        else if( other.tag =="Gimmick2")
        {
            _isGateGimmick2 = false;
        }
    }
}
