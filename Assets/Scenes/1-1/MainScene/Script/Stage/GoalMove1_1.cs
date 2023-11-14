using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalMove1_1 : MonoBehaviour
{
    private GameObject _EndPos;
    private GameObject _StartPos;

    [SerializeField] private float _speed = 1;

    // 二点間の距離
    private float _distance;

    // Start is called before the first frame update
    void Start()
    {
        _EndPos = GameObject.Find("EndGoalPos");
        _StartPos = GameObject.Find("StartGoalPos");
        _distance = Vector3.Distance(_StartPos.transform.position, _EndPos.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        float presetLocation = (Time.time * _speed) / _distance;

        transform.position = Vector3.Slerp(_StartPos.transform.position, _EndPos.transform.position, presetLocation);
    }
}
