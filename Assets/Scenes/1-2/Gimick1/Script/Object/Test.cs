using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

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
        public Quaternion rota;
    }

    private CinemachineVirtualCamera vcamera;

    // 追従対象リスト
    [SerializeField] private TargetInfo[] _targetList;

    int _count = 0;
    // Start is called before the first frame update
    void Start()
    {
        vcamera = this.GetComponent<CinemachineVirtualCamera>();
        var info = _targetList[_count];
        vcamera.Follow = info.follow;
        vcamera.LookAt = info.lookAt;
        vcamera.transform.rotation = info.rota;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 2"))
        {
            _count++;
        }
        if(_count >= 2)
        {
            _count = 0;
        }

        var info = _targetList[_count];
        vcamera.Follow = info.follow;
        vcamera.LookAt = info.lookAt;
        vcamera.GetCinemachineComponent(CinemachineCore.Stage.Aim).GetComponent<CinemachinePOV>().m_HorizontalAxis.Value = 0.2f;
        //this.transform.rotation = info.rota * this.transform.rotation;
        //vcamera.transform.rotation = info.rota;
        Debug.Log(this.transform.rotation);
    }
}
