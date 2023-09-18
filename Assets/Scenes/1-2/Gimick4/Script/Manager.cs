using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    GameObject _botton;
    GameObject _rota;
    GameObject _coll;
    // Start is called before the first frame update
    void Start()
    {

        _botton = GameObject.Find("GameManager");
        _rota   = GameObject.Find("cordRota");
        _coll   = GameObject.Find("cordRota");
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
                _coll.GetComponent<MyCollsion3D>().SetHit(false);
            }
        }
        // �{�^���������Ă��Ȃ�
        _coll.GetComponent<MyCollsion3D>().SetHit(false);
    }
}
