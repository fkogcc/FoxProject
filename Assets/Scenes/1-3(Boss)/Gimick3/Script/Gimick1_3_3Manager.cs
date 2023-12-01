using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimick1_3_3Manager : MonoBehaviour
{
    // オブジェクトの取得
    private CameraChange _cameraChange;
    private StageCamera _stageCamera;
    private ContainerDirector _containerDirector;
    //バリケードを取得.
    GameObject _barricade;
    // Start is called before the first frame update
    void Start()
    {
        _barricade = GameObject.Find("Barricade");
        _cameraChange = GetComponent<CameraChange>();
        _stageCamera = GameObject.Find("MinmapCamera").GetComponent<StageCamera>();
        _containerDirector = GameObject.Find("Container Director").GetComponent<ContainerDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        _cameraChange.ChengeCameraUpdate();
        _stageCamera.CameraUpdate();
        if (_containerDirector.IsStage1Clear())
        {
            _barricade.gameObject.transform.position += new Vector3(0,-0.1f,0); 
            //Destroy(_Barricade);
        }
    }
}
