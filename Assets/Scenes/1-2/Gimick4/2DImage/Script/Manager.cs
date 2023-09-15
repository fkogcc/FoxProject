using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    GameObject _botton;
    GameObject _rota;
    // Start is called before the first frame update
    void Start()
    {

        _botton = GameObject.Find("GameManager");
        _rota = GameObject.Find("cordRota");
    }

    // Update is called once per frame
    void Update()
    {
        if (_botton.GetComponent<Botton>().GetButtonB())
        {
            _rota.GetComponent<TurnGraph>().Rota();
        }
    }
}
