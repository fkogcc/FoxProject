using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MachineDestory : MonoBehaviour
{
    private MoveWall _wall;

    // Start is called before the first frame update
    void Start()
    {
        _wall = GameObject.Find("MoveWallDir").GetComponent<MoveWall>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_wall.GetResult())
        {
            // オブジェクトの削除
            Destroy(this.gameObject);
        }
    }
}
