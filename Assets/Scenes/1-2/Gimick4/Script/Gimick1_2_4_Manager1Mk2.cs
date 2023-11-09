using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimick1_2_4_Manager1Mk2 : MonoBehaviour
{
    // クリア後のフレームカウントの最大数
    static readonly int ClearCountMaxFrame = 60 * 3;

    // ボタン操作.
    private GameObject _botton;

    // ワープするための変数
    private Gimick1_2_4_PlayerWarp _warp;

    // 回転用.
    [SerializeField] GameObject[] _rota;

    // 回転用のクラスのメモリを確保
    private TurnGraph[] _rotaGraph = new TurnGraph[19];

    // 判定用.
    [SerializeField] GameObject[] _coll;

    // クリア後のライトを調整
    private GameObject _light;

    // 回転するオブジェクトの最大数.
    public int _objRotaMaxNum;

    // 謎解きがとけたかどうか.
    private bool _isClear = false;

    // 回路が正しい場合のカウント.
    private int _ansFrameCount = 0;

    // クリア後のカウント
    private int _clearFrameCount = 0;

    // クリア後カメラの位置を移動させる.
    private CinemachineVirtualCamera _camera;

    // クリア後カメラの位置をターゲット位置
    private GameObject _cameraData;
    private Transform _cameraPos;

    // クリア後のカメラ角度
    public float _clearCameraRotaY;
    public float _clearCameraRotaX;

    // ライトが光るかどうか
    private bool _isLight = false;

    void Start()
    {
        // ボタン用.
        _botton = GameObject.Find("GameManager2");

        // 回転する回路のクラス
        for (int i = 0; i < _objRotaMaxNum; i++)
        {
            _rotaGraph[i] = _rota[i].GetComponent<TurnGraph>();
        }

        // カメラ関連
        {
            // カメラオブジェクトを取得
            _camera = GameObject.Find("3DPlayerCamer").GetComponent<CinemachineVirtualCamera>();

            // カメラ用の位置データを取得
            _cameraData = GameObject.Find("AnsPos1");
            _cameraPos = _cameraData.transform;
        }
    }

    void Update()
    {
        // ゲームクリアした場合ライトが光るので
        // 光ってない場合はプレイヤーを追跡する
        // 光ってる場合はカメラはクリア用の位置に行く
        if(!_isLight)
        {
            _camera.Follow = GameObject.Find("3DPlayer").transform;
        }
        else
        {
            // カメラのターゲット位置と角度を変更
            _camera.Follow = _cameraPos;
            _camera.GetCinemachineComponent(CinemachineCore.Stage.Aim).GetComponent<CinemachinePOV>().m_VerticalAxis.Value   = _clearCameraRotaY;
            _camera.GetCinemachineComponent(CinemachineCore.Stage.Aim).GetComponent<CinemachinePOV>().m_HorizontalAxis.Value = _clearCameraRotaX;
        }

        for (int i = 0; i < _objRotaMaxNum; i++)
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
            if (!_rotaGraph[i].IsGetAns())
            {
                _ansFrameCount = 0;
                break;
            }
            else
            {
                // 最大値まで到達するとカウントを行わない.
                if (_ansFrameCount < _objRotaMaxNum)
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
            _isLight = true;

            // 一定数カウントが値を御超えると.
            if (_clearFrameCount > ClearCountMaxFrame)
            {
                // クリアした場合のフラグを立てる
                _isClear = true;
            }
        }
    }

    // クリアしたかどうか.
    public bool GetResult()
    {
        return _isClear;
    }

    // ライトを光らせるかどうか
    public bool IsLight()
    {
        return _isLight;
    }
}
