﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAnimDirector : MonoBehaviour
{
    // フェードキャンバスの取得.
    [SerializeField] private Fade _fade;

    public bool fade = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (fade)
        {
            _fade.FadeIn(1f);
        }
        else
        {
            _fade.FadeOut(1f);
        }
            
    }
}
