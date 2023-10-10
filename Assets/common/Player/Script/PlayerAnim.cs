// �v���C���[�A�j���[�V����.

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

    //-------------------------------------------
    // �A�j���[�V�����Đ�.
    // true: �Đ�.
    // false:�Đ����Ȃ�.
    //-------------------------------------------

    // �ړ�.
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

    // �W�����v�A�j���[�V����.
    public bool Jump()
    {
        if(!IsGroundedCheck._instance._isGround)
        {
            return true;
        }
        return false;
    }

    // �Q�[���I�[�o�[�A�j���[�V����.
    public bool GameOver()
    {
        //if (Player2DMove._instance._hp <= 0)
        //{
        //    return true;
        //}
        return false;
    }

}
