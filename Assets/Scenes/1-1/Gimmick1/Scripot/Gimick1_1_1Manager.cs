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
    private bool[] _isButtonHandle;
    // �ǂ̋߂��Ń{�^�������������ǂ���
    private bool[] _isButtonWall;
    // ��]���n�߂�
    private bool[] _isRota;
    // �Ō�܂ŉ�]���s����
    private bool[] _isEndRota;
    // 1�t���[������^����
    private bool[] _isOneFrameStop;
    // Start is called before the first frame update
    void Start()
    {
        //  _testCollHandle �@�@ = GameObject.Find("Handle0");
        //  _posChangeHandle = GameObject.Find("Handle0");

        _isButtonHandle[0] = false;
        _isButtonHandle[1] = false;

        _isButtonWall[0] = false;
        _isButtonWall[1] = false;

        _isRota[0] = false;
        _isRota[1] = false;

        _isEndRota[0] = false;
        _isEndRota[1] = false;

        _isOneFrameStop[0] = false;
        _isOneFrameStop[1] = false;

        _testCollHandle[0].GetComponent<CollsionHandle>().SetNameColl("3DPlayer");
        _testCollHandle[1].GetComponent<CollsionHandle>().SetNameColl("3DPlayer");

        
    }



    private void Update()
    {
        for(int i = 0; i > 2; i++)
        {

            // �n���h������肵�Ă��Ȃ��ꍇ
            if (!_isButtonHandle[i])
            {
                // �n���h���ɓ������Ă�����
                if (_testCollHandle[0].GetComponent<CollsionHandle>().IsGetHit())
                {
                    // �{�^������������
                    if (Input.GetKeyDown(KeyCode.JoystickButton1))
                    {
                        _isButtonHandle[i] = true;
                        _testCollHandle[i].GetComponent<CollsionHandle>().SetNameColl("HandleWall0");
                        _testCollHandle[i].GetComponent<CollsionHandle>().SetHit(false);
                    }
                }
            }

            // �n���h������肵���ꍇ
            if (_isButtonHandle[i] && !_isEndRota[i])
            {
                _testHandle[0].GetComponent<HandlePos>().HandlePosIsPlayer();
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
                _testHandle[0].GetComponent<HandlePos>().HandlePosIsHandleWall();
                // ��]���n�߂�
                if (Input.GetKeyDown(KeyCode.JoystickButton1) && _isOneFrameStop[i])
                {
                    _isRota[i] = true;
                }
                if (_isRota[i])
                {
                    _testHandle[i].GetComponent<HandlePos>().Rota(0.3f);
                    if (_testHandle[i].GetComponent<HandlePos>().IsGetRotaTimeOver(6000))
                    {
                        _isEndRota[i] = true;
                    }
                }
                _isOneFrameStop[i] = true;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    // ��������I��������ǂ���
    //public bool isEnd()
    //{
    //    return _isEndRota[;
    //}
}
