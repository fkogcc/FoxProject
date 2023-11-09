using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimick1_2_4_Manager : MonoBehaviour
{
    // クリア後のフレームカウントの最大数.
    static readonly int ClearCountMaxFrame = 60 * 3;

    // ボタン操作.
    private GameObject _botton;

    // ワープするための変数.
    private  Gimick1_2_4_PlayerWarp _warp;

    // 回転用.
    [SerializeField] GameObject[] _rota;

    // 回転用のクラスのメモリを確保.
    private TurnGraph[] _rotaGraph = new TurnGraph[10];

    // 判定用.
    [SerializeField] GameObject[] _coll;

    // クリア後のライトを調整.
    private GameObject _light;

    // 回転するオブジェクトの最大数.
    public int _objRotaMaxNum;

    // 謎解きがとけたかどうか.
    private bool _isClear = false;

    // 回路が正しい場合のカウント.
    private int _ansFrameCount = 0;

    // クリア後のカウント.
    private int _clearFrameCount = 0;

    // クリア後カメラの位置を移動させる.
    private CinemachineVirtualCamera _camera;

    // クリア後カメラの位置をターゲット位置.
    private GameObject _cameraData;
    private Transform _cameraPos;
    private Transform _cameraTargetPos;

    // クリア後のカメラ角度.
    public float _clearCameraRotaY;
    public float _clearCameraRotaX;

    void Start()
    {
        // ボタン用.
        _botton = GameObject.Find("GameManager");
        
        // 回転する回路のクラス.
        for (int i = 0; i < _objRotaMaxNum; i++)
        {
            _rotaGraph[i] = _rota[i].GetComponent<TurnGraph>();
        }

        // ワープ用クラスを取得.
        _warp = GameObject.Find("Warp").GetComponent<Gimick1_2_4_PlayerWarp>();

        // ライト関連.
        {
            // ライト用クラスを取得.
            _light = GameObject.Find("Lights0");
            _light.SetActive(false);
        }

        // カメラ関連.
        {
            // カメラオブジェクトを取得.
            _camera          = GameObject.Find("3DPlayerCamer").GetComponent<CinemachineVirtualCamera>();

            // カメラ用の位置データを取得.
            _cameraData      = GameObject.Find("AnsTargetPos");
            _cameraTargetPos = _cameraData.transform;
            _cameraData      = GameObject.Find("AnsPos");
            _cameraPos       = _cameraData.transform;
        }
    }

    void Update()
    {
        Debug.Log("動いています1_2_4_0");
        for(int i = 0; i < _objRotaMaxNum; i++)
        {
            // オブジェクトにあたっていたら.
            if (_coll[i].GetComponent<MyCollsion3D>().IsGetHit())
            {
                // ボタンをおしたら.
                if (_botton.GetComponent<Botton>().GetButtonB())
                {
                    // 回転したら.
                    _rota[i].GetComponent<TurnGraph>().Rota();
                }
            }
        }
           
        // 回路が正しく接続されている数を確認.
        for (int i = 0; i < _objRotaMaxNum; i++)
        {
            if(!_rotaGraph[i].IsGetAns())
            {
                _ansFrameCount = 0;
                break;
            }
            else
            {
                // 最大値まで到達するとカウントを行わない.
               if(_ansFrameCount < _objRotaMaxNum)
               {
                    _ansFrameCount++; 
               }
            }
        }
    }

    private void FixedUpdate()
    {
        // 全ての回路が正しく接続されている場合.
        if (_ansFrameCount == _objRotaMaxNum)
        {
            // クリア後少し間を開ける為のカウント.
            _clearFrameCount++;

            // 光った演出用のライトを表示させる.
            _light.SetActive(true);
          
            //// カメラのターゲット位置と角度を変更.
            _camera.Follow = _cameraPos;
            _camera.GetCinemachineComponent(CinemachineCore.Stage.Aim).GetComponent<CinemachinePOV>().m_VerticalAxis.Value   = _clearCameraRotaY;
            _camera.GetCinemachineComponent(CinemachineCore.Stage.Aim).GetComponent<CinemachinePOV>().m_HorizontalAxis.Value = _clearCameraRotaX;

            // 一定数カウントが値を御超えると.
            if (_clearFrameCount > ClearCountMaxFrame)
            {
                // クリアした場合のフラグを立てる.
                _isClear = true;

                // 次のギミックの場所にワープする.
                _warp.GetComponent<Gimick1_2_4_PlayerWarp>().NextStagePos();

                // 光った演出用のライトを非表示にする.
                _light.SetActive(false);

                //// カメラのターゲット位置と角度を変更.
                _camera.Follow = GameObject.Find("3DPlayer").transform;
                _camera.GetCinemachineComponent(CinemachineCore.Stage.Aim).GetComponent<CinemachinePOV>().m_VerticalAxis.Value 　= 0.0f;
                _camera.GetCinemachineComponent(CinemachineCore.Stage.Aim).GetComponent<CinemachinePOV>().m_HorizontalAxis.Value = 0.0f;
            }
        }
    }
    // クリアしたかどうか.
    public bool GetResult()
    {
        return _isClear;
    }
}
