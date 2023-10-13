using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    private GameObject _rope;
    private GameObject _wall;
    private GameObject _lava;
    private float _wallHeight;
    private float _ropeLength;
    private bool _isFlag;
    // Start is called before the first frame update
    void Start()
    {
        _rope = GameObject.Find("Rope");
        _wall = GameObject.Find("MoveWall");
        _lava = GameObject.Find("Movelava");
        _wallHeight = _wall.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        _ropeLength = _rope.GetComponent<PullRope>().GetNowLength() - 3;
        Debug.Log(_ropeLength);
        if (_ropeLength > 0)
        {
            _wall.transform.position = new Vector3(0, _wallHeight - _ropeLength, -14.66f);
            if (_ropeLength > 3.6f)
            {
                _isFlag = true;
            }
        }
        if (_isFlag)
        {
            if (_lava.transform.position.x < 8)
            {
                _lava.transform.Translate(new Vector3(0, 0, 0.01f));
            }
        }
    }
}
