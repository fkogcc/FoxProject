using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurnGraph : MonoBehaviour
{
    // ��]����.
    private bool _connected = false;
    // ��]��.
    private int _rota = 0;
    // ��]�ʕۑ�.
    private float _tempRota = 0.0f;
    // �����̊p�x.
    public int _ansRota;
    // �����������U���̏ꍇ.
    public bool _isFake;

    void Update()
    {
        // �{�^���������ꂽ��.
        if (_connected)
        {
            // 90�x��]������~�߂�.
            if (_rota >= _tempRota + 90.0f)
            {
                _connected = false;
                _tempRota = _rota;
            }
            else
            {
                // ��]������.
                _rota += 1;
                this.transform.rotation = Quaternion.Euler(90.0f, 0.0f, _rota);
            }
        }

        // 360�x��]������0�x�ɖ߂�.
        if (_tempRota >= 360.0f)
        {
            _rota = 0;
            _tempRota = 0.0f;
        }
    }

    // ��]��L���ɂ���.
    public void Rota()
    {
        _connected = true;
    }

    // ��]���ʂ�������������true.
    public bool IsGetAns()
    {
        if (_isFake) return true;

            if (_ansRota == _tempRota)
        {
            return true;
        }

        return false;
    }
}
