using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlePos : MonoBehaviour
{
    GameObject _player;
    GameObject _handleWall;
    public string _name;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("fox");
        _handleWall = GameObject.Find(_name);
    }
    // �n���h���̈ʒu���v���C���[�̈ʒu�ɂ��܂�
    public void HandlePosIsPlayer()
    {
        this.transform.position = _player.transform.position;
    }
    public void HandlePosIsHandleWall()
    {
        this.transform.position = _handleWall.transform.position;
        // �p�x�ύX
        Quaternion rot = transform.rotation;
        rot.y = 180.0f;
        this.transform.rotation = rot;
        // �ʒu�C��
        Vector3 pos = new Vector3(_handleWall.transform.position.x, _handleWall.transform.position.y, _handleWall.transform.position.z - 0.35f);
        this.transform.position = pos;
    }
}
