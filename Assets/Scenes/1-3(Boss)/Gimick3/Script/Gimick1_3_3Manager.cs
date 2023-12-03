using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gimick1_3_3Manager : MonoBehaviour
{
    // オブジェクトの取得
    private CameraChange _cameraChange;
    private StageCamera _stageCamera;
    private ContainerDirector _containerDirector;
    private Reset_Button _reset;
    //バリケードを取得.
    private GameObject _barricade;
    // テスト用
    private bool _isDestory = false;

    // Start is called before the first frame update
    void Start()
    {
        _barricade = GameObject.Find("Barricade");
        _cameraChange = GetComponent<CameraChange>();
        _stageCamera = GameObject.Find("MinmapCamera").GetComponent<StageCamera>();
        _containerDirector = GameObject.Find("Container Director").GetComponent<ContainerDirector>();
        _reset = GameObject.Find("Reset_Button").GetComponent<Reset_Button>();
    }

    // Update is called once per frame
    void Update()
    {
        _cameraChange.ChengeCameraUpdate();
        _stageCamera.CameraUpdate();
        _reset.ResetPush(_containerDirector.IsStage1Clear());
        if (_containerDirector.IsStage1Clear() && !_isDestory)
        {
            _barricade.gameObject.transform.position += new Vector3(0,-0.05f,0);
            _cameraChange.ChangeCameraAnim();
            if (_barricade.transform.position.y < -7)
            {
                Destroy(_barricade);
                _cameraChange.CameraDestory();
                _isDestory =true;
            }
        }
    }
}
