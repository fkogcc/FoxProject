using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class testCol : MonoBehaviour
{
    public static testCol _instance;// �C���X�^���X
    // �V�[���J�ڂ��s�������ǂ���
    public bool _isScene;
    // �V�[���J�ڂ̐^�U
    public bool _isGateGimmick1;
    public bool _isGateGimmick2;

    private void Awake()
    {
        // �V���O���g��
        if(_instance == null)
        {
            // ���g���C���X�^���X�Ƃ���
            _instance = this;
        }
        else
        {
            // �C���X�^���X���������݂��Ȃ��悤�ɁA���ɑ��݂��Ă����玩�g����������
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        // ������
        _isScene = false;
        _isGateGimmick1 = false;
        _isGateGimmick2 = false;
    }

    // Update is called once per frame
    void Update()
    {
    }


    private void OnTriggerEnter(Collider other)
    {
        // ���̓����蔻��ɓ�������ture
        if(other.tag == "Gimmick1")
        {
            _isGateGimmick1 = true;
        }
        else if(other.tag == "Gimmick2")
        {
            _isGateGimmick2 = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // ���̓����蔻����o����false
        if(other.tag =="Gimmick1")
        {
            _isGateGimmick1 = false;
        }
        else if( other.tag =="Gimmick2")
        {
            _isGateGimmick2 = false;
        }
    }
}
