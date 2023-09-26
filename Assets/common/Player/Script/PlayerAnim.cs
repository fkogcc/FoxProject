// �v���C���[�A�j���[�V����

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    public static PlayerAnim _instance;
    private void Awake()
    {
        if( _instance == null )
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // �ړ��A�j���[�V����
    public bool Run()
    {
        // ��������.
        float vertical = Input.GetAxis("Vertical");
        // ��������.
        float horizontal = Input.GetAxis("Horizontal");
        // �X�e�B�b�N���X����.
        bool isStickTilt = vertical != 0 ||
            horizontal != 0;

        
        if(isStickTilt)
        {
            return true;
        }
        return false;
    }
}
