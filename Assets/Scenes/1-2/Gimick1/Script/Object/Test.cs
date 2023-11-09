using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

// HACK カメラの管理のスクリプトいろいろなおす
public class Test : MonoBehaviour
{

    // 追従対象情報
    [Serializable]
    public struct TargetInfo
    {
        // 追従対象
        public Transform follow;
        // 照準を合わせる対象
        public Transform lookAt;
        // おためし
        public float rota;
    }

    //private enum cameraNum
    //{
    //    GimickMonitor  = 0, 
    //    Left = 1,
    //    Right = 2,

    //}
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
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown("joystick button 2"))
        //{
        //    _count++;
        //}
        //if(_count >= 3)
        //{
        //    _count = 0;
        //}
        // 

        for(int count = 0; count < _targetList.Length;count++)
        {
            //Debug.Log(_targetList[count].follow.name + "     " + _cameraName);
            //Debug.Log("いま入っているのは" + _cameraName);
            if (_targetList[count].follow.name == _cameraName)
            {
                var info = _targetList[count];
                _vCamera.Follow = info.follow;
                _vCamera.LookAt = info.lookAt;
                _vCamera.GetCinemachineComponent(CinemachineCore.Stage.Aim).GetComponent<CinemachinePOV>().m_HorizontalAxis.Value = info.rota;
            }
        }

        //this.transform.rotation = info.rota * this.transform.rotation;
        //vcamera.transform.rotation = info.rota;
        //Debug.Log(this.transform.rotation);
    }

    public void SetCameraName(string name)
    {
        _cameraName = name;
        //Debug.Log("いま入っているのは" + _cameraName);
    }
}
