using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCollsion3D : MonoBehaviour
{
    // 判定を取りたいオブジェクトの名前
    public string _objectName;
    // 当たっているかどうか
    private bool _isColliding;


    private void Update()
    {
        _isColliding = false;
    }

    private void OnTriggerStay(Collider other)
    {
        // 指定したオブジェクトに当たったら
        if (other.name == _objectName)
        {
            _isColliding = true;    
        }
    }

    // 判定処理をどうするかを決める
    public void SetHit(bool isHit)
    {
        _isColliding = isHit;
    }

    // 当たっているかどうか
    public bool IsGetHit()
    {
        return _isColliding;
    }


}
