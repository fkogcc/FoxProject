using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    public TitleWindow Window;
    private MoveBackGround _bg;
    private StaffRool _rool;
    private FadeScene _fade;

    private void Start()
    {
        _bg = GetComponent<MoveBackGround>();
        _rool = GetComponent<StaffRool>();
        _fade = GameObject.Find("Fade").GetComponent<FadeScene>();
    }

    private void FixedUpdate()
    {
        Window.WindowUpdate();
        _bg.BgMove();
        _rool.RoolUpdate();

        if (Input.GetKey(KeyCode.L))
        {
            _rool.RoolUpdate();
            _rool.RoolUpdate();
            _rool.RoolUpdate();
        }


        if (_rool.GetIsEnd())
        {
            _fade._isFadeOut = true;
        }

        if (_rool.GetIsEnd() && _fade.GetAlphColor() >= 0.98f)
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
