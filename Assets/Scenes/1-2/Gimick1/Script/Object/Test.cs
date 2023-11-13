using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

// HACK カメラの管理のスクリプトいろいろなおす
// オブジェクトの生成スクリプト
public class Test : MonoBehaviour
{
    //// Hack 毎回新しいのを作る
    //[SerializeField] private GameObject PlayerHand = default;
    //private GameObject _handObject;


    // 追従対象情報
    [Serializable]
    public struct TargetInfo
    {
        // 追従対象
        public Transform follow;
        // 照準を合わせる対象
        public Transform lookAt;
        // カメラの角度
        public float rota;
        // Test
        public Transform hand;
    }

    private CinemachineVirtualCamera _vCamera;
    //private CinemachinePOV _cameraPov;

    // 追従対象リスト
    [SerializeField] private TargetInfo[] _targetList;

    private int _count = 0;
    private string _cameraName;
    // Start is called before the first frame update
    void Start()
    {
        _vCamera = this.GetComponent<CinemachineVirtualCamera>();
        //_cameraPov = this.GetComponent<CinemachinePOV>();
        var info = _targetList[_count];
        _vCamera.Follow = info.follow;
        _vCamera.LookAt = info.lookAt;

        _cameraName = null;
        //_vCamera.transform.rotation = info.rota;

        //_handObject = Instantiate(PlayerHand,
        //    this.transform.position,
        //    Quaternion.identity) as GameObject;
    }

    public void CameraUpdate()
    {
        for (int count = 0; count < _targetList.Length; count++)
        {
            if (_targetList[count].follow.name == _cameraName)
            {
                var info = _targetList[count];
                _vCamera.Follow = info.follow;
                _vCamera.LookAt = info.lookAt;
                _vCamera.GetCinemachineComponent(CinemachineCore.Stage.Aim).GetComponent<CinemachinePOV>().m_HorizontalAxis.Value = info.rota;
            }
        }
    }

    public void SetCameraName(string name)
    {
        _cameraName = name;
    }
}
