using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxIn : MonoBehaviour
{
    // �f�B���N�^�[
    BoxDirector _director;
    // �M�~�b�N�̐F
    public string _color;

    void Start()
    {
        _director = GameObject.Find("GimmickDirector").GetComponent<BoxDirector>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("�M�~�b�N��:color, " + _color);
        _director.SetGimmickIn(_color, this.transform.position);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("�M�~�b�N�O");
        _director.IsSetFlag();
    }
}
