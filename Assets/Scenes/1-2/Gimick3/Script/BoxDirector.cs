using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxDirector : MonoBehaviour
{
    // ���̃V�[���̖��O.
    public string NextStageName;

    // �N���A���J�E���g.
    private int _clearCount;
    // �u���邩�̃t���O.
    private bool _isSetFlag;
    // �����n�߂����̐F.
    private string _pullColor;
    // �M�~�b�N�ݒu�ꏊ�̐F.
    private string _gimmickColor;
    // �M�~�b�N�ݒu�ꏊ�̍��W.
    private Vector3 _gimmickPos;
    // �M�~�b�N�̍ő吔.
    private int _gimmickNum;

    // ����������
    void Start()
    {
        _clearCount = 0;
        _isSetFlag = false;
        _pullColor = "";
        _gimmickColor = "";
        _gimmickPos = new Vector3();
        _gimmickNum = 4;
    }

    // �����n�߂��F�̎擾
    public void SetGimmickOut(string color)
    {
        _pullColor = color;
    }

    // �M�~�b�N�ɓ����������̏���.
    public void SetGimmickIn(string color, Vector3 temp)
    {
        // �M�~�b�N�ݒu�ꏊ�ɓ���������F�擾.
        _gimmickColor = color;
        // ���W�̕ێ�.
        _gimmickPos = temp;
        // �M�~�b�N�͈͓��ɂ���悤�ɂ���.
        _isSetFlag = true;
    }
    // �M�~�b�N�̈ʒu��Ԃ�.
    public Vector3 GetGimmickPos()
    {
        return _gimmickPos;
    }

    // �t���O��Ԃ�.
    public void IsSetFlag(bool flag)
    {
        _isSetFlag = flag;
    }

    // �����n�߂��F�Ɠ����Ȃ��true�Ԃ�.
    public bool IsSameColor()
    {
        // �͈͊O�ɂ���Ȃ炨���Ȃ��悤�ɂ���.
        if (!_isSetFlag) return false;

        if (_pullColor == _gimmickColor)
        {
            _clearCount++;

            if (_gimmickNum <= _clearCount)
            {
                Debug.Log("[BoxGimmick]�N���A���܂���");

                SceneManager.LoadScene(NextStageName);
            }
            return true;
        }
        return false;
    }
}
