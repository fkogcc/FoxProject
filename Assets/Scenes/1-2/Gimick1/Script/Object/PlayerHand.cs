using UnityEngine;
// プレイヤーの手の管理スクリプト.
public class PlayerHand : MonoBehaviour
{
    // 手の移動速度.
    private float _speed;
    // 移動スピード.
    private float _moveSpeed;
    // ボタンの名前を入れる用の変数.
    private string _buttonName;
    // ボタンの状態を入れるフラグ.
    private bool _isButtonState;
    // プレイヤーの手が判定内にいるかどうかを返すフラグ.
    private bool _isCollision;

    // 初期化処理.
    void Start()
    {
        // 初期化処理.
        _speed = 2.5f;
        _moveSpeed = _speed * Time.deltaTime;
        _isButtonState = false;
        _isCollision = false;
    }

    // プレイヤーの手の移動処理.
    public void MovePlayerHand()
    {
        // 手を動かす用の処理.
        if (Input.GetAxis("Vertical") > 0)
        {
            // 上.
            transform.position += transform.up * _moveSpeed;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            // 下.
            transform.position -= transform.up * _moveSpeed;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            // 右.
            transform.position += transform.right * _moveSpeed;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            // 左.
            transform.position -= transform.right * _moveSpeed;
        }
    }
    // ボタンを押した処理.
    public void ButtonPush()
    {
        // プレイヤーの手が判定内にいて、ボタンを押されたら.
        if (_isCollision && Input.GetKeyDown("joystick button 1"))
        {
            // ボタンが押されたフラグを返す.
            _isButtonState = true;
        }
        // 条件に当てはまらなかったら.
        else
        {
            // ボタンのフラグをfalseで返す.
            _isButtonState = false;
        }
    }
    // ボタンを押したフラグ.
    public bool IsGetButtonState()
    {
        return _isButtonState;
    }
    // ボタンの名前を取得する.
    public string IsGetButtonName()
    {
        return _buttonName;
    }
    // 現在の手の位置を取得する.
    public Vector3 PlayerHandPos()
    {
        Vector3 pos = this.transform.position;
        return pos;
    }
    // ボタンを押せる判定内にいるかどうか.
    void OnTriggerEnter(Collider other)
    {
        // プレイヤーがコライダーに入ったとき.
        if (other.tag == "Button")
        {
            // 判定内にいるというフラグを返す.
            _isCollision = true;
            // 今触れているボタンを取得する
            _buttonName = other.gameObject.name;
        }
    }
    // ボタンを押せる判定外に出たかどうか.
    void OnTriggerExit(Collider other)
    {
        // プレイヤーがコライダーから出たとき.
        if (other.tag == "Button")
        {
            // 判定外にいるというフラグを返す.
            _isCollision = false;
        }
    }
}
