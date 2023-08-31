using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUpdate : MonoBehaviour
{
    //Vector3 playerPos = GameObject.Find("fox").transform.position;

    GameObject _targetPlayer;

    // Start is called before the first frame update
    void Start()
    {
        _targetPlayer = GameObject.Find("Foxidle");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float playerPosX = _targetPlayer.transform.position.x;
        float playerPosY = _targetPlayer.transform.position.y;
        transform.position = new Vector3(playerPosX + 7, (playerPosY/5.0f) + 6.0f, -20.0f);
    }
}
