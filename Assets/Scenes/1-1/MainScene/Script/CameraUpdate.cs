// 2Dカメラ処理.
// HACK:マジックナンバーが残っているので何とかする.

using UnityEngine;

public class CameraUpdate : MonoBehaviour
{
    // カメラが追う座標.
    private Vector3 _targetPosition;
    // カメラの速度
    private Vector3 _velocity = Vector3.zero;
    // カメラが追う座標に向かう時間.
    [SerializeField] private float _time = 0.2f;

    // ギミックの処理
    private GimmickManager1_1 _manager;

    // ギミックの作動中のカメラの座標.
    [SerializeField] private GameObject[] _operationGimmickCameraPosition;

    // プレイヤーのゲームオブジェクト.
    private GameObject _targetPlayer;
    // カメラの座標.
    private float _cameraPosX;
    private float _cameraPosY;
    private float _cameraPosZ;
    // ステージ端のカメラの固定座標.
    private float _cameraFixedPositionLeft = 0;
    private float _cameraFixedPositionRight = 160;

    // Start is called before the first frame update
    void Start()
    {
        _manager = GameObject.Find("GimmickManager").GetComponent<GimmickManager1_1>();

        _targetPlayer = GameObject.Find("Foxidle");

        // X,Y座標にプレイヤーの座標を代入
        _cameraPosX = _targetPlayer.transform.position.x;
        _cameraPosY = _targetPlayer.transform.position.y;

        

        _cameraPosZ = -20.0f;
    }

    private void FixedUpdate()
    {
        // カメラの追従.
        // プレイヤーの座標を代入し続ける.
        _cameraPosX = _targetPlayer.transform.position.x;
        _cameraPosY = _targetPlayer.transform.position.y;

        // 向いている方向によってカメラの位置を変更.
        if (!Player2DMove._instance._isDirection)
        {
            _targetPosition = new Vector3(_cameraPosX + 7, (_cameraPosY / 5.0f) + 6.0f, _cameraPosZ);
        }
        else
        {
            _targetPosition = new Vector3(_cameraPosX - 7, (_cameraPosY / 5.0f) + 6.0f, _cameraPosZ);
        }

        // ステージ端に来たらカメラの固定.
        if(transform.position.x <= _cameraFixedPositionLeft )
        {
            transform.position = new Vector3(_cameraFixedPositionLeft, (_cameraPosY / 5.0f) + 6.0f, -20.0f);
        }
        else if(transform.position.x >= _cameraFixedPositionRight)
        {
            transform.position = new Vector3(_cameraFixedPositionRight, (_cameraPosY / 5.0f) + 6.0f, -20.0f);
        }

        // ギミックが作動していたらカメラを動かさない
        if(!_manager.GetSolveGimmick(0) && !_manager.GetSolveGimmick(1))
        {
            MoveCamera();
        }
        else if(_manager.GetSolveGimmick(0))
        {
            OperationGimmickCamera();
        }
    }

    // カメラの移動.
    private void MoveCamera()
    {
        transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref _velocity, _time);
    }

    // ギミックの作動中のときのカメラの挙動.
    private void OperationGimmickCamera()
    {
        transform.position = Vector3.SmoothDamp(transform.position, _operationGimmickCameraPosition[0].transform.position, ref _velocity, _time);
    }
}
