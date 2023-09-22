using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimickButton : MonoBehaviour
{
    // �����蔻����ɂ��邩�ǂ����ۑ�����t���O.
    public bool _isCollision;
    // �{�^���̉�������Ԃ�ۑ�����t���O.
    public bool _isButtonState;
    // �{�^���̏�Ԃ�n�����߂ɃI�u�W�F�N�g���擾.
    private GameObject _gameObject;
    // script���擾.
    PlayerHand _player;
    // �v���C���[���G�ꂢ�Ă���{�^���̖��O������邽�߂̕ϐ�.
    private string _name;

    // Start is called before the first frame update
    void Start()
    {
        // �t���O�̏�����.
        _isCollision = false;

        // �I�u�W�F�N�g���擾.
        _gameObject = GameObject.Find("FoxHand");
        // �I�u�W�F�N�g�̒��ɂ���script���擾.
        _player = _gameObject.GetComponent<PlayerHand>();
    }

    // Update is called once per frame
    void Update()
    {
        // ���g�̖��O�ƃv���C���[���G��Ă���{�^���̖��O���ꏏ��������.
        if (_name == this.gameObject.name)
        {
            // �݂ǂ�ɐF��ς���.
            GetComponent<Renderer>().material.color = Color.green;
        }
        // �v���C���[���{�^������������Ԃł�������.
        if (_player._isButtonState)
        {
            // ���G��Ă���{�^���̖��O���擾����.
            _name = _player._buttonName;
        }
        // ��������ԂłȂ����.
        else
        {
            // ���O�ɂ͉�������Ȃ�
            _name = "";
        }

    }
    void FixedUpdate()
    {
        
    }
}
