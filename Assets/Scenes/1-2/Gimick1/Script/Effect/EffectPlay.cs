using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPlay : MonoBehaviour
{
    public GameObject _tapEffect;
    private GameObject _handObject;
    private void Start()
    {
        _handObject = GameObject.Find("FoxHand");
    }

    private void Update()
    {
        //タップ時
        CheckTap();
    }

    private void CheckTap()
    {
        if (_handObject.GetComponent<PlayerHand>().IsGetButtonState())
        {
            NewTapEffect(_handObject.GetComponent<PlayerHand>().PlayerHandPos());
        }
    }
    //タップエフェクトを出す
    private void NewTapEffect(Vector3 pos)
    {
        Object.Instantiate(_tapEffect, pos, Quaternion.identity, transform);
    }
}
