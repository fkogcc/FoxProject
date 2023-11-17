using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerDirector : MonoBehaviour
{
    //バリケードを取得.
    GameObject _Barricade;
    //クリア数カウント.
    public static int _count;
    //クリアに必要なカウント数.
    private int _Maxcount = 8;
    //Stage2に行くためのカウント.
    private int _Stage2_Count = 4;
    // 全てクリアしているかのフラグ.
    private bool _isAllClear;

    // Start is called before the first frame update
    void Start()
    {
        _count = 0;
        _Barricade = GameObject.Find("Barricade");
    }

    // Update is called once per frame
    void Update()
    {
        if (_count == _Stage2_Count)
        {
            Destroy(_Barricade);
        }

        if (_count == _Maxcount)
        {
            GetResult();
        }
    }

    public bool GetResult()
    {
        Debug.Log("クリア");
        return _isAllClear;
    }
}
