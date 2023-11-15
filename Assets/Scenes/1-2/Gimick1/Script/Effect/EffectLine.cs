using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectLine : MonoBehaviour
{
    [SerializeField] private GameObject Line = default;

    private GameObject _effectLine;

    private LineRenderer _lineRenderer;

    private List<Vector3>_pointList = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        LineInit();
    }
    private void LineInit()
    {
        // 初期化処理
        _effectLine = Instantiate(Line,this.transform.position,
                                    Quaternion.identity);
        // LineRenderer取得
        _lineRenderer = _effectLine.GetComponent<LineRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Generate();

        if (Input.GetKey(KeyCode.Z))
        {
            LineDestroy();
        }

    }
    // ラインエフェクトの生成
    public void LineGenerate(Vector3 pos)
    {
        _pointList.Add(pos);
        _lineRenderer.positionCount = _pointList.Count;

        // 各頂点の座標設定
        for (int iCnt = 0; iCnt < _pointList.Count; iCnt++)
        {
            _lineRenderer.SetPosition(iCnt, _pointList[iCnt]);
        }
    }
    public void LineClearGenerete()
    {
        Vector3 pos = new Vector3(0,0,0);
        _pointList.Add(_pointList[0]);
        _lineRenderer.positionCount = _pointList.Count;

        // 各頂点の座標設定
        for (int iCnt = 0; iCnt < _pointList.Count; iCnt++)
        {
            _lineRenderer.SetPosition(iCnt, _pointList[iCnt]);
        }
    }
    public void LineDestroy()
    {
        _pointList.Clear();
        Destroy(_effectLine);
        Destroy(_lineRenderer);

        LineInit();

    }
}
