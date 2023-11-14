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
        // とりあえず 今の位置に生成！

        // 初期化処理
        _effectLine = Instantiate(Line,this.transform.position,
                                    Quaternion.identity);
        // LineRenderer取得
        _lineRenderer = _effectLine.GetComponent<LineRenderer>();
        
        _pointList.Add(this.transform.position);

        _lineRenderer.positionCount = _pointList.Count;

        // 各頂点の座標設定
        for (int iCnt = 0; iCnt < _pointList.Count; iCnt++)
        {
            _lineRenderer.SetPosition(iCnt, _pointList[iCnt]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
