// 橋の処理.
// HACK:橋の回転処理をもっとスマートにできそう.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickBirdge : MonoBehaviour
{
    public static GimmickBirdge _instance;

    // 橋の通路.
    // 左.
    [SerializeField] private GameObject _birdgeLeft;
    // 右.
    [SerializeField] private GameObject _birdgeRight;

    // カメラ
    private Camera _camera;

    private void Awake()
    {
        if( _instance == null )
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _camera = GameObject.Find("Camera").GetComponent<Camera>();
    }

    private void CameraWork()
    {

    }

    /// <summary>
    /// 橋がかかる処理.
    /// </summary>
    /// <param name="solveGimmick">ギミックを解いたかどうか</param>
    public void UpdateBirdgeAisle(bool solveGimmick)
    {
        // 橋が架かると以降処理しない.
        if (_birdgeLeft.transform.localEulerAngles == new Vector3(0.0f, 0.0f, 0.0f) ||
           _birdgeRight.transform.localEulerAngles == new Vector3(0.0f, 0.0f, 0.0f))
            return;

        if (!solveGimmick) return;
        // 橋の回転.
        RotateBirdgeAisleLeft(solveGimmick);
        RotateBirdgeAisleRight(solveGimmick);
    }

    // 橋わたる部分のの回転.
    // 一度回転を終えると処理を行わない.
    // 左.
    private void RotateBirdgeAisleLeft(bool solveGimmick)
    {
        _birdgeLeft.transform.Rotate(0,0,-1);

        if(_birdgeLeft.transform.localEulerAngles  == new Vector3(0.0f,0.0f,0.0f))
        {
            solveGimmick = false;
        }
    }

    // 右.
    private void RotateBirdgeAisleRight(bool solveGimmick)
    {
        _birdgeRight.transform.Rotate(0, 0, 1);

        if (_birdgeRight.transform.localEulerAngles == new Vector3(0.0f, 0.0f, 0.0f))
        {
            solveGimmick = false;
        }
    }
}
