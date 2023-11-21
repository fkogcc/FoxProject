using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaffRool : MonoBehaviour
{
    // エンドが真ん中あたりにいるフレーム
    private const int kframe = 3750;

    public GameObject _credits;
    Vector3 _vec;

    int _frame = 0;

    private void Start()
    {
        _vec = new Vector3(0, 1f, 0);
    }

    private void FixedUpdate()
    {
        _credits.GetComponent<RectTransform>().localPosition += _vec;
        _frame++;
        Debug.Log(_frame);
    }
}
