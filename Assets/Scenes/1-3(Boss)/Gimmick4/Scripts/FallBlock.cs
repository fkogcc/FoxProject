using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBlock : MonoBehaviour
{
    bool _isFlag;//プレイヤーがブロックに乗ったか判断する
    Vector3 _position;//ブロックの最初のポジション
    Vector3 _moveVec;//ブロックの動く位置
    Vector3 kfallVel = new Vector3(0, -0.1f, 0);//ブロックの落ちる速度
    float kspeed = 0.1f;
    int kfallTime = 50;//板が落ちる時間
    int _frameCount;

    // Start is called before the first frame update
    void Start()
    {
        _frameCount = 0;
        _isFlag = false;
        _position = this.transform.position;
        _moveVec.y = kspeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_isFlag)
        {
            _frameCount++;
            //            _moveVec = _position;

            if (transform.position.y > _position.y + 0.05f)
            {
                _moveVec.y = -kspeed;
            }
            else if (transform.position.y < _position.y -0.05f)
            {
                _moveVec.y = kspeed;
            }
                this.transform.Translate(_moveVec);
        }
        if (_frameCount > kfallTime)
        {
            _isFlag = false;
            transform.Translate(kfallVel);
        }
        if (this.transform.position.y < -3)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            _isFlag = true;
        }
    }
}
