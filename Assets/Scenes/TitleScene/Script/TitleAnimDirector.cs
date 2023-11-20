using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAnimDirector : MonoBehaviour
{
    // プレイヤーのアニメ
    public TitleAnimePlayer PlayerAnim;


    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerAnim.Update();
    }
}
