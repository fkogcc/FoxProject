using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneSelect : MonoBehaviour
{
    // �R���g���[���[�̑���p�N���X
    GameObject _button;
    // �Z���N�g�p�e�L�X�g
    GameObject _titleTextPlay;
    GameObject _titleTextQuit;
    // �I�����Ă���ꏊ
    private int _selectedIndex;
    // �I������i���o�[
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
        // �I��
        Control();
        // �I�𒆂̏ꏊ��F�ς���
        ColorChange(); 

        // �I�����܂�
        if (Input.GetKeyDown("joystick button 0"))
        {
            _selectedNo = _selectedIndex;
        }

        // �Q�[���v���C��ʂɈڍs
        if(_selectedNo == 0)
        {

        }
        // �Q�[���I��
        if (_selectedNo == 1)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
            Application.Quit();//�Q�[���v���C�I��
#endif
        }

        Debug.Log(_selectedIndex);
    }
    private void Control()
    {
        // �I��
        if (_button.GetComponent<TitleButton>().GetUpTrgger())
        {
            _selectedIndex--;
        }
        if (_button.GetComponent<TitleButton>().GetDownTrgger())
        {
            _selectedIndex++;
        }
        // ����
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
        // �I�𒆂̏ꏊ��F�ς���
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
