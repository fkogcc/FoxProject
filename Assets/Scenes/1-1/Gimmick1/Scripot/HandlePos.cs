using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlePos : MonoBehaviour
{
    // �v���C���[
    GameObject _player;
    // �n���h���̍������݌�
    GameObject _handleWall;
    // �n���h���̉�]�t���[���𑪂�
    private int _rotaFrameHandle = 0;
    // Start is called before the first frame update
    void Start()
    {
        // �v���C���[
        _player     = GameObject.Find("3DPlayer");
        // �n���h���̍������݌�
        _handleWall = GameObject.Find("HandleWall0");

    }
    // �n���h���̈ʒu���v���C���[�̈ʒu�ɂ��܂�

    // �n���h�����v���C���[�̈ʒu�Ɉړ�
    public void HandlePosIsPlayer()
    {
        Vector3 pos;
        pos.x = _player.transform.position.x;
        pos.y = _player.transform.position.y + 3.3f;
        pos.z = _player.transform.position.z;
        this.transform.position = pos;
    }

    // �n���h�����������݈ʒu�Ɉړ�
    public void HandlePosIsHandleWall()
    {
        Vector3 pos;
        pos.x = _handleWall.transform.position.x;
        pos.y = _handleWall.transform.position.y;
        pos.z = _handleWall.transform.position.z - 0.4f;
        this.transform.position = pos;
    }

    // �n���h���̉�]
    public void Rota(float speed)
    {
        this.transform.Rotate(0, 0, speed);
        _rotaFrameHandle++;
    }

    public bool IsGetRotaTimeOver(int frame)
    {
        if(_rotaFrameHandle > frame)
        {
            return true;
        }

        return false;
    }
}
