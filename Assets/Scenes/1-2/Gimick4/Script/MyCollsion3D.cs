using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCollsion3D : MonoBehaviour
{
    // �������肽���I�u�W�F�N�g�̖��O
    public string _objectName;
    // �������Ă��邩�ǂ���
    private bool _isColliding;


    private void Update()
    {
        _isColliding = false;
    }

    private void OnTriggerStay(Collider other)
    {
        // �w�肵���I�u�W�F�N�g�ɓ���������
        if (other.name == _objectName)
        {
            _isColliding = true;    
        }
    }

    // ���菈�����ǂ����邩�����߂�
    public void SetHit(bool isHit)
    {
        _isColliding = isHit;
    }

    // �������Ă��邩�ǂ���
    public bool IsGetHit()
    {
        return _isColliding;
    }


}
