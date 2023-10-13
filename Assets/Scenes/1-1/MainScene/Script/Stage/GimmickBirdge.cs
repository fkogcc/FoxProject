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
    /// <param name="isOperationGimmick">ギミックを動かすのかどうか</param>
    public void UpdateBirdgeAisle(bool isOperationGimmick)
    {
        // 橋が架かると以降処理しない.
        if (_birdgeLeft.transform.localEulerAngles == new Vector3(0.0f, 0.0f, 0.0f) ||
           _birdgeRight.transform.localEulerAngles == new Vector3(0.0f, 0.0f, 0.0f))
            return;

        Debug.Log(isOperationGimmick);

        if (!isOperationGimmick) return;
        // 橋の回転.
        //RotateBirdgeAisleLeft(solveGimmick);
        //RotateBirdgeAisleRight(solveGimmick);

        RotateBirdgeAisle(_birdgeLeft, isOperationGimmick, new Vector3(0.0f, 0.0f, -1.0f));
        RotateBirdgeAisle(_birdgeRight, isOperationGimmick, new Vector3(0.0f, 0.0f, 1.0f));
    }

    // 一度回転し終わると処理を通さない.
    /// <summary>
    /// 橋のわたる部分の回転.
    /// </summary>
    /// <param name="birdge">回転させる橋のオブジェクト</param>
    /// <param name="isOperationGimmick">動作しているかどうか</param>
    /// <param name="rotate"></param>
    private void RotateBirdgeAisle(GameObject birdge, bool isOperationGimmick, Vector3 rotate)
    {
        birdge.transform.Rotate(rotate);

        if(birdge.transform.localEulerAngles == new Vector3(0.0f, 0.0f, 0.0f))
        {
            isOperationGimmick = false;
        }
    }
}
