using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteasiba : MonoBehaviour
{

    //���ꂪ�v���C���[�ɐڐG�����Ƃ�.
    private void OnTriggerEnter(Collider other)
    {
        //������폜����.
        Destroy(this.gameObject);   
    }
}
