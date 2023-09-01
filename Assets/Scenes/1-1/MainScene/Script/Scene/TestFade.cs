using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestFade : MonoBehaviour
{
    public Color _color;// �F

    private bool _isPush;// �Q�[�g�̃{�^�������������ǂ���

    // Start is called before the first frame update
    void Start()
    {
        // ������
        _isPush = false;
        _color = gameObject.GetComponent<Image>().color;
        _color.r = 0.0f;
        _color.g = 0.0f;
        _color.b = 0.0f;
        _color.a = 1.0f;
        gameObject.GetComponent<Image>().color = _color;
    }

    // Update is called once per frame
    void Update()
    {
        // �t�F�[�h����
        FadeUpdate();
        // �V�[���J�ڊ֐�
        SceneTransition();
    }

    // �Q�[�g�̑O�ɂ��邩�̏��
    bool SetGateFlag()
    {
        return testCol._instance._isGateGimmick1 || testCol._instance._isGateGimmick2;
    }

    // �t�F�[�h����
    void FadeUpdate()
    {
        // �t�F�[�h�C���t���O
        if (_color.a >= 1.0f)
        {
            _isPush = false;
        }

        // �����x���Œ艻
        if (_color.a <= 0.0f)
        {
            _color.a = 0.0f;
        }

        // �t�F�[�h�C��
        if (!_isPush)
        {
            _color.a -= 0.01f;
            gameObject.GetComponent<Image>().color = _color;
        }
        else// �t�F�[�h�A�E�g
        {
            _color.a += 0.01f;
            gameObject.GetComponent<Image>().color = _color;
        }
    }

    // �V�[���J��
    void SceneTransition()
    {
        // �{�^����������(�{�^���z�u�͉�)
        if (Input.GetKeyDown("joystick button 3"))
        {
            // �Q�[�g�̑O�ɂ��Ȃ��Ƃ��̓X�L�b�v
            if (!SetGateFlag()) return;
            _isPush = true;
        }

        // �V�[���J��
        if (testCol._instance._isGateGimmick1 && _color.a >= 0.9f)
        {
            SceneManager.LoadScene("Gimmick1Scene");
        }
        else if (testCol._instance._isGateGimmick2 && _color.a >= 0.9f)
        {
            SceneManager.LoadScene("Gimmick2Scene");
        }

    }
}
