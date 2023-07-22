using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coll : MonoBehaviour
{
   public bool _isHit;
    public bool _isItemGet;
    public bool _isHandleWallSet;
    GameObject _playerObj;
    GameObject _handleWallObj;
    public static handleWall _wall;
    private void Start()
    {
        _isHit = false;
        _isItemGet = false;
        _isHandleWallSet = false;

        // �v���C���\
        _playerObj = GameObject.Find("fox");
        _handleWallObj = GameObject.Find("handleWall1");
    }

    private void Update()
    {
        if(!_isHandleWallSet)
        {
            if(_isHit)
            {
                if(Input.GetKey("a"))
                {
                    Debug.Log("�����Ă܂�");
                    _isItemGet = true;  
                }
            }
        }
        // �n���h���̈ʒu�ƃv���C���[�̈ʒu�𓯂��ɂ���
        if(_isItemGet)
        {
            this.transform.position = _playerObj.transform.position;
        }
        else
        {
            Debug.Log("�����܂�");
        }
        if(!_wall._isHandleSet)
        {
            Debug.Log("�Z�b�g���܂�");
            this.transform.position = _handleWallObj.transform.position;
        }
    }

    void OnTriggerStay(Collider collision)
    {
        // �Ԃ���������̖��O���擾
        Debug.Log(collision.gameObject.name); 

        // �v���C���[�ɓ�����
        if (collision.tag == "Player")
        {
            _isHit = true;
        }
        else
        {
            _isHit = false;
        }
    }
    public void GetHandleFlag(bool isItemPosSet)
    {
        _isHandleWallSet = isItemPosSet;
    }

    //private void Awake()
    //{
    //    if(_coll == null)
    //    {
    //        _coll = this;
    //        DontDestroyOnLoad(this.gameObject);
    //    }
    //    else
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}
}
