using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rota : MonoBehaviour
{
    // 回転時間をカウントします
    private int _count;
    // 任意の時間を刻みで代入します
    public int _countSecondsMax;
    // 1秒60フレームとして調整する
    private int _countMax;
    // 回転が終わったかどうか
    private bool _isRotaEnd;
    // Start is called before the first frame update
    void Start()
    {
        _count = 0;
        _countMax = 60 * _countSecondsMax;
        _isRotaEnd = false;
    }
    private void FixedUpdate()
    {
        // 回転、カウント
        this.transform.Rotate(0.0f, 0.0f, 1.0f);
        _count++;
        
    }
    // 回転が終わったかどうか
    public bool RotaEnd()
    {
        // 回転用フレームカウントを確認
        if (_count > _countMax)
        {
            _isRotaEnd = true;
        }
        return _isRotaEnd;
    }
    // カウントをリセットします
    public void RotaReset()
    {
        _count = 0;
        _isRotaEnd = false;
    }
}
