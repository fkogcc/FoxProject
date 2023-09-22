using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimick1_1_1Manager : MonoBehaviour
{

    // �n���h���̔���
    //   private GameObject _collHandle;
    // �n���h���̈ʒu��ύX
    //   private GameObject _posChangeHandle;

    [SerializeField] private GameObject[] _testHandle;
    [SerializeField] private GameObject[] _testCollHandle;

    // �n���h���̋߂��Ń{�^�������������ǂ���
    private bool[] _isButtonHandle = {false,false};
    // �ǂ̋߂��Ń{�^�������������ǂ���
    private bool[] _isButtonWall = { false, false };
    // ��]���n�߂�
    private bool[] _isRota = { false, false };
    // �Ō�܂ŉ�]���s����
    private bool[] _isEndRota = { false, false };
    // 1�t���[������^����
    private bool[] _isOneFrameStop = { false, false };

    private string[] _handleWallName = {"HandleWall0","HandleWall1"};
    // Start is called before the first frame update
    void Start()
    {
        _testCollHandle[0].GetComponent<CollsionHandle>().SetNameColl("3DPlayer");
        _testCollHandle[1].GetComponent<CollsionHandle>().SetNameColl("3DPlayer");
    }



    private void Update()
    {
        for (int i = 0; i < 2; i++)
        {
            // �n���h������肵�Ă��Ȃ��ꍇ
            if (!_isButtonHandle[i])
            {
                // �n���h���ɓ������Ă�����
                if (_testCollHandle[i].GetComponent<CollsionHandle>().IsGetHit())
                {
                    // �{�^������������
                    if (Input.GetKeyDown(KeyCode.JoystickButton1))
                    {
                        _isButtonHandle[i] = true;
                        _testCollHandle[i].GetComponent<CollsionHandle>().SetNameColl(_handleWallName[i]);
                        _testCollHandle[i].GetComponent<CollsionHandle>().SetHit(false);
                    }
                }
            }

            // �n���h������肵���ꍇ
            if (_isButtonHandle[i] && !_isEndRota[i])
            {
                _testHandle[i].GetComponent<HandlePos>().HandlePosIsPlayer();
                if (_testCollHandle[i].GetComponent<CollsionHandle>().IsGetHit())
                {
                    // �{�^������������
                    if (Input.GetKeyDown(KeyCode.JoystickButton1))
                    {
                        _isButtonWall[i] = true;
                    }
                }
            }
     
            // �n���h�����������񂾏ꍇ
            if (_isButtonWall[i] && !_isEndRota[i])
            {
                _testHandle[i].GetComponent<HandlePos>().HandlePosIsHandleWall(i);
                // ��]���n�߂�
                if (Input.GetKeyDown(KeyCode.JoystickButton1) && _isOneFrameStop[i])
                {
                    // ��]�w��
                    _isRota[i] = true;
                }
                // ��]�J�n
                if (_isRota[i])
                {
                    // ��]���x
                    _testHandle[i].GetComponent<HandlePos>().Rota(0.3f);
                    // ��]����
                    if (_testHandle[i].GetComponent<HandlePos>().IsGetRotaTimeOver(2000))
                    {
                        // ��]�I��
                        _isEndRota[i] = true;
                    }
                }
                // �{�^������x�Ƃ߂�
                _isOneFrameStop[i] = true;
            }


        }
        // ��������I��������ǂ���
        if(_isEndRota[0] && _isEndRota[1])
        {
            Debug.Log("�V�[����؂�ւ��Ă�������H�H�H");
        }
    }
}
