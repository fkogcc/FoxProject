using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUpdate : MonoBehaviour
{
    //Vector3 playerPos = GameObject.Find("fox").transform.position;

    // プレイヤーのゲームオブジェクト
    private GameObject _targetPlayer;
    // カメラのポジション限界
    private Vector3 _camearMaxPosition;
    private float _cameraPosX;
    private float _cameraPosY;
    private float _cameraPosZ;

    // Start is called before the first frame update
    void Start()
    {
        _targetPlayer = GameObject.Find("Foxidle");

        _cameraPosX = _targetPlayer.transform.position.x;
        _cameraPosY = _targetPlayer.transform.position.y;
        _cameraPosZ = -20.0f;
        _camearMaxPosition = new Vector3(_cameraPosX + 7, (_cameraPosY / 5.0f) + 6.0f, _cameraPosZ);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // カメラの追従

        float playerPosX = _targetPlayer.transform.position.x;
        float playerPosY = _targetPlayer.transform.position.y;
        if (transform.position.x <= -10)
        {
            transform.position = new Vector3(-10, (playerPosY / 5.0f) + 6.0f, -20.0f);
        }

        if(!PlayerMove._instance._isDirection)
        {
            _camearMaxPosition = new Vector3(_cameraPosX + 7, (_cameraPosY / 5.0f) + 6.0f, _cameraPosZ);
        }
        else
        {
            _camearMaxPosition = new Vector3(_cameraPosX - 7, (_cameraPosY / 5.0f) + 6.0f, _cameraPosZ);
        }

        if(transform.position.x > _camearMaxPosition.x)
        {
            
        }
        
    }
}
