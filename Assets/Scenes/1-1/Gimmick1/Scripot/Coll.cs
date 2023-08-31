using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coll : MonoBehaviour
{
    // �n���h���^�O�̃I�u�W�F�N�g�ɓ������Ă��邩�ǂ���
    private bool _isHandleHit;
    private bool _isHandleWallHit;


    public string _tagHandleName;
    public string _tagHandleWallName;

    private bool _isHandleHit2;
    private bool _isHandleWallHit2;

    public string _tagHandleName2;
    public string _tagHandleWallName2;
    private void Start()
    {
        _isHandleHit = false;
        _isHandleWallHit = false;

        _isHandleHit2 = false;
        _isHandleWallHit2 = false;
    }

    private void Update()
    {
    
    }

    void OnTriggerEnter(Collider collision)
    {
        // �v���C���[�ɓ�����
        if (collision.gameObject.name == _tagHandleName)
        {           
            _isHandleHit = true;
        }
        // �v���C���[�ɓ�����
        if (collision.gameObject.name == _tagHandleWallName)
        {
            _isHandleWallHit = true;
        }

        // �v���C���[�ɓ�����
        if (collision.gameObject.name == _tagHandleName2)
        {
            _isHandleHit2 = true;
        }
        // �v���C���[�ɓ�����
        if (collision.gameObject.name == _tagHandleWallName2)
        {
            _isHandleWallHit2 = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        // �v���C���[�ɓ������Ă��Ȃ��ꍇ
        if (collision.gameObject.name == _tagHandleName)
        {
            _isHandleHit = false;
        }
        // �v���C���[�ɓ������Ă��Ȃ��ꍇ
        if (collision.gameObject.name == _tagHandleWallName)
        {
            _isHandleWallHit = false;
        }

        // �v���C���[�ɓ������Ă��Ȃ��ꍇ
        if (collision.gameObject.name == _tagHandleName2)
        {
            _isHandleHit2 = false;
        }
        // �v���C���[�ɓ������Ă��Ȃ��ꍇ
        if (collision.gameObject.name == _tagHandleWallName2)
        {
            _isHandleWallHit2 = false;
        }
    }

    // �n���h���ɓ������Ă��邩�ǂ���
    public bool HitHandle()
    {
        return _isHandleHit;
    }
    // �n���h���������ޕǂɓ������Ă��邩�ǂ���
    public bool HitHandleWall()
    {
        return _isHandleWallHit;
    }

    // �n���h���ɓ������Ă��邩�ǂ���
    public bool HitHandle2()
    {
        return _isHandleHit2;
    }
    // �n���h���������ޕǂɓ������Ă��邩�ǂ���
    public bool HitHandleWall2()
    {
        return _isHandleWallHit2;
    }
}
