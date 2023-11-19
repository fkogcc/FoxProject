﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScene : MonoBehaviour
{
    private SolveGimmickManager _manager;
    private GateFlag _flag;
    private Fade3DSceneTransition _sceneTransition;
    private Player3DMove _player;

    // Start is called before the first frame update
    void Start()
    {
        _manager = GameObject.FindWithTag("GimmickManager").GetComponent<SolveGimmickManager>();
        _flag = GameObject.Find("3DPlayer").GetComponent<GateFlag>();
        _sceneTransition = GameObject.Find("Fade").GetComponent<Fade3DSceneTransition>();
        _player = GameObject.FindWithTag("Player").GetComponent<Player3DMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(_manager.GetAllClear())
        {
            _sceneTransition._isPush = true;
            _flag._isGoal1_3 = true;
            _player._isController = false;
        }
    }
}
