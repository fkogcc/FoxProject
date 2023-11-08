using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player3D : MonoBehaviour
{
    // カメラ.
    private GameObject _camera;

    private PlayerAnim3D _anim3D;
    private Animator _animator;
    private Rigidbody _rigidbody;

    private Transform _transform;

    private BoxCollider _collider;

    // 着地しているかどうか.
    private bool _isGround;

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
    

    void Start()
    {
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

        if (!_isController) return;
        MoveDirection();
        Jump();
        Anim();
        FallDebug();
    }

    private void FixedUpdate()
    {
        _SphereCastCenterPosition = 
            new Vector3(transform.position.x, 
            transform.position.y + _SphereCastRegulationY, 
            transform.position.z);

        //Debug.Log(IsGroundShpere());

        //Debug.DrawRay(ray.origin, ray.direction * distance, Color.red); // レイを赤色で表示させる
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if(collision.gameObject.tag == "Stage")
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
        //Gizmos.DrawRay(transform.position + Vector3.up * _rayOffset, Vector3.down * _rayLength);
        //Gizmos.DrawWireSphere(transform.position, 0.1f);
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

    private void MoveDirection()
    {
        // 垂直方向.
        float vertical = Input.GetAxis("Vertical");
        // 水平方向.
        float horizontal = Input.GetAxis("Horizontal");

        //// カメラの向きを基準にした正面方向のベクトル.
        //Vector3 cameraForward = Vector3.Scale(_camera.transform.forward, new Vector3(1.0f, 0.0f, 1.0f)).normalized;

        //// カメラ基準.
        //Vector3 moveZ = _speed * vertical * cameraForward;// 前後.
        //Vector3 moveX = _camera.transform.right * horizontal * _speed;// 左右.

        

        //vector.x = horizontal * _speed;
        //vector.z = vertical * _speed;

        //_moveDirection = moveZ + moveX/* + new Vector3(0.0f, 0.0f, 0.0f)*/;

        

        //_transform.rotation = Quaternion.Euler(0.0f, _transform.rotation.y, 0.0f);

        //_rigidbody.velocity = _moveDirection.normalized * 5;

        //_rigidbody.velocity = new Vector3(_moveDirection.x, 0.0f, _moveDirection.z).normalized * 5;

        //_rigidbody.velocity = new Vector3(_moveDirection.x, Physics.gravity.y, _moveDirection.z);


        //if (_rigidbody.velocity.magnitude <= 5)
        //{
        //    _rigidbody.AddForce(_moveDirection);
        //}


        //if((_rigidbody.velocity.x < 10.0f && _rigidbody.velocity.x > -10.0f) || (_rigidbody.velocity.z < 10.0f && _rigidbody.velocity.z > -10.0f))
        //{
        //    _rigidbody.AddForce(_moveDirection);
        //}

        Vector3 cameraForward = _camera.transform.forward;
        Vector3 cameraRight = _camera.transform.right;
        cameraForward.y = 0.0f;
        cameraRight.y = 0.0f;

        // プレイヤーの回転
        transform.forward = Vector3.Slerp(transform.forward, _moveDirection, Time.deltaTime * 10.0f);

        // カメラの角度によって正面方向を変える
        _moveDirection = _speed * (cameraRight.normalized * horizontal + cameraForward.normalized * vertical);

        // プレイヤーの移動
        _rigidbody.AddForce(_testmove * (_moveDirection - _rigidbody.velocity));

        // 摩擦力の変更
        if (horizontal == 0.0f && vertical == 0.0f && IsGroundShpere() && !Input.GetKeyDown("joystick button 0"))
        {
            _rigidbody.drag = 50.0f;
        }
        else
        {
            _rigidbody.drag = 5.0f;
        }

        //Debug.Log(_rigidbody.velocity);
    }

    // ジャンプ処理
    private void Jump()
    {
        if(Input.GetKeyDown("joystick button 0"))
        {
            if (IsGroundShpere())
            {
                //Debug.Log("通った");
                //_isGround = false;
                _rigidbody.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
            }
        }
    }

    private bool IsGroundLine()
    {
        rayPosition = transform.position + new Vector3(0, 0.5f, 0); // レイを発射する位置の調整
        ray = new Ray(rayPosition, -transform.up); // レイを下に飛ばす
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red); // レイを赤色で表示させる
        if (Physics.Raycast(ray, out hit, distance)) // レイが当たった時の処理
        {
            if (hit.collider.tag == "Stage") // レイが地面に触れたら
            {
                return true; // 地面に触れたことにする
            }
        }

        return false;
    }

    private bool IsGroundShpere()
    {
        Ray ray = new(origin: transform.position + Vector3.up * _rayOffset, direction: Vector3.down);

        // 円キャスト.
        Physics.SphereCast(_SphereCastCenterPosition, _raySphereLength, -transform.up, out hit);

        // 接地距離によってtrue.
        if (hit.distance <= _distanceGround /*&& hit.distance >= 0.0f*/)
        {
            return true;
        }

        // Rayが接地するかどうか.
        // 円
        return false;
    }

    private void Anim()
    {
        _animator.SetBool("Run", _anim3D.Run());
        _animator.SetBool("Jump", _anim3D.Jump());
        _animator.SetBool("isDead", _anim3D.GameOver());
    }
}
