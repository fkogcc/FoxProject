using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonState : MonoBehaviour
{
    // ボタンの押した状態を保存するためにSerializeFieldで管理する.
    [SerializeField] private GameObject[] _objGet;
    // 押したボタンの名前を取得する.
    private string _buttonName;
    // ボタンの状態(ボタンが押されたかどうか)を取得する.
    private bool _isButtonState = false;
    // 配列を管理するために用意.
    private int _num;
    // 配列の最大値.
    private int _max;
    // 名前をチェックするために用意.
    private bool _isNameCheck = false;
    // ボタンの状態を渡すためにオブジェクトを取得.
    private GameObject _playerObject;
    // .
    private GimickButton[] _button;
    // HACK ほんとにこれはテスト、あとでぜったい変えます、ほんとにまずい.
    private string[] _objNameTest;
    private const string _buttonNameTest = "FrontButton";

    private bool _isEffectResetFlag = false;
    private bool _isGameClear = false;
    // Start is called before the first frame update
    void Start()
    {
        // 初期化処理.
        _buttonName = "";
        _isButtonState = false;
        _num = 0;
        _max = 5;
        _isNameCheck = false;

        // 配列の最大数を定義.
        _objNameTest = new string[_max];
        _button = new GimickButton[_max];
        // テスト.
        _objNameTest[0] = _buttonNameTest + "5";
        _objNameTest[1] = _buttonNameTest + "2";
        _objNameTest[2] = _buttonNameTest + "4";
        _objNameTest[3] = _buttonNameTest + "1";
        _objNameTest[4] = _buttonNameTest + "3";

    }
    public void GetPlayerObject(GameObject handobj)
    {
        // オブジェクトを取得.
        _playerObject = handobj;
    }
    public void ButtonAcquisition()
    {
        _isEffectResetFlag = false;

        // ボタンが押されたかどうかを取得する.
        _isButtonState = _playerObject.GetComponent<PlayerHand>().IsGetButtonState();
        // ボタンが押されていたら.
        if (_isButtonState)
        {
            // ボタンの名前を取得する.
            _buttonName = _playerObject.GetComponent<PlayerHand>().IsGetButtonName();
            // _numが0だったら.
            // (for文だと0のままだと回らないために0番目のみ処理).
            if (_num == 0)
            {
                // 0番目に保存.
                _objGet[_num] = GameObject.Find(_buttonName);
                _isNameCheck = true;
            }
            // for文で処理を回す.
            for (int obj = 0; obj < _num; obj++)
            {
                Debug.Log(obj);
                // 取得したボタンの名前と今保存しているボタンの名前が一緒だったら.
                if (_objGet[obj].gameObject.name == _buttonName)
                {
                    // もう取得したボタンなので保存しないフラグを立てる.
                    _isNameCheck = false;
                    // for文も止める.
                    break;
                }
                // もし一緒じゃなかったら.
                else
                {
                    // 保存するフラグを立てる.
                    _isNameCheck = true;
                }
            }
            //　保存するフラグがたっていたら.
            if (_isNameCheck)
            {
                // _num番目に要素を保存.
                _objGet[_num] = GameObject.Find(_buttonName);
                _num++;
            }
        }
        else
        {
            _isButtonState = false;
            _isNameCheck = false ;
        }

        // 答えと違ったら違うという表示を出す.
        // for文で処理を回す.
        if (_num == _max && isCheckColor())
        {
            for (int obj = 0; obj < _max; obj++)
            {
                if (_objGet[obj].name != _objNameTest[obj])
                {
                    // 取得したボタンを初期化する.
                    ObjGetInit();
                    _num = 0;
                    _isEffectResetFlag = true;
                    break;
                }
                // 最後まで間違いがなかった場合
                else if(obj == _max - 1)
                {
                    Debug.Log("クリア");
                    //_isGameClear = true;
                }
            }

        }
    }
    // 取得したオブジェクト(ボタン)の情報を初期化する.
    private void ObjGetInit()
    {
        for (int obj = 0; obj < _max; obj++)
        {
            // 初期化する際に色も元に戻す.
            _button[obj].ChengeColor(true);
            // None(何も入っていない状態)にする.
            _objGet[obj] = GameObject.Find("");
            // ここのフラグをfalseにしておかないとずっと白色のままになってしまう.
            _button[obj].ChengeColor(false);
        }
    }
    // ボタンの色チェック
    private bool isCheckColor()
    {
        for (int obj = 0; obj < _max; obj++)
        {
            // ボタンの情報をここで取得する.
            _button[obj] = _objGet[obj].GetComponent<GimickButton>();
            // ひとつでもボタンの色が緑ではなかったら押し終わってないことになるのでチェックする.
            if(_button[obj].IsCheckColor() != Color.green)
            {
                return false;
            }
        }
        return true;
    }
    public bool isCheckButton()
    {
        Debug.Log(_isNameCheck);
        return _isNameCheck;
    }
    public bool IsResetFlag()
    {
        return _isEffectResetFlag;
    }
    public bool GetResult()
    {
        return _isGameClear;
    }
}
