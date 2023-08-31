using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rota : MonoBehaviour
{
    // ��]���Ԃ��J�E���g���܂�
    private int _count;
    // �C�ӂ̎��Ԃ����݂ő�����܂�
    public int _countSecondsMax;
    // 1�b60�t���[���Ƃ��Ē�������
    private int _countMax;
    // ��]���I��������ǂ���
    private bool _isRotaEnd;
    // Start is called before the first frame update
    void Start()
    {
        _count = 0;
        _countMax = 60 * _countSecondsMax;
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
