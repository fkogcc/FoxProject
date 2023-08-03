using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRoll : MonoBehaviour
{
    // テキスト
    GameObject _teamMember;
    GameObject _programer;
    GameObject _cg;
    GameObject _director;
    // 位置を変える
    private float _posY;
    // テキストのスピード
    public float _rollSpeed = 0.001f;
    // Start is called before the first frame update
    void Start()
    {
        _teamMember = GameObject.Find("TeamMember");
        _programer = GameObject.Find("Programer");
        _cg = GameObject.Find("CG");
        _director = GameObject.Find("Director");

        _posY = 0.0f;
    }

    void FixedUpdate()
    {
        _teamMember.gameObject.transform.position = new Vector3(
            _teamMember.gameObject.transform.position.x,
            _teamMember.gameObject.transform.position.y + _posY,
            _teamMember.gameObject.transform.position.z);

        _programer.gameObject.transform.position = new Vector3(
            _programer.gameObject.transform.position.x,
            _programer.gameObject.transform.position.y + _posY,
            _programer.gameObject.transform.position.z);

        _cg.gameObject.transform.position = new Vector3(
            _cg.gameObject.transform.position.x,
            _cg.gameObject.transform.position.y + _posY,
            _cg.gameObject.transform.position.z);

        _director.gameObject.transform.position = new Vector3(
            _director.gameObject.transform.position.x,
            _director.gameObject.transform.position.y + _posY,
            _director.gameObject.transform.position.z);

        _posY += _rollSpeed;
    }
}
