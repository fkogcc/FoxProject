using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideGimmickDirector : MonoBehaviour
{
    const int kNum = 16;

    GameObject[] _gimmickObj;

    bool[] _isPut;

    Vector3 _tempPos1;
    Vector3 _tempPos2;

    void Start()
    {
        _gimmickObj = new GameObject[kNum];

        _isPut = new bool[kNum];

        _tempPos1 = new Vector3();
        _tempPos2 = new Vector3();

        for (int i = 0; i < kNum - 1; i++)
        {
            _gimmickObj[i] = GameObject.Find((i).ToString());
            _isPut[i] = true;
        }

        _gimmickObj[kNum - 1] = GameObject.Find((kNum - 1).ToString());
        _isPut[kNum - 1] = false;
    }

    public void EleCheck(int ele)
    {
        // �z��v�f�Ȃ����̔���

        Debug.Log("[SlideGmmick] checkNum : " + ele);

        // ��̃`�F�b�N
        if (0 <= ele - 4 && ele - 4 < kNum)
        {
            Debug.Log("[SlideGmmick] ��`�F�b�N");

            if(!_isPut[ele - 4])
            {
                // �ʒu����ւ�
                ChangeTrs(ele, ele - 4);

                Debug.Log("[SlideGmmick] ����ւ��܂���");
                return;
            }
        }
        // ���̃`�F�b�N
        if (0 <= ele + 4 && ele + 4 < kNum)
        {
            Debug.Log("[SlideGmmick] ���`�F�b�N");
            if (!_isPut[ele + 4])
            {
                ChangeTrs(ele, ele + 4);

                Debug.Log("[SlideGmmick] ����ւ��܂���");
                return;
            }
        }
        // ���̃`�F�b�N
        if (0 <= ele - 1 && ele - 1 < kNum)
        {
            Debug.Log("[SlideGmmick] ���`�F�b�N");
            if (!_isPut[ele - 1])
            {
                ChangeTrs(ele, ele - 1);

                Debug.Log("[SlideGmmick] ����ւ��܂���");
                return;
            }
        }
        // �E�̃`�F�b�N
        if (0 <= ele + 1 && ele + 1 < kNum)
        {
            Debug.Log("[SlideGmmick] �E�`�F�b�N");
            if (!_isPut[ele + 1])
            {
                ChangeTrs(ele, ele + 1);

                Debug.Log("[SlideGmmick] ����ւ��܂���");
                return;
            }
        }

        Debug.Log("[SlideGmmick] ����ւ���܂���ł���");
    }

    /// �ʒu�̕ύX
    void ChangeTrs(int ele1, int ele2)
    {
        Debug.Log("�ύX�O");
        Debug.Log(_gimmickObj[ele1].transform.position);
        Debug.Log(_gimmickObj[ele2].transform.position);

        _tempPos1 = _gimmickObj[ele1].transform.position;
        _tempPos2 = _gimmickObj[ele2].transform.position;

        _gimmickObj[ele1].transform.position = _tempPos2;
        _gimmickObj[ele2].transform.position = _tempPos1;

        Debug.Log("�ύX��");
        Debug.Log(_gimmickObj[ele1].transform.position);
        Debug.Log(_gimmickObj[ele2].transform.position);

        _isPut[ele1] = false;
        _isPut[ele2] = true;
    }
}
