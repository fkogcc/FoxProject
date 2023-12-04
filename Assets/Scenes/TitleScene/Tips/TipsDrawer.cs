using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsDrawer : MonoBehaviour
{
    // 画像データ.
    public Sprite _sprite; 
    // 下にスライドさせる場合の速度.
    public float _slideDownSpeed;
    // 上にスライドさせる場合の速度.
    public float _slideUpSpeed;
    // 画像サイズ
    public float _imageSize;

    // 画像クラスの初期化
    private Image _image = null;
    // トランスフォームクラスの初期化
    private RectTransform rectTransform = null;

    // スライド用の速度
    private float _slideSpeed = 0.0f;

    // スライドの方向
    private bool _isDownSlider = false;
    private bool _isUpSlider = false;

    private UpdatePause _pause;

    // スライドの位置を確かめる
    public bool _isSlideStart { get; private set; }
    public bool _isSlideEnd   { get; private set; }

    private Player3DMove _player;

    void Start()
    {
        //// Canvasを取得または作成.
        //Canvas canvas = GetComponent<Canvas>();
        //canvas = gameObject.AddComponent<Canvas>();

        //canvas.renderMode = RenderMode.ScreenSpaceCamera;

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
        rectTransform.anchorMin        = new Vector2(0.5f, 0.5f);
        rectTransform.anchorMax        = new Vector2(0.5f, 0.5f);
        rectTransform.pivot            = new Vector2(0.5f, 0.5f);
        rectTransform.anchoredPosition = new Vector2(0.0f, 1080.0f);
        rectTransform.localScale       = new Vector3(_imageSize, _imageSize, _imageSize);

        _pause = GameObject.Find("PauseSystem").GetComponent<UpdatePause>();

        _isSlideStart = true;
        _isSlideEnd = false;

        _player = GameObject.Find("3DPlayer").GetComponent<Player3DMove>();
    }


    private void Update()
    {
        // if 下にスライドの場合
        // else if 上にスライド
        if(_isDownSlider)
        {
            // Y軸で下にスライドさせるのでマイナス.
            _slideSpeed = (-_slideDownSpeed);
            // 画面の中心まで移動するとスライドを止める.
            if(rectTransform.anchoredPosition.y <= 1.0f)
            {
                _isSlideStart = false;
                _isSlideEnd   = true;

                _isDownSlider = false;
                _slideSpeed = 0.0f;
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, 1.0f);
            }
        }
        else if(_isUpSlider)
        {
            _slideSpeed = _slideUpSpeed;
            if (rectTransform.anchoredPosition.y >= 1080.0f)
            {
                _isSlideStart = true;
                _isSlideEnd = false;

                _isUpSlider = false;
                _slideSpeed = 0.0f;
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, 1080.0f);

            }
        }

        // 画像をスライドさせる.
        rectTransform.anchoredPosition += new Vector2(0.0f, _slideSpeed);
    }

    

    // 下にスライドさせる場合.
    public void IsDownSlider()
    {
        _isDownSlider = true;
        _isUpSlider = false;
        _player._isController = false;
    }
    // 上にスライドさせる場合.
    public void IsUpSlider()
    {
        _isUpSlider = true;
        _isDownSlider = false;
        _player._isController = true;
    }

    public bool IsUpSliderResult()
    {
        return _isUpSlider;
    }
    public bool IsDownSliderResult()
    {
        return _isDownSlider;
    }
}
