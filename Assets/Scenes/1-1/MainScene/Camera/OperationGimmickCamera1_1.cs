// ギミックが作動中時のカメラの挙動

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationGimmickCamera1_1 : MonoBehaviour
{
    // ギミックの作動中のカメラの座標.
    [SerializeField] private GameObject[] _CameraPosition;

    // ギミックの真偽を統括しているオブジェクト.
    private GimmickManager1_1 _GimmickManger;

    // Start is called before the first frame update
    void Start()
    {
        _GimmickManger = GameObject.Find("GimmickManager").GetComponent<GimmickManager1_1>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
