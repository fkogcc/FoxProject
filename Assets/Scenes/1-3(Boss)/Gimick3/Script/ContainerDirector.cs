using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerDirector : MonoBehaviour
{
    // ギミックの管理に使用.
    [SerializeField] private List< bool> _gimickClears = new List<bool>();
    //[SerializeField] private Dictionary<int, bool> _gimickClears = new Dictionary<int, bool>();
    [SerializeField] private Dictionary<int, Dictionary<string,bool>> _gimickClear = new Dictionary<int, Dictionary<string, bool>>();
    // ギミックの名前を取得する用の配列.
    [SerializeField] private GameObject[] _gimickName = new GameObject[0];
    //バリケードを取得.
    GameObject _Barricade;
    //クリア数カウント.
    public static string _getName;
    public static bool _isColl; 
    //クリアに必要なカウント数.
    //private int _Maxcount = 8;
    //Stage2に行くためのカウント.
    private int _stage2_Count = 4;
    // 一回クリア判定.
    private bool _isStage1Flag = false;
    // 全てクリアしているかのフラグ.
    private bool _isAllClear;

    // Start is called before the first frame update
    void Start()
    {
        //_getName = 0;
        _Barricade = GameObject.Find("Barricade");
        _isAllClear= false;
        GetGimickName();
    }
    // ギミックの名前を取得.
    // ギミックの正誤を初期化.
    private void GetGimickName()
    {
        for (int i = 0; i < _gimickName.Length; i++)
        {
            _gimickClears.Add(false);
            //_gimickClears.Add(i, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 箱が置かれているかどうかチェックする.
        GimickClearCheck();
        // ステージ2にいくときにバリケードを壊す.
        if (_isStage1Flag)
        {
            Destroy(_Barricade);
        }

        // クリア判定.
        _isAllClear = IsGimickAllClear();
    }
    // ギミックのクリア判定のチェック
    private void GimickClearCheck()
    {
        for (int i = 0; i < _gimickClears.Count; i++)
        {
            if (_gimickName[i].name == _getName)
            {
                _gimickClears[i] = _isColl;
            }
        }
    }
    //// ギミックの情報の取得をする.
    //public void SetGimickDate(string name,bool iscol)
    //{

    //}
    // ギミックをクリアしたかどうか.
    private bool IsGimickAllClear()
    {
        for (int i = 0; i < _gimickClears.Count; i++)
        {
            if (_gimickClears[i] == false)
            {
                return false;
            }
            // ステージ1をクリアした(0の分をカウントするために1つたす).
            if (i + 1 >= _stage2_Count)
            {
                _isStage1Flag = true;
            }
        }
        return true;
    }
    // クリア判定.
    public bool GetResult()
    {
        return _isAllClear;
    }
}
