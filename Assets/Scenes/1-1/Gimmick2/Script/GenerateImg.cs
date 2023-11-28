using UnityEngine;

public class GenerateImg : MonoBehaviour
{
    // clearテキストをいれる.
    [SerializeField, Header("クリア画像")] private GameObject ClearImg;
    // Canvasを入れるよう.
    [SerializeField] private GameObject Canvas;
    // テキストの生成.
    private GameObject _img = null;
    // 画像を生成する.
    public void GenerateImage()
    {
        // 一回だけ画像を生成する.
        if (_img == null)
        {
            _img = Instantiate(ClearImg);
            _img.transform.SetParent(Canvas.transform, false);
        }
    }
}
