using UnityEngine;
using UnityEngine.UI;

// テキストのフェードをさせるスクリプト.
public class ImageManager : MonoBehaviour
{
    // 32フレームで消えるように.
    private readonly float kAlpha = 0.01f;

    // 色を入れるよう.
    private Color _color;

    private void Start()
    {
        _color = gameObject.GetComponent<Image>().color;
        _color.a = 0.0f;
    }

    private void FixedUpdate()
    {
        // 現在のアルファ値からたしていく.
        _color.a += kAlpha;
        gameObject.GetComponent<Image>().color = _color;
        if (_color.a > 1.0f)
        {
            _color.a = 1.0f;
        }
    }
}
