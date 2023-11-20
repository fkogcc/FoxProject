using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPlay : MonoBehaviour
{
    public GameObject _tapEffect;
    private GameObject _handObject;
    private EffectLine _effectLine;
    private string _panelName;
    SoundManager _soundManager = null;
    // clearテキストをいれる
    [SerializeField, Header("クリアテキスト")] private GameObject ClearText;
    // Canvasを入れるよう
    [SerializeField] private GameObject Canvas;

    private void Start()
    {
        _handObject = null;
    }
    public void EffectInit()
    {
        _effectLine = GetComponent<EffectLine>();
        _effectLine.LineInit();
    }

    public void GetPanelName(string name)
    {
        _panelName = name;
    }
    public void GetSoundData(SoundManager sound)
    {
        _soundManager = sound;
    }
    public void GetPlayerObject(GameObject handobj)
    {
        // オブジェクトを取得.
        _handObject = handobj;
    }

    public void CheckTap(bool buttonFlag)
    {
        _effectLine.LineEndDraw();
        if (buttonFlag)
        {
            _soundManager.PlaySE("1_2_1_Button");
            NewTapEffect();
        }
    }
    //タップエフェクトを出す
    private void NewTapEffect()
    {
        // 手の位置と回転率をそのままいれて手の位置からエフェクトを生成.
        Instantiate(_tapEffect, _handObject.transform.position, _handObject.transform.localRotation, transform);
        _effectLine.LineGenerate(_handObject.transform.position, _panelName);
    }
    public void EffectClearGenerete(bool generete)
    {
        if (generete)
        {
            _soundManager.PlaySE("1_2_1_Clear");
            _effectLine.LineClearGenerete(_panelName);
        }
    }
    public void EffectDestory(bool destory)
    {
        if (destory)
        {
            _soundManager.PlaySE("1_2_1_Miss");
            _effectLine.LineDestroy(_panelName);
        }
    }
    public void EffectPosReset()
    {
        _effectLine.PosAllErase(_panelName);
    }
    // クリアしたらテキストを生成する
    public void GenaretaText()
    {
        // Test 眠すぎて適当なので後で書き直す！！！！！！！！！！！！！！！！！！
        // クリアしたことをテキストで表示
        if (_effectLine.GetResult())
        {
            _soundManager.StopBgm();
            GameObject clone = Instantiate(ClearText);
            clone.transform.SetParent(Canvas.transform, false);
        }
    }
}
