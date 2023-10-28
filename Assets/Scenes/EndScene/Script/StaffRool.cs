using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaffRool : MonoBehaviour
{
    public GameObject _credits;
    Vector3 _vec;

    private void Start()
    {
        _vec = new Vector3(0, 1f, 0);
    }

    private void FixedUpdate()
    {
        _credits.GetComponent<RectTransform>().localPosition += _vec;
    }
}
