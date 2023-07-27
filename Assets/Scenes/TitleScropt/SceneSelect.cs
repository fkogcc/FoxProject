using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSelect : MonoBehaviour
{
    GameObject _button;
    // Start is called before the first frame update
    void Start()
    {
        _button = GameObject.Find("ButtonSystem");
    }

    // Update is called once per frame
    void Update()
    {
        if(_button.GetComponent<TitleButton>().GetLeftTrgger())
        {
            Debug.Log("‚±‚±‚±‚±‚‹");
        }
        _button.GetComponent<TitleButton>().GetRightTrgger();
        _button.GetComponent<TitleButton>().GetUpTrgger();
        _button.GetComponent<TitleButton>().GetDownTrgger();
    }
}
