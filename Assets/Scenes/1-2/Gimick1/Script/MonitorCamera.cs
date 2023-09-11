using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorCamera : MonoBehaviour
{
    // �{�^�������������̏��.
    public bool _isPushFlag;
    public GameObject _playerCameraObject;
    public GameObject _playerObject;
    public GameObject _HandObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // �{�^���̏�Ԃɂ���ĕ��򂳂���.
        if (_isPushFlag)
        {
            Debug.Log("Camera On");
            // ���j�^�[�O�̃J�������I���ɂ���
            _playerCameraObject.gameObject.SetActive(false);
            _playerObject.gameObject.SetActive(false);
            _HandObject.gameObject.SetActive(true);
        }
        else
        {
            // ���j�^�[�O�̃J�������I�t�ɂ���
            Debug.Log("Camera Off");
            _playerCameraObject.gameObject.SetActive(true);
            _playerObject.gameObject.SetActive(true);
            _HandObject.gameObject.SetActive(false);
        }
    }
    void FixedUpdate()
    {

    }
}
