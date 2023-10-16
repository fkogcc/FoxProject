using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeObject : MonoBehaviour
{
    // マテリアル.
    private Renderer _fadeMaterial;

    // フェードする速度.
    private float _fadeSpeed = 0.01f;
    // _fadeMaterialの色.
    private float _r, _g, _b, _a;

    // true :フェードアウト開始.
    // false:フェードアウト停止.
    [SerializeField] private bool _isFadeOut = false;

    // Start is called before the first frame update
    void Start()
    {
        _fadeMaterial = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if( _isFadeOut )
        {
            StartFadeOut();
        }
    }

    private void StartFadeOut()
    {
        // 透明度を下げる.
        _a -= _fadeSpeed;
        SetMaterialColor();
        if(_a <= 0)
        {
            _isFadeOut = false;
            // 描画をoff.
            _fadeMaterial.enabled = false;
        }
    }

    private void SetMaterialColor()
    {
        _fadeMaterial.material.color = new Color(_r, _g, _b, _a);
    }
}
