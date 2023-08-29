using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleButton : MonoBehaviour
{
    private bool _isTrgger;

    // �X�e�B�b�N�̕���
    private bool _isLeftTrgger;
    private bool _isRightTrgger;
    private bool _isUpTrgger;
    private bool _isDownTrgger;
    // Start is called before the first frame update
    void Start()
    {
        _isTrgger = false;
    }

    // Update is called once per frame
    void Update()
    {
        // �X�e�B�b�N�̊p�x���擾
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        LStickTrgger(x, y);

        //if(GetRightTrgger())
        //{
        //    Debug.Log("��");
        //}
        //if (GetLeftTrgger())
        //{
        //    Debug.Log("��");
        //}

        //if (GetUpTrgger())
        //{
        //    Debug.Log("��");
        //}
        //if (GetDownTrgger())
        //{
        //    Debug.Log("��");
        //}
    }

    private void LStickTrgger(float x,float y)
    {
        // �E�̔���
        _isRightTrgger = false;
        if ((x >= 1.0f) && !_isTrgger)
        {
            _isRightTrgger = true;
            _isTrgger = true;
        }
        // ���̔���
        _isLeftTrgger = false;
        if ((x <= -1.0f) && !_isTrgger)
        {
            _isLeftTrgger = true;
            _isTrgger = true;
        }
        // ��̔���
        _isUpTrgger = false;
        if ((y >= 1.0f) && !_isTrgger)
        {
            _isUpTrgger = true;
            _isTrgger = true;
        }
        // ���̔���
        _isDownTrgger = false;
        if ((y <= -1.0f) && !_isTrgger)
        {
            _isDownTrgger = true;
            _isTrgger = true;
        }

        // �������삵�ĂȂ����ǂ���
        if (((x == 0.0f) && (y == 0.0f)) && _isTrgger)
        {
            Debug.Log("Reset");
            _isTrgger = false;

            _isLeftTrgger = false;
            _isRightTrgger = false;
            _isUpTrgger = false;
            _isDownTrgger = false;
        }
    }

    // ��
    public bool GetLeftTrgger()
    {
        return _isLeftTrgger;
    }
    // �E
    public bool GetRightTrgger()
    {
        return _isRightTrgger;
    }
    // ��
    public bool GetUpTrgger()
    {
        return _isUpTrgger;
    }
    // ��
    public bool GetDownTrgger()
    {
        return _isDownTrgger;
    }
}
