using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rota : MonoBehaviour
{
    private int _count;
    public int _countMax = 60 * 10;
    private bool _isRotaEnd;
    // Start is called before the first frame update
    void Start()
    {
        _count = 0;
        _isRotaEnd = false;
    }
    private void FixedUpdate()
    {
        // ��]�A�J�E���g
        this.transform.Rotate(0.0f, 0.0f, 1.0f);
        _count++;
        
    }
    // ��]���I��������ǂ���
    public bool RotaEnd()
    {
        // ��]�p�t���[���J�E���g���m�F
        if (_count > _countMax)
        {
            _isRotaEnd = true;
        }
        return _isRotaEnd;
    }
    // �J�E���g�����Z�b�g���܂�
    public void RotaReset()
    {
        _count = 0;
        _isRotaEnd = false;
    }
}
