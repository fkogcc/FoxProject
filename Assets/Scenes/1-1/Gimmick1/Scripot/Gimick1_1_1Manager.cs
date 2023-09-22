using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimick1_1_1Manager : MonoBehaviour
{
    // �n���h���̈ʒu��ύX.
    [SerializeField] private GameObject[] _testHandle;
    // �n���h���̔���.
    [SerializeField] private GameObject[] _testCollHandle;

    // �n���h���̋߂��Ń{�^�������������ǂ���.
    private bool[] _isButtonHandle = {false,false};
    // �ǂ̋߂��Ń{�^�������������ǂ���.
    private bool[] _isButtonWall = { false, false };
    // ��]���n�߂�.
    private bool[] _isRota = { false, false };
    // �Ō�܂ŉ�]���s����.
    private bool[] _isEndRota = { false, false };
    // 1�t���[������^����.
    private bool[] _isOneFrameStop = { false, false };
    // �ǂ̖��O.
    private string[] _handleWallName = {"HandleWall0","HandleWall1"};
    // fot���Ɏg�p����ő吔.
    private int _maxNum;
    // Start is called before the first frame update.
    void Start()
    {
        string objName = "3DPlayer";
        _testCollHandle[0].GetComponent<CollsionHandle>().SetNameColl(objName);
        _testCollHandle[1].GetComponent<CollsionHandle>().SetNameColl(objName);
        _maxNum = 2;
    }

    private void Update()
    {
        for (int i = 0; i < _maxNum; i++)
        {
            // �n���h������肵�Ă��Ȃ��ꍇ.
            if (!_isButtonHandle[i])
            {
                // �n���h���ɓ������Ă�����.
                if (_testCollHandle[i].GetComponent<CollsionHandle>().IsGetHit())
                {
                    // �{�^������������.
                    if (Input.GetKeyDown(KeyCode.JoystickButton1))
                    {
                        _isButtonHandle[i] = true;
                        _testCollHandle[i].GetComponent<CollsionHandle>().SetNameColl(_handleWallName[i]);
                        _testCollHandle[i].GetComponent<CollsionHandle>().SetHit(false);
                    }
                }
            }
            // �n���h������肵���ꍇ.
            if (_isButtonHandle[i] && !_isEndRota[i])
            {
                _testHandle[i].GetComponent<HandlePos>().HandlePosIsPlayer();
                if (_testCollHandle[i].GetComponent<CollsionHandle>().IsGetHit())
                {
                    // �{�^������������.
                    if (Input.GetKeyDown(KeyCode.JoystickButton1))
                    {
                        _isButtonWall[i] = true;
                    }
                }
            }
            // �n���h�����������񂾏ꍇ.
            if (_isButtonWall[i] && !_isEndRota[i])
            {
                _testHandle[i].GetComponent<HandlePos>().HandlePosIsHandleWall(i);
                // ��]���n�߂�.
                if (Input.GetKeyDown(KeyCode.JoystickButton1) && _isOneFrameStop[i])
                {
                    // ��]�w��
                    _isRota[i] = true;
                }
                // ��]�J�n.
                if (_isRota[i])
                {
                    // ��]���x.
                    _testHandle[i].GetComponent<HandlePos>().Rota(0.3f);
                    // ��]����.
                    if (_testHandle[i].GetComponent<HandlePos>().IsGetRotaTimeOver(2000))
                    {
                        // ��]�I��.
                        _isEndRota[i] = true;
                    }
                }
                // �{�^������x�Ƃ߂�.
                _isOneFrameStop[i] = true;
            }
        }
        // ��������I��������ǂ���.
        if (_isEndRota[0] && _isEndRota[1])
        {
            //Debug.Log("�V�[����؂�ւ��Ă�������H�H�H");
        }
    }
}
