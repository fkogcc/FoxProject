using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlaneManager : MonoBehaviour
{
    private enum moveNum
    {
        up,
        right,
        down,
        left,
        empty,
    }
    private GameObject _player;//メインプレイヤーをいれる変数
    private GameObject _planeManager;//移動処理をまとめるスクリプトを入れているオブジェクトを入れる変数
    private int _moveAngle;//板を踏んだ時の動きの方向を決める変数
    private float _planeAngle;//板がどの方向を向いてるかを決める変数
    public bool _isPanelColor;//動き続けるパネルかそうでないかを判断する変数
    public bool _isWall;//壁かどうかを判断する変数
    private int _lastCol;//板の処理をいくつ動かしているか判断する変数

    private void Start()
    {
        _player = GameObject.Find("3DPlayer");//メインプレイヤーを代入する
        _planeManager = GameObject.Find("PlaneManager");//移動処理をまとめているオブジェクトをいれる
        _planeAngle = this.transform.localEulerAngles.y;//板の向きを代入する

    }
    private void FixedUpdate()
    {
        Debug.Log(_planeManager.GetComponent<PlaneBool>().GetLastCol());
        if (_planeManager.GetComponent<PlaneBool>().GetMoving())//板の処理を動かすかどうかの判断
        {
            if (_planeManager.GetComponent<PlaneBool>().GetAngle() == (int)moveNum.up)//板が上を向いている場合
            {
                _player.transform.position += new Vector3(-0.002f, 0.0f, 0.0f);
            }
            else if (_planeManager.GetComponent<PlaneBool>().GetAngle() == (int)moveNum.right)//板が右を向いている場合
            {
                _player.transform.position += new Vector3(0.0f, 0.0f, 0.002f);
            }
            else if (_planeManager.GetComponent<PlaneBool>().GetAngle() == (int)moveNum.down)//板が下を向いている場合
            {
                _player.transform.position += new Vector3(0.002f, 0.0f, 0.0f);
            }
            else if (_planeManager.GetComponent<PlaneBool>().GetAngle() == (int)moveNum.left)//板が左を向いている場合
            {
                _player.transform.position += new Vector3(0.0f, 0.0f, -0.002f);
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //if(_isPanelColor)
        //{
        //    _planeManager.GetComponent<PlaneBool>().ResetLastCol();
        //    _planeManager.GetComponent<PlaneBool>().SetLastCol(1);
        //}
        if (!_isWall)//壁出なかったら処理を行う
        {
            _planeManager.GetComponent<PlaneBool>().SetLastCol(1);//処理を行っている板の枚数をカウントする
            _planeManager.GetComponent<PlaneBool>().SetMoving(true);//板の処理を行うようにする
            if (_planeAngle == 0)//上
            {
                _planeManager.GetComponent<PlaneBool>().SetAngle((int)moveNum.up);
            }
            else if (_planeAngle == 90)//右
            {
                _planeManager.GetComponent<PlaneBool>().SetAngle((int)moveNum.right);
            }
            else if (_planeAngle == 180)//下
            {
                _planeManager.GetComponent<PlaneBool>().SetAngle((int)moveNum.down);
            }
            else if (_planeAngle == 270)//左
            {
                _planeManager.GetComponent<PlaneBool>().SetAngle((int)moveNum.left);
            }
        }
        else//壁にぶつかった場合の処理
        {
            if (_planeManager.GetComponent<PlaneBool>().GetLastCol() > 0)
            {
                _planeManager.GetComponent<PlaneBool>().ResetLastCol();
            }
            _planeManager.GetComponent<PlaneBool>().SetMoving(false);//板の処理を止める
            _moveAngle = (int)moveNum.empty;//動きの方向をなくす
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (_isPanelColor)//黒色のパネルから出た場合
        {
            if (_planeManager.GetComponent<PlaneBool>().GetLastCol() > 0)//処理を行っている板の枚数が1枚以上だった場合
            {
                _planeManager.GetComponent<PlaneBool>().SetLastCol(-1);//処理を行っている板の枚数を一枚減らす
            }
            if (_planeManager.GetComponent<PlaneBool>().GetLastCol() == 0)//もし処理を行っている枚数がゼロだったら
            {
                _planeManager.GetComponent<PlaneBool>().SetMoving(false);//動きを止める
                _moveAngle = (int)moveNum.empty;//動きの方向をなくす
            }
        }
    }
}


