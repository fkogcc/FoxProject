using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asibaMove : MonoBehaviour
{
    // �b���𐔂���J�E���g.
    private int _count;
    //Transform���擾.
    private Transform _myTransform;
    // ���W���擾.
    private Vector3 _pos;
    // 5�b�̎���.
    private int _time;
    // �M�~�b�N�̈ړ���
    private float _moveZ;
    void Start()
    {
        _count = 0;
        _myTransform = this.transform;
        _pos = _myTransform.position;
        _time = 300;
        _moveZ = 0.08f;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        _count++;

        //5�b�o������.
        if (_count < _time)
        {
            // z���W��0.08���Z.
            _pos.z -= _moveZ;
            // ���W��ݒ�.
            _myTransform.position = _pos;  
        }
        //10�b�o������.
        else if (_count < _time * 2)
        {
            // z���W��0.08���Z.
            _pos.z += _moveZ;
            // ���W��ݒ�.
            _myTransform.position = _pos;  
        }
        //����ȏ�ɂȂ�����.
        else
        {
            //�J�E���g������������.
            _count = 0;
        }
    }
}
