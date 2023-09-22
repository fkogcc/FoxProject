using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimick1_2_4_Manager : MonoBehaviour
{

    // �{�^������.
    GameObject _botton;
    // ��]�p.
    [SerializeField] GameObject[] _rota;
    // ����p.
    [SerializeField] GameObject[] _coll;
    // ��]����I�u�W�F�N�g�̍ő吔.
    public int _objRotaMaxNum;
    // ��������Ƃ������ǂ���.
    private bool _isClear = false;

    void Start()
    {
        // �{�^���p.
        _botton = GameObject.Find("GameManager");
    }

    void Update()
    {
        for(int i = 0; i < _objRotaMaxNum; i++)
        {
            // �I�u�W�F�N�g�ɂ������Ă�����.
            if (_coll[i].GetComponent<MyCollsion3D>().IsGetHit())
            {
                // �{�^������������.
                if (_botton.GetComponent<Botton>().GetButtonB())
                {
                    // ��]������.
                    _rota[i].GetComponent<TurnGraph>().Rota();
                }
            }
        }

        // ���ׂĂ̓䂪�Ƃ�����.
        if (_rota[0].GetComponent<TurnGraph>().IsGetAns() &&
            _rota[1].GetComponent<TurnGraph>().IsGetAns() &&
            _rota[2].GetComponent<TurnGraph>().IsGetAns() &&
            _rota[3].GetComponent<TurnGraph>().IsGetAns() &&
            _rota[4].GetComponent<TurnGraph>().IsGetAns() &&
            _rota[5].GetComponent<TurnGraph>().IsGetAns() &&
            _rota[6].GetComponent<TurnGraph>().IsGetAns() &&
            _rota[7].GetComponent<TurnGraph>().IsGetAns() &&
            _rota[8].GetComponent<TurnGraph>().IsGetAns() &&
            _rota[9].GetComponent<TurnGraph>().IsGetAns())
        {
            // �����ŃV�[����؂�ւ�.
        }

    }
}
