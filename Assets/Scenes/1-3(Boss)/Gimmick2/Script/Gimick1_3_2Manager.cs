using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimick1_3_2Manager : MonoBehaviour
{
    [SerializeField] private ResetButton _reset;
    [SerializeField] private SoundManager _sound;
    [SerializeField] private TipsDrawer _tips;
    // Start is called before the first frame update
    void Start()
    {
        _reset.SoundDataSet(_sound);
        _tips.IsDownSlider();
    }

    // Update is called once per frame
    void Update()
    {
        // リセットボタンの処理.
        _reset.ResetPush();
    }
}
