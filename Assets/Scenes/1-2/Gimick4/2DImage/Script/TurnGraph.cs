using System.Collections;
using System.Collections.Generic;
using UnityEngine;


GameObject bottonObj;
Botton botton;
public class TurnGraph : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        bottonObj = GameObject.Find("Botton"); //Unityちゃんをオブジェクトの名前から取得して変数に格納する
        botton = bottonObj.GetComponent<Botton>(); //unitychanの中にあるUnityChanScriptを取得して変数に格納する
    }

    // Update is called once per frame
    void Update()
    {

    }
}
