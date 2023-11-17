using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player3DMove : MonoBehaviour
{
    // カメラ.
    private GameObject _camera;

    private GateFlag _transitionScene;

    private PlayerAnim3D _anim3D;
    private Animator _animator;
    private Rigidbody _rigidbody;

    private Transform _transform;

    private BoxCollider _collider;

    // 着地しているかどうか.
    public bool _isGround;

    // 移動スピード.
    [SerializeField] private float _speed = 5;

    // ジャンプ力.
    [SerializeField] private float _jumpPower;

    // 移動方向.
    private Vector3 _moveDirection = Vector3.zero;
    Vector3 vector = Vector3.zero;

    private Ray ray; // 飛ばすレイ
    private float distance = 0.5f; // レイを飛ばす距離
    private RaycastHit hit; // レイが何かに当たった時の情報
    private Vector3 rayPosition; // レイを発射する位置

    // 操作可能かどうか.
    public bool _isController = true;
    // ジャンプ可能かどうか.
    public bool _isJumpController = true;


    [Header("身体にめり込ませるRayの長さ")]
    [SerializeField] private float _rayOffset;

    [Header("円のRayの長さ")]
    [SerializeField] private float _raySphereLength = 0.1f;

    [Header("円のy座標調整")]
    [SerializeField] private float _SphereCastRegulationY = 0;

    // SphereCastの中心座標
    private Vector3 _SphereCastCenterPosition = Vector3.zero;

    [SerializeField] private float _distanceGround;

    [SerializeField] private float _testmove;
    
    float currentGravity = -0.1f;
    void Start()
    {
        _transitionScene = GameObject.Find("3DPlayer").GetComponent<GateFlag>();

        _camera = GameObject.Find("Camera");
        _anim3D = GetComponent<PlayerAnim3D>();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();

        _transform = GetComponent<Transform>();

        _collider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        //print(_isGround);

        if(Input.GetKeyDown("joystick button 3"))
        {
            // ゲートの前にいないときはスキップ.
            if (!_transitionScene.SetGateFlag()) return;

            _isController = false;
        }

        if (!_isController) return;
        MoveDirection();
        if(_isJumpController)
        {
            Jump();
        }
        Anim();
        FallDebug();
    }

    private void FixedUpdate()
    {
        _SphereCastCenterPosition = 
            new Vector3(transform.position.x, 
            transform.position.y + _SphereCastRegulationY, 
            transform.position.z);

        _isGround = IsGroundShpere();

        if(_rigidbody.velocity.y <= -20.0f && IsGroundShpere())
        {
            Debug.Log("通った");
        }

        //Debug.Log(IsGroundShpere());

        //Debug.DrawRay(ray.origin, ray.direction * distance, Color.red); // レイを赤色で表示させる
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag == "Stage" && _rigidbody.velocity.y >= 20.0f)
        //{
        //    _isGround = true;
        //}
    }

    private void OnDrawGizmos()
    {
        // デバッグ表示.
        // 接地.
        // true 緑.
        // false 赤.
        Gizmos.color = IsGroundShpere() ? Color.green : Color.red;
        Gizmos.DrawWireSphere(_SphereCastCenterPosition + -transform.up * (hit.distance), _raySphereLength);
    }


    // 落下時の復帰判定
    private void FallDebug()
    {
        if (this.transform.position.y <= -5.0f)
        {
            this.transform.position = new Vector3(0.0f, 1.0f, 0.0f);
        }
    }


    // 回転を含む移動処理
    private void MoveDirection()
    {
        // 垂直方向.
        float vertical = Input.GetAxis("Vertical");
        // 水平方向.
        float horizontal = Input.GetAxis("Horizontal");

        
        Vector3 cameraForward = _camera.transform.forward;
        Vector3 cameraRight = _camera.transform.right;
        cameraForward.y = 0.0f;
        cameraRight.y = 0.0f;

        float Gravity = 1.1f;

        

        currentGravity *= Gravity;

        if(currentGravity <= -20.0f)
        {
            currentGravity = -20.0f;
        }

        // プレイヤーの回転.
        transform.forward = Vector3.Slerp(transform.forward, _moveDirection, Time.deltaTime * 10.0f);

        // カメラの角度によって正面方向を変える.
        _moveDirection = _speed * (cameraRight.normalized * horizontal + cameraForward.normalized * vertical);

        // プレイヤーの移動.
        _rigidbody.velocity = new Vector3(_moveDirection.x, _rigidbody.velocity.y, _moveDirection.z);

    }

    // ジャンプ処理.
    private void Jump()
    {
        if(Input.GetKeyDown("joystick button 0"))
        {
            if (IsGroundShpere())
            {
                _rigidbody.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
            }
        }
    }

    // Rayが接地するかどうか.
    // 円
    public bool IsGroundShpere()
    {
        Ray ray = new(origin: transform.position + Vector3.up * _rayOffset, direction: Vector3.down);

        // 円キャスト.
        Physics.SphereCast(_SphereCastCenterPosition, _raySphereLength, -transform.up, out hit);

        // 接地距離によってtrue.
        if (hit.distance <= _distanceGround)
        {
            return true;
        }

        
        return false;
    }

    // アニメーションの処理.
    private void Anim()
    {
        _animator.SetBool("Run", _anim3D.Run());
        _animator.SetBool("Jump", _anim3D.Jump());
        _animator.SetBool("Push", _anim3D.Push());
        _animator.SetBool("isDead", _anim3D.GameOver());
    }

    // 操作できるかどうか.
    public bool GetIsMoveActive() { return _isController; }
}
