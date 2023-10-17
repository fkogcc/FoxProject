// ゲートの当たり判定.
// TODO:ファイル名がデバッグ用なので後で変える

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCol : MonoBehaviour
{
    // インスタンス.
    public static testCol _instance;
    // シーン遷移の真偽.
    private bool _isGateGimmick1;
    private bool _isGateGimmick2;

    // ゴールについたかどうか
    private bool _isGoal;

    private void Awake()
    {
        // シングルトン.
        if (_instance == null)
        {
            // 自身をインスタンスとする.
            _instance = this;
        }
        else
        {
            // インスタンスが複数存在しないように、既に存在していたら自身を消去する.
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // 初期化.
        _isGateGimmick1 = false;
        _isGateGimmick2 = false;
        _isGoal = false;
    }

    // Update is called once per frame
    void Update()
    {
    }


    private void OnTriggerEnter(Collider other)
    {
        // 扉の当たり判定に入ったらture.
        if (other.tag == "Gimmick1")
        {
            _isGateGimmick1 = true;
        }
        else if(other.tag == "Gimmick2")
        {
            _isGateGimmick2 = true;
        }
        else if(other.tag == "Goal")
        {
            _isGoal = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 扉の当たり判定を出たらfalse.
        if (other.tag =="Gimmick1")
        {
            _isGateGimmick1 = false;
        }
        else if( other.tag =="Gimmick2")
        {
            _isGateGimmick2 = false;
        }
        else if (other.tag == "Goal")
        {
            _isGoal = false;
        }
    }

    public bool GetIsGateGimmick1(){ return _isGateGimmick1; }

    public bool GetIsGateGimmick2(){ return _isGateGimmick2; }

    public bool GetIsGoal() { return _isGoal; }
}
