using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botton : MonoBehaviour
{
    // �����Ă邩�ǂ�����n��
    // �g���K�[����p
    public bool isTrigger { get; set; }
 
    // ���݃{�^���������Ă��邩�ǂ���
    private bool isTriggerActive = false;
    // Start is called before the first frame update
    void Start()
    {
        isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.JoystickButton1) && !isTriggerActive)
        {
            isTriggerActive = true;
        }
        else
        {
            isTriggerActive = false;
        }

        if (isTriggerActive)
        {
            Debug.Log("ositeru");
        }
    }
}
