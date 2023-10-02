using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxIn : MonoBehaviour
{
    // �f�B���N�^�[.
    public BoxDirector _director;
    // �M�~�b�N�̐F.
    public string Color;

    // ����������.
    void Start()
    {
        // GimmickDirector�̏����擾����.
        _director = GameObject.Find("GimmickDirector").GetComponent<BoxDirector>();
    }

    void OnTriggerEnter(Collider other)
    {
        _director.SetGimmickIn(Color, this.transform.position);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("�M�~�b�N�O");
        _director.IsSetFlag(false);
    }
}
