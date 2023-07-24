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
    // ハンドルの位置をプレイヤーの位置にします
    public void HandlePosIsPlayer()
    {
        this.transform.position = _player.transform.position;
    }
    public void HandlePosIsHandleWall()
    {
        this.transform.position = _handleWall.transform.position;
        // 角度変更
        Quaternion rot = transform.rotation;
        rot.y = 180.0f;
        this.transform.rotation = rot;
        // 位置修正
        Vector3 pos = new Vector3(_handleWall.transform.position.x, _handleWall.transform.position.y, _handleWall.transform.position.z - 0.35f);
        this.transform.position = pos;
    }
}
