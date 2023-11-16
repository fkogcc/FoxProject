using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPlay : MonoBehaviour
{
    public GameObject _tapEffect;
    private GameObject _handObject;
    private string _panelName;
    private void Start()
    {
        _handObject = null;
    }
    public void EffectInit()
    {
        GetComponent<EffectLine>().LineInit();
    }

    public void GetPanelName(string name)
    {
        _panelName = name;
    }
    public void GetPlayerObject(GameObject handobj)
    {
        // オブジェクトを取得.
        _handObject = handobj;
    }

    public void CheckTap(bool buttonFlag)
    {
        if (buttonFlag)
        {
            NewTapEffect();
        }
    }
    //タップエフェクトを出す
    private void NewTapEffect()
    {
        // 手の位置と回転率をそのままいれて手の位置からエフェクトを生成.
        Instantiate(_tapEffect, _handObject.transform.position, _handObject.transform.localRotation, transform);
        GetComponent<EffectLine>().LineGenerate(_handObject.transform.position, _panelName);
    }
    public void EffectClearGenerete(bool generete)
    {
        if (generete)
        {
            GetComponent<EffectLine>().LineClearGenerete(_panelName);
        }
    }
    public void EffectDestory(bool destory)
    {
        if (destory)
        {
            GetComponent<EffectLine>().LineDestroy(_panelName);
        }
    }
    public void EffectPosReset()
    {
        GetComponent<EffectLine>().PosAllErase(_panelName);
    }
}
