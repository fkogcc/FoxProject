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
    private bool _isTestNameCheck = false;
    // ボタンの状態を渡すためにオブジェクトを取得.
    private GameObject _playerObject;
    // scriptを取得.
    private PlayerHand _player;
    private GimickButton _button;
    private bool _isAnswer;
    // HACK ほんとにこれはテスト、あとでぜったい変えます、ほんとにまずい
    private string[] _objNameTest;
    private const string _buttonNameTest = "Button";

    // Start is called before the first frame update
    void Start()
    {
        // 初期化処理.
        _buttonName = "";
        _isButtonState = false;
        _num = 0;
        _max = 5;
        _isTestNameCheck = false;
        // オブジェクトを取得.
        _playerObject = GameObject.Find("FoxHand");
        // オブジェクトの中にあるscriptを取得.
        _player = _playerObject.GetComponent<PlayerHand>();
        _isAnswer = false;
        // ObjGetも初期化.
        ObjGetInit();
        _objNameTest = new string[_max];
        // テスト
        _objNameTest[0] = _buttonNameTest + "5";
        _objNameTest[1] = _buttonNameTest + "2";
        _objNameTest[2] = _buttonNameTest + "4";
        _objNameTest[3] = _buttonNameTest + "1";
        _objNameTest[4] = _buttonNameTest + "3";

    }

    // Update is called once per frame
    void Update()
    {
        // ボタンが押されたかどうかを取得する.
        _isButtonState = _player._isButtonState;
        // ボタンが押されていたら.
        if (_isButtonState)
        {
            // ボタンの名前を取得する.
            _buttonName = _player._buttonName;
            // _numが0だったら.
            // (for文だと0のままだと回らないために0番目のみ処理).
            if (_num == 0)
            {
                // 0番目に保存.
                _objGet[_num] = GameObject.Find(_buttonName);
                // 要素を追加.
                _num++;
            }
            // for文で処理を回す.
            for (int obj = 0; obj < _num; obj++)
            {
                // 取得したボタンの名前と今保存しているボタンの名前が一緒だったら.
                if (_objGet[obj].gameObject.name == _buttonName)
                {
                    // もう取得したボタンなので保存しないフラグを立てる.
                    _isTestNameCheck = false;
                    // for文も止める.
                    break;
                }
                // もし一緒じゃなかったら.
                else
                {
                    // 保存するフラグを立てる.
                    _isTestNameCheck = true;
                }
            }
            //　保存するフラグがたっていたら.
            if (_isTestNameCheck)
            {
                // _num番目に要素を保存.
                _objGet[_num] = GameObject.Find(_buttonName);
                _num++;
            }
        }
        else
        {
            _isButtonState = false;
        }

        // 答えと違ったら違うという表示を出す.
        // for文で処理を回す.
        if (_num == _max)
        {
            for (int obj = 0; obj < _max; obj++)
            {
                if (_objGet[obj].name != _objNameTest[obj])
                {
                    _isAnswer = true;
                    Debug.Log("ちがうよ");
                    ObjGetInit();
                    _num = 0;
                    break;
                }
            }
        }

        /////
        // for (int obj = 0; obj < _max; obj++)
        //{
        //    GimickButton test;
        //    test = _objGet[obj].GetComponent<GimickButton>();
        //}
    }
    void FixedUpdate()
    {
        _isAnswer = false;
    }
    private void ObjGetInit()
    {
        for (int obj = 0; obj < _max; obj++)
        {
            GimickButton test;
            //test = _objGet[obj].GetComponent<GimickButton>();
            //_objGet[obj] = GameObject.Find("");
        }
    }
}
