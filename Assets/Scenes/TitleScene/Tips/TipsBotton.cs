using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsBotton : MonoBehaviour
{
    public bool _isA;
    public bool _isB;
    public bool _isX;
    public bool _isY;

    // 画像を描画
    Image _image;

    // 画像データ.
    public Sprite _sprite;

    public float _imageSize;

    // トランスフォームクラスの初期化
    private RectTransform rectTransform = null;

    private bool _isHit = false;

    void Start()
    {
        // パネルにImageコンポーネントを追加.
        _image = gameObject.AddComponent<Image>();
        // 画像をアタッチ.
        _image.sprite = _sprite;

        // RectTransformを取得して設定.
        rectTransform = _image.rectTransform;

        // 16:9アスペクト比に設定.
        float targetAspectRatio = 16.0f / 9.0f;
        rectTransform.sizeDelta = new Vector2(1080, 1080 / targetAspectRatio); // 16:9アスペクト比を維持した高さ.
        // 画面外の上に配置.
        rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        rectTransform.pivot = new Vector2(0.5f, 0.5f);
        rectTransform.anchoredPosition = new Vector2(0.0f, 0.0f);
        rectTransform.localScale = new Vector3(_imageSize, _imageSize, _imageSize);
    }

    void Update()
    {
        if(_isHit)
        {
            Debug.Log("描画");

            

        }
    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerStay(Collider coll)
    {
        // プレイヤーに触れたら
        if (coll.gameObject.tag == "Player")
        {
            _isHit = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // プレイヤーに触れたら
        if (other.gameObject.tag == "Player")
        {
            _isHit = false;
        }
    }

}
