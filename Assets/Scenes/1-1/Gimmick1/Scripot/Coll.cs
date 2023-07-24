using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coll : MonoBehaviour
{
    // �n���h���^�O�̃I�u�W�F�N�g�ɓ������Ă��邩�ǂ���
    private bool _isHandleHit;
    private bool _isHandleWallHit;
    
    private void Start()
    {
        _isHandleHit = false;
        _isHandleWallHit = false;
    }

    private void Update()
    {
    
    }

    void OnTriggerEnter(Collider collision)
    {
        // �v���C���[�ɓ�����
        if (collision.tag == "handle")
        {           
            _isHandleHit = true;
        }
        // �v���C���[�ɓ�����
        if (collision.tag == "handleWall")
        {
            _isHandleWallHit = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        // �v���C���[�ɓ������Ă��Ȃ��ꍇ
        if (collision.tag == "handle")
        {
            _isHandleHit = false;
        }
        // �v���C���[�ɓ������Ă��Ȃ��ꍇ
        if (collision.tag == "handleWall")
        {
            _isHandleWallHit = false;
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
}
