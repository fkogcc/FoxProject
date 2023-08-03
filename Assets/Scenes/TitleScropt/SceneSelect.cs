using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneSelect : MonoBehaviour
{
    // コントローラーの操作用クラス
    GameObject _button;
    // セレクト用テキスト
    GameObject _titleTextPlay;
    GameObject _titleTextQuit;
    // 選択している場所
    private int _selectedIndex;
    // 選択決定ナンバー
    private int _selectedNo;
    // Start is called before the first frame update
    void Start()
    {
        _button = GameObject.Find("ButtonSystem");
        _titleTextPlay = GameObject.Find("SelectPlay");
        _titleTextQuit = GameObject.Find("SelectQuit");
        _selectedIndex = 0;
        _selectedNo = -1;
    }

    // Update is called once per frame
    void Update()
    {
        // 選択
        Control();
        // 選択中の場所を色変える
        ColorChange(); 

        // 選択します
        if (Input.GetKeyDown("joystick button 0"))
        {
            _selectedNo = _selectedIndex;
        }

        // ゲームプレイ画面に移行
        if(_selectedNo == 0)
        {

        }
        // ゲーム終了
        if (_selectedNo == 1)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
            Application.Quit();//ゲームプレイ終了
#endif
        }

        Debug.Log(_selectedIndex);
    }
    private void Control()
    {
        // 選択
        if (_button.GetComponent<TitleButton>().GetUpTrgger())
        {
            _selectedIndex--;
        }
        if (_button.GetComponent<TitleButton>().GetDownTrgger())
        {
            _selectedIndex++;
        }
        // 制御
        if (_selectedIndex >= 2)
        {
            _selectedIndex = 0;
        }
        if (_selectedIndex <= -1)
        {
            _selectedIndex = 1;
        }
    }
    private void ColorChange()
    {
        // 選択中の場所を色変える
        if (_selectedIndex == 0)
        {
            _titleTextPlay.GetComponent<TextMeshProUGUI>().color = Color.blue;
        }
        else
        {
            _titleTextPlay.GetComponent<TextMeshProUGUI>().color = Color.white;
        }
        if (_selectedIndex == 1)
        {
            _titleTextQuit.GetComponent<TextMeshProUGUI>().color = Color.blue;
        }
        else
        {
            _titleTextQuit.GetComponent<TextMeshProUGUI>().color = Color.white;
        }
    }

}
