using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlaneManager : MonoBehaviour
{
    // 移動パターン.
    private enum moveNum
    {
        up,
        right,
        down,
        left,
        empty,
    }

    // プレイヤーオブジェクト.
    private GameObject _player;
    // プレイヤーマネージャーオブジェクト.
    private GameObject _planeManager;
    // プレイヤーの角度.
    private float _planeAngle;
    // 緑の床.
    public bool _isExit;
    private bool _isExitHit = false;
    // 青の床.
    public bool _isWall;

    private void Start()
    {
        // オブジェクトの取得.
        _player = GameObject.Find("3DPlayer");
        _planeManager = GameObject.Find("PlaneManager");

        // プレイヤー角度代入
        _planeAngle = this.transform.localEulerAngles.y;
    }

    private void Update()
    {
        if(_isExitHit)
        {
            // ギミックの発動を停止する.
            _planeManager.GetComponent<PlaneBool>().SetMoving(false);
            _planeManager.GetComponent<PlaneBool>().SetAngle(4);
            _isExitHit = false;
        }
    }

    private void FixedUpdate()
    {
        // ギミックのが発動したなら.
        if (_planeManager.GetComponent<PlaneBool>().GetMoving())
        {
            _player.GetComponent<Player3DMove>()._isController = false;
            // プレイヤーの移動パターンを見て.
            // 自動で移動を開始.
            if (_planeManager.GetComponent<PlaneBool>().GetAngle() == (int)moveNum.up)
            {
                _player.transform.position += new Vector3(-0.002f, 0.0f, 0.0f);
            }
            else if (_planeManager.GetComponent<PlaneBool>().GetAngle() == (int)moveNum.right)
            {
                _player.transform.position += new Vector3(0.0f, 0.0f, 0.002f);
            }
            else if (_planeManager.GetComponent<PlaneBool>().GetAngle() == (int)moveNum.down)
            {
                _player.transform.position += new Vector3(0.002f, 0.0f, 0.0f);
            }
            else if (_planeManager.GetComponent<PlaneBool>().GetAngle() == (int)moveNum.left)
            {
                _player.transform.position += new Vector3(0.0f, 0.0f, -0.002f);
            }
        }
        else
        {
            _player.GetComponent<Player3DMove>()._isController = true;
            _planeManager.GetComponent<PlaneBool>().SetAngle(4);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        // ふれているタグがプレイヤーだった場合.
        if (other.gameObject.tag == "Player")
        {
            // 青い床では無かった場合.
            if (!_isWall)
            {
                // 仕掛けを発動するようにする.
                _planeManager.GetComponent<PlaneBool>().SetMoving(true);

                // プレイヤーの角度を見る.
                // 進行方向を決める.
                if (_planeAngle == 0)
                {
                    _planeManager.GetComponent<PlaneBool>().SetAngle((int)moveNum.up);
                }
                else if (_planeAngle == 90)
                {
                    _planeManager.GetComponent<PlaneBool>().SetAngle((int)moveNum.right);
                }
                else if (_planeAngle == 180)
                {
                    _planeManager.GetComponent<PlaneBool>().SetAngle((int)moveNum.down);
                }
                else if (_planeAngle == 270)
                {
                    _planeManager.GetComponent<PlaneBool>().SetAngle((int)moveNum.left);
                }
            }
            else
            {
                _isExitHit = true;
            }
        }
    }

    // 当たっていたオブジェクトから離れた場合.
    private void OnTriggerExit(Collider other)
    {
        // ふれているタグがプレイヤーだった場合.
        if (other.gameObject.tag == "Player")
        {
            // 緑の床だった場合.
            if (_isExit)
            {
                _isExitHit = true;
            }
        }
    }
}


