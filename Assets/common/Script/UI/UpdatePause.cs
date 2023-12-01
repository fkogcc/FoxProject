// ポーズ画面の処理.

using UnityEngine;

public class UpdatePause : MonoBehaviour
{
    // ポーズ画面を開いたかどうか.
    [SerializeField] private bool _isPause = false;
    // ポーズ画面のオブジェクト
    [SerializeField] private GameObject _pauseCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ポーズ画面を開いているかどうか.
        _pauseCanvas.gameObject.SetActive(_isPause);

        // 時間を動かす.
        if (!_isPause)
        {
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown("joystick button 7"))
        {
            _isPause = true;
        }
        if (Input.GetKeyDown("joystick button 1"))
        {
            _isPause = false;
        }

        

        
    }

    private void FixedUpdate()
    {
        // 時間を止める.
        if (_isPause)
        {
            Time.timeScale = 0;
        }
    }

}
