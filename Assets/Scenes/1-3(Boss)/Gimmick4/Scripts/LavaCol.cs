using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LavaCol : MonoBehaviour
{
    Vector3 kjumpForce = new Vector3(0, 200.0f, 0);
    Rigidbody _rb;
    GameObject _player;

    // キャラクターコントローラー.
    private CharacterController _playerController;
    // ジャンプ力.
    [SerializeField] private float _jumpPower = 8.0f;

    private void Start()
    {
        _player = GameObject.Find("3DPlayer");
        _playerController = _player.GetComponent<CharacterController>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("当たった");
            _playerController.Move(kjumpForce * Time.deltaTime);
        }
    }
}
