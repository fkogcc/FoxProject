using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideGimmickDirector : MonoBehaviour
{
    const int kNum = 16;

    GameObject _parentObj;
    GameObject[] _gimmickObj;

    bool[] _isPut;
    int[] _eles;

    Vector3 _tempPos1;
    Vector3 _tempPos2;
    int _tempEle;

    void Start()
    {
        _parentObj = new GameObject();
        _gimmickObj = new GameObject[kNum];

        _isPut = new bool[kNum];
        _eles = new int[kNum];

        _tempPos1 = new Vector3();
        _tempPos2 = new Vector3();

        _parentObj = GameObject.Find("Box");

        for (int i = 0; i < kNum; i++)
        {
            _gimmickObj[i] = _parentObj.transform.GetChild(i).gameObject;
            _isPut[i] = true;
            _eles[i] = i;
        }

        _isPut[kNum - 1] = false;
    }

    public void EleCheck(int ele)
    {
        if (!_isPut[ele]) return;

        // ��̃`�F�b�N
        if (0 <= ele - 4 && ele - 4 < kNum)
        {
            if(!_isPut[ele - 4])
            {
                // �ʒu����ւ�
                ChangeTrs(ele, ele - 4);

                return;
            }
            Debug.Log("��Ⴄ");
        }
        // ���̃`�F�b�N
        if (0 <= ele + 4 && ele + 4 < kNum)
        {
            if (!_isPut[ele + 4])
            {
                ChangeTrs(ele, ele + 4);

                return;
            }
            Debug.Log("���Ⴄ");
        }
        // ���̃`�F�b�N
        if (0 <= ele - 1 && ele - 1 < kNum && ele % 4 != 0)
        {
            if (!_isPut[ele - 1])
            {
                ChangeTrs(ele, ele - 1);

                return;
            }
            Debug.Log("���Ⴄ");
        }
        // �E�̃`�F�b�N
        if (0 <= ele + 1 && ele + 1 < kNum && ele % 4 != 3)
        {
            if (!_isPut[ele + 1])
            {
                ChangeTrs(ele, ele + 1);

                return;
            }
            Debug.Log("�E�Ⴄ");
        }
    }

    /// �ʒu�̕ύX
    void ChangeTrs(int ele1, int ele2)
    {
        _tempPos1 = _gimmickObj[_eles[ele1]].transform.position;
        _tempPos2 = _gimmickObj[kNum - 1].transform.position;

        _gimmickObj[_eles[ele1]].transform.position = _tempPos2;
        _gimmickObj[kNum - 1].transform.position = _tempPos1;

        _isPut[ele1] = false;
        _isPut[ele2] = true;

        _tempEle = _eles[ele1];
        _eles[ele1] = _eles[ele2];
        _eles[ele2] = _tempEle;

        // �f�o�b�O�\�L�p
        Debug.Log("���݂̏��");
        for (int i = 0; i < 4; i++)
        {
            Debug.Log(_isPut[i * 4] + ", " + _isPut[i * 4 + 1] + ", " + _isPut[i * 4 + 2] + ", " + _isPut[i * 4 + 3] + ", ");
        }
        for (int i = 0; i < 4; i++)
        {
            Debug.Log(_eles[i * 4] + ", " + _eles[i * 4 + 1] + ", " + _eles[i * 4 + 2] + ", " + _eles[i * 4 + 3] + ", ");
        }

    }
}
