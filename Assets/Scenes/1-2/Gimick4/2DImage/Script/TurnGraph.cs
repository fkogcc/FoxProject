using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurnGraph : MonoBehaviour
{
    GameObject _botton;

    // ��]����
    private bool _connected = false;

    // ��]��
    private float _rota = 0.0f;
    // ��]�ʕۑ�
    private float _tempRota = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        if (_connected)
        {
            if (_rota >= _tempRota + 90.0f)
            {
                _connected = false;
                _tempRota = _rota;
            }
            else
            {
                _rota += 1.0f;
                this.transform.Rotate(0.0f, 0.0f, 1.0f);
            }
        }

        Debug.Log(_tempRota);
        Debug.Log(_rota);

    }

    public void Rota()
    {
        _connected = true;
    }
}
