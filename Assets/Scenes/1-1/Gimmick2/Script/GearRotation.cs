using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearRotation : MonoBehaviour
{
    // ��]�x��.
    public Vector3 _rotaDegrees;
    // ��].
    public Quaternion _rotation;
    // TODO �v���C���[���{�^�������������̃t���O�i�e�X�g�j
    public bool _pushButton;

    // �C���X�^���X�̍쐬.
    void Start()
    {
        // ������
        _rotaDegrees += new Vector3( 0.0f, 1.0f, 0.0f); 
        _rotation = Quaternion.AngleAxis(0.5f, _rotaDegrees);
        _pushButton = false;
    }

    // 60�t���[���Ɉ��̍X�V����.
    void FixedUpdate()
    {
        if (_pushButton)
        {
            // ��]�x���������đ���
            this.transform.rotation = _rotation * this.transform.rotation;
        }
    }
    
    // �X�V����.
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("���؁[����������");
            _pushButton = true;
        }
        //if(this.transform.rotation.y > 0)
        //{
        //    Debug.Log("180");
        //    _pushButton = false;
        //}
    }
}
