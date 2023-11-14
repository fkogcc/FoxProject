using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerDirector : MonoBehaviour
{
    //クリア数カウント.
    public static int _count;
    //クリアに必要なカウント数
    private int _Maxcount = 8;
    // 全てクリアしているかのフラグ.
    private bool _isAllClear;

    // Start is called before the first frame update
    void Start()
    {
        _count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(_count == _Maxcount)
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
