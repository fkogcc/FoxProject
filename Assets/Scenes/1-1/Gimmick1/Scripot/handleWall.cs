using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handleWall : MonoBehaviour
{
    // �n���h�����������ݗp�t���O
    public bool _isHandleSet;
    
    // �n���h���I�u�W�F�N�g�̏�Ԃ��擾
    public Coll _coll;

    void Start()
    {
        _isHandleSet = false;
    }

    // Update is called once per frame
    public void Update()
    {
        if (_isHandleSet)
        {
            Debug.Log("�Z�b�g�ł��܂�");
            if (Input.GetKey("s"))
            {
                Debug.Log("S�����܂���");
                 _coll.GetHandleFlag(true);
                 _coll._isItemGet = false;
                 _coll._isHit = false;
                _coll._isHandleWallSet = true;
            }
        }

    }

    void OnTriggerStay(Collider collision)
    {
        if(collision.tag == "handle")
        {
            Debug.Log("handle");
            _isHandleSet = true;    
        }
    }

}
