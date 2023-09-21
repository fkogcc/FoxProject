using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxIn : MonoBehaviour
{
    // ディレクター
    BoxDirector _director;
    // ギミックの色
    public string Color;

    void Start()
    {
        _director = GameObject.Find("GimmickDirector").GetComponent<BoxDirector>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("ギミック内:color, " + Color);
        _director.SetGimmickIn(Color, this.transform.position);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("ギミック外");
        _director.IsSetFlag();
    }
}
