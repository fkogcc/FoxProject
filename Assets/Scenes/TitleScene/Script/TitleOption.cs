using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleOption : MonoBehaviour
{
    // ボリュームの変更量
    private const float kValumNum = 0.02f;

    public GameObject OptionCas;
    public Slider BgmSlider;
    public Slider SeSlider;

    private SoundManager _soundManager;

    private bool _isSelect;

    float _alpha;
    // フェードインアウトの真偽.
    private bool _isFadeIn;
    private bool _isFadeOut;

    void Start()
    {
        OptionCas.SetActive(false);
        _soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        _isSelect = false;
        _isFadeIn = false;
        _isFadeOut = false;
        _alpha = 0.0f;
    }

    // Update is called once per frame
    public void OptionUpdate()
    {
        // 非アクティブなら処理しない
        if (!OptionCas.activeSelf) return;

        // Bボタン押したら終了
        if (Input.GetKeyDown("joystick button 0"))
        {
            _isFadeIn = false;
            _isFadeOut = true;
        }

        if (Input.GetAxisRaw("Horizontal") > 0.5f)
        {
            _soundManager.MasterVolumeChangeBgm(kValumNum);
            _soundManager.MasterVolumeChangeSe(kValumNum);
        }
        if (Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            _soundManager.MasterVolumeChangeBgm(-kValumNum);
            _soundManager.MasterVolumeChangeSe(-kValumNum);
        }
    }

    public void ChangeVulm()
    {
        BgmSlider.value = _soundManager.GetVolumeBgm();
        BgmSlider.value = _soundManager.GetVolumeSe();
    }

    // フェード処理.
    public void FadeUpdate()
    {
        // 非アクティブなら処理しない
        if (!OptionCas.activeSelf) return;

        if (_alpha <= 0.0f && _isFadeOut)
        {
            _isFadeOut = false;
            OptionCas.SetActive(false);
        }
        // 透明度を固定化.
        if (_alpha >= 1.0f)
        {
            _alpha = 1.0f;
            _isFadeIn = false;
        }

        // フェードイン.
        if (_isFadeIn)
        {
            _alpha += 0.01f;
            OptionCas.GetComponent<CanvasGroup>().alpha = _alpha;
        }
        // フェードアウト.
        else if (_isFadeOut)
        {
            _alpha -= 0.01f;
            OptionCas.GetComponent<CanvasGroup>().alpha = _alpha;
        }
    }

    public void Indicate()
    {
        // アクティブなら処理しない
        if (OptionCas.activeSelf) return;

        OptionCas.SetActive(true);
        OptionCas.GetComponent<CanvasGroup>().alpha = _alpha;
        _isFadeIn = true;
    }
}
