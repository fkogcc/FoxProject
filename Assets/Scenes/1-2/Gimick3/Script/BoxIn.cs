using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxIn : MonoBehaviour
{
    // ディレクター.
    private BoxDirector _director;
    // ギミックの色.
    public string Color;

    // 初期化処理.
    void Start()
    {
        // GimmickDirectorの情報を取得する.
        _director = GameObject.Find("GimmickDirector").GetComponent<BoxDirector>();
    }

    void OnTriggerEnter(Collider other)
    {
        _director.SetGimmickIn(Color, this.transform.position);
        _director.SetObj(this.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        _director.IsSetFlag(false);
    }
}
