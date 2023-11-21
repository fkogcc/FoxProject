using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndManager : MonoBehaviour
{
    public TitleWindow Window;
    private MoveBackGround _bg;

    private void Start()
    {
        _bg = GetComponent<MoveBackGround>();
    }

    private void FixedUpdate()
    {
        Window.WindowUpdate();
        _bg.BgMove();
    }
}
