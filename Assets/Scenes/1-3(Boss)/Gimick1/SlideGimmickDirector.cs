using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideGimmickDirector : MonoBehaviour
{
    // �������u���b�N�̐�.
    const int kNum = 16;

    // �e�I�u�W�F.
    GameObject _parentObj;
    // �q�I�u�W�F.
    GameObject[] _gimmickObj;

    // ������Ă��邩.
    bool[] _isPut;
    // �v�f�̔ԍ�.
    int[] _eles;

    // ����ւ��p.
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

        // �e�I�u�W�F��T��.
        _parentObj = GameObject.Find("Box");

        for (int i = 0; i < kNum; i++)
        {
            // �q�I�u�W�F��T��.
            _gimmickObj[i] = _parentObj.transform.GetChild(i).gameObject;
            // ������Ă��邱�Ƃɂ���.
            _isPut[i] = true;
            // �����ԍ��̑��.
            _eles[i] = i;
        }

        // �Ō�̂͋󔒒n�̂��ߓ�����Ă��Ȃ��ɂ���.
        _isPut[kNum - 1] = false;


        // �V���b�t��
        for(int i = 0; i < 32; i++)
        {
            ChangeTrs(Random.Range(0, kNum), Random.Range(0, kNum));
        }
    }

    public void EleCheck(int ele)
    {
        // �v�f�ԍ��̈ʒu���󔒒n�Ȃ牽�����Ȃ�
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
    // �v�f��ځA�v�f���
    void ChangeTrs(int ele1, int ele2)
    {
        // ���ꂼ��̈ʒu��ۑ�.
        _tempPos1 = _gimmickObj[_eles[ele1]].transform.position;
        _tempPos2 = _gimmickObj[_eles[ele2]].transform.position;

        // �ۑ������ʒu���g���A�ʒu�̓���ւ�.
        _gimmickObj[_eles[ele1]].transform.position = _tempPos2;
        _gimmickObj[_eles[ele2]].transform.position = _tempPos1;

        // �v�f�̔ԍ���ύX.
        _tempEle = _eles[ele1];
        _eles[ele1] = _eles[ele2];
        _eles[ele2] = _tempEle;

        // bool�̕ύX.
        if (!_isPut[ele2])
        {
            _isPut[ele1] = false;
            _isPut[ele2] = true;
        }
        else if (!_isPut[ele1])
        {
            _isPut[ele1] = true;
            _isPut[ele2] = false;
        }
        
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
