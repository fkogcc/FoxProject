using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botton : MonoBehaviour
{
    // �����Ă邩�ǂ�����n��
    // �g���K�[����p
    private bool _isTrigger { get; set; }
    // ���݃{�^���������Ă��邩�ǂ���
    private bool _isTriggerActive = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _isTrigger = false;
    }
 
    // Update is called once per frame
    void Update()
    {
        _isTrigger = false;
        // B������
        if (Input.GetKey(KeyCode.JoystickButton1)) // B
        {
            if (!_isTriggerActive)
            {
                _isTriggerActive = true;
                _isTrigger = true;
            }
        }
        else
        {
            _isTriggerActive = false;
        }
    }
    public bool GetButtonB()
    {
        return _isTrigger;
    }
}
