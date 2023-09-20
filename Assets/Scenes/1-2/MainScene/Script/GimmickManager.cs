using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickManager : MonoBehaviour
{
    //[SerializeField] private GameObject[] _gameObject;
    [SerializeField] private bool[] _solveGimmick;
    //public WallGimmick _wallGimmick;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        WallGimmick._instance.UpdateWall(_solveGimmick[0]);
        WallGimmick._instance.DebugReset(_solveGimmick[0]);
        //_wallGimmick.UpdateWall(_solveGimmick[0]);
    }
}
