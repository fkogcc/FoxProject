// クリアシーンマネージャー.

using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearSceneManager : MonoBehaviour
{
    // 現在の経過時間.
    public int _currentTime;
    // フェード.
    private FadeScene _fade;

    private void Start()
    {
        _fade = GameObject.Find("Fade").GetComponent<FadeScene>();
    }

    private void FixedUpdate()
    {
        _currentTime++;

        if(_currentTime >= 500)
        {
            _fade._isFadeOut = true;
        }

        if(_fade._color.a >= 0.9f && _currentTime >= 500)
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
