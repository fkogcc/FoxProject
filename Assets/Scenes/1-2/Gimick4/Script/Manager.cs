using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    // �{�^������
    GameObject _botton;
    // �I�u�W�F�N�g��]����
    GameObject _rota;
    // �����蔻�菈��
    GameObject _coll;
    // Start is called before the first frame update
    void Start()
    {
        // �{�^������
        _botton = GameObject.Find("GameManager");
        // �I�u�W�F�N�g��]����
        _rota   = GameObject.Find("cordRota0");
        // �����蔻�菈��
        _coll = GameObject.Find("cordRota0");
    }

    void Update()
    {
        // �v���C���[���������Ă�����
        if (_coll.GetComponent<MyCollsion3D>().IsGetHit())
        {
            // �{�^������������
            if (_botton.GetComponent<Botton>().GetButtonB())
            {
                // ��]
                _rota.GetComponent<TurnGraph>().Rota();
            }
        }
    }
}
