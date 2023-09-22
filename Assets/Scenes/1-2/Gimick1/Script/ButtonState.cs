using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonState : MonoBehaviour
{
    // �{�^���̉�������Ԃ�ۑ����邽�߂�SerializeField�ŊǗ�����.
    [SerializeField] private GameObject[] _objGet;
    // �������{�^���̖��O���擾����.
    private string _buttonName;
    // �{�^���̏��(�{�^���������ꂽ���ǂ���)���擾����.
    private bool _isButtonState = false;
    // �z����Ǘ����邽�߂ɗp��.
    private int _num = 0;
    // ���O���`�F�b�N���邽�߂ɗp��.
    private bool _isTestNameCheck = false;
    // �{�^���̏�Ԃ�n�����߂ɃI�u�W�F�N�g���擾.
    private GameObject _playerObject;
    // script���擾.
    PlayerHand _player;

    // Start is called before the first frame update
    void Start()
    {
        // ����������.
        _buttonName = "";
        _isButtonState = false;
        _num = 0;
        _isTestNameCheck = false;
        // �I�u�W�F�N�g���擾.
        _playerObject = GameObject.Find("FoxHand");
        // �I�u�W�F�N�g�̒��ɂ���script���擾.
        _player = _playerObject.GetComponent<PlayerHand>();
    }

    // Update is called once per frame
    void Update()
    {
        // �{�^���������ꂽ���ǂ������擾����.
        _isButtonState = _player._isButtonState;
        // �{�^����������Ă�����.
        if (_isButtonState)
        {
            // �{�^���̖��O���擾����.
            _buttonName = _player._buttonName;
            // _num��0��������.
            // (for������0�̂܂܂��Ɖ��Ȃ����߂�0�Ԗڂ̂ݏ���).
            if (_num == 0)
            {
                // 0�Ԗڂɕۑ�.
                _objGet[_num] = GameObject.Find(_buttonName);
                // �v�f��ǉ�.
                _num++;
            }
            // for���ŏ�������.
            for (int obj = 0; obj < _num; obj++)
            {
                // �擾�����{�^���̖��O�ƍ��ۑ����Ă���{�^���̖��O���ꏏ��������.
                if (_objGet[obj].gameObject.name == _buttonName)
                {
                    // �����擾�����{�^���Ȃ̂ŕۑ����Ȃ��t���O�𗧂Ă�.
                    _isTestNameCheck = false;
                    // for�����~�߂�.
                    break;
                }
                // �����ꏏ����Ȃ�������.
                else
                {
                    // �ۑ�����t���O�𗧂Ă�.
                    _isTestNameCheck = true;
                }
            }
            //�@�ۑ�����t���O�������Ă�����.
            if (_isTestNameCheck)
            {
                // _num�Ԗڂɗv�f��ۑ�.
                _objGet[_num] = GameObject.Find(_buttonName);
                _num++;
            }
        }
        else
        {
            _isButtonState = false;
        }
    }
    void FixedUpdate()
    {

    }
}
