using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    //[SerializeField] private TriggerEvent onTriggerStay = new TriggerEvent();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
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
            // �v���C���[��Empty�̃R���C�_�[�ɓ������Ƃ�
            Debug.Log("�͈͓�");
            // Inspector�^�u��onTriggerStay�Ŏw�肳�ꂽ���������s����
            //onTriggerStay.Invoke(other);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            // �v���C���[��Empty�̃R���C�_�[����o���Ƃ�
            Debug.Log("�͈͊O");
        }
    }
}
