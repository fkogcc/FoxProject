using System.Collections;
using System.Collections.Generic;
using UnityEngine;


GameObject bottonObj;
Botton botton;
public class TurnGraph : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        bottonObj = GameObject.Find("Botton"); //Unity�������I�u�W�F�N�g�̖��O����擾���ĕϐ��Ɋi�[����
        botton = bottonObj.GetComponent<Botton>(); //unitychan�̒��ɂ���UnityChanScript���擾���ĕϐ��Ɋi�[����
    }

    // Update is called once per frame
    void Update()
    {

    }
}
