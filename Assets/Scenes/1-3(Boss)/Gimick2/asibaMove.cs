using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asibaMove : MonoBehaviour
{
    //�b���𐔂���J�E���g
    int count = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
       
        //Transform���擾
        Transform myTransform = this.transform;

        // ���W���擾
        Vector3 pos = myTransform.position;

        count++;

        //5�b�o������
        if(count < 250)
        {
            // z���W��0.1���Z
            pos.z -= 0.04f;    
            // ���W��ݒ�
            myTransform.position = pos;  
        }
        //10�b�o������
        else if (count < 500)
        {
            // z���W��0.01���Z
            pos.z += 0.04f;
            // ���W��ݒ�
            myTransform.position = pos;  
        }
        //����ȏ�ɂȂ�����
        else 
        {
            //�J�E���g������������
            count = 0;
        }
        


    }
}
