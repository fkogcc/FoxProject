using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDirector : MonoBehaviour
{
    // �u���邩�̃t���O
    bool _isSetFlag;

    // �F�p�ϐ�
    string _gimmickColor;

    void Start()
    {
        _isSetFlag = false;

        _gimmickColor = "";
    }

    // �����n�߂��F�̎擾
    void SetGimmickColor(string color)
    {
        _gimmickColor = color;
    }

    // �����n�߂��F�Ɠ����Ȃ��true�Ԃ�
    bool IsSameColor(string color)
    {
        if (_gimmickColor == color)
        {
            return true;
        }

        return false;
    }
}
