using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimickButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // �{�^�����R���C�_�[�ɓ������Ƃ�.
            Debug.Log("�G��Ă���");
            //_isPlayerCollider = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            // �{�^�����R���C�_�[����o���Ƃ�.
            Debug.Log("�͂Ȃ���");
            //_isPlayerCollider = false;
        }
    }
}
