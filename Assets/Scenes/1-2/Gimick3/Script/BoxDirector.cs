using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDirector : MonoBehaviour
{
    // �N���A���J�E���g
    int _clearCount;

    // �u���邩�̃t���O
    bool _isSetFlag;

    // �����n�߂����̐F
    string _pullColor;

    // �M�~�b�N�ݒu�ꏊ�̐F
    string _gimmickColor;
    // �M�~�b�N�ݒu�ꏊ�̍��W
    Vector3 _gimmickPos;

    void Start()
    {
        _clearCount = 0;

        _isSetFlag = false;

        _pullColor = "";

        _gimmickColor = "";
        _gimmickPos = new Vector3();
    }

    // �����n�߂��F�̎擾
    public void SetGimmickOut(string color)
    {
        _pullColor = color;
    }

    // �M�~�b�N�ݒu�ꏊ�ɓ���������F�擾
    // ���W�̕ێ�
    // �M�~�b�N�͈͓��ɂ���悤�ɂ���
    public void SetGimmickIn(string color, Vector3 temp)
    {
        _gimmickColor = color;

        _gimmickPos = temp;

        _isSetFlag = true;
    }

    public Vector3 GetGimmickPos()
    {
        return _gimmickPos;
    }

    public void IsSetFlag()
    {
        _isSetFlag = false;
    }

    // �����n�߂��F�Ɠ����Ȃ��true�Ԃ�
    public bool IsSameColor()
    {
        // �͈͊O�ɂ���Ȃ炨���Ȃ��悤�ɂ���
        if (!_isSetFlag) return false;

        if (_pullColor == _gimmickColor)
        {
            _clearCount++;

            return true;
        }

        return false;
    }
}
