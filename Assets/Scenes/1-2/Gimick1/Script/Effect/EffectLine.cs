using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectLine : MonoBehaviour
{
    [SerializeField] private GameObject Line = default;

    private GameObject[] _effectLine = new GameObject[3];
    [SerializeField] private GameObject[] _lineName;

    private LineRenderer[] _lineRenderer = new LineRenderer[3];

    private List<Vector3>_pointList = new List<Vector3>();
    private bool _isGameClear = false;
    public void LineInit()
    {
        for (int i = 0; i < _lineName.Length; i++)
        {
            // 初期化処理
            _effectLine[i] = Instantiate(Line, this.transform.position,
                                        Quaternion.identity); // 初期化処理
                                                              // LineRenderer取得
            _lineRenderer[i] = _effectLine[i].GetComponent<LineRenderer>();
        }
    }
    private void Regeneration(string name)
    {
        for (int i = 0; i < _lineName.Length; i++)
        {
            if (_lineName[i].name == name)
                // 初期化処理
                _effectLine[i] = Instantiate(Line, this.transform.position,
                                            Quaternion.identity);
            // LineRenderer取得
            _lineRenderer[i] = _effectLine[i].GetComponent<LineRenderer>();
        }
    }
    private void LinePosAdd(Vector3 pos,int linenum)
    {
        _pointList.Add(pos);
        _lineRenderer[linenum].positionCount = _pointList.Count;

        // 各頂点の座標設定
        for (int iCnt = 0; iCnt < _pointList.Count; iCnt++)
        {
            _lineRenderer[linenum].SetPosition(iCnt, _pointList[iCnt]);
        }
    }
    // ラインエフェクトの生成
    public void LineGenerate(Vector3 pos,string name)
    {
        for (int i = 0; i < _lineName.Length; i++)
        {
            if (name == _lineName[i].name)
            {
                LinePosAdd(pos,i);
            }
        }
    }
    public void LineClearGenerete(string name)
    {
        for (int i = 0; i < _lineName.Length; i++)
        {
            if (name == _lineName[i].name)
            {
                if (_lineRenderer[i].positionCount <= 5)
                {
                    LinePosAdd(_pointList[0], i);
                    _pointList.Clear();

                }
            }
        }
    }
    public void LineDestroy(string name)
    {
        for (int i = 0; i < _lineName.Length; i++)
        {
            if (name == _lineName[i].name)
            {
                // 完成していたら消さない
                if (_lineRenderer[i].positionCount <= 5)
                {
                    _pointList.Clear();
                    Destroy(_effectLine[i]);
                    Destroy(_lineRenderer[i]);
                    Regeneration(name);
                }
            }
        }
    }
    public void PosAllErase(string name)
    {
        LineDestroy(name);
    }
    // ラインを最後まで引いたかどうか
    private void LineEndDraw()
    {
        int endCount = 0;
        for (int i = 0; i < _lineName.Length; i++)
        {
            if (_lineRenderer[i].positionCount <= 5)
            {
                endCount++;
            }
        }
        if(endCount < _lineRenderer.Length)
        {
            _isGameClear  = true;
        }
    }
    public bool GetResult()
    {
        return _isGameClear;
    }
}
