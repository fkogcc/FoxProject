using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asibaMove : MonoBehaviour
{
    //秒数を数えるカウント
    int count = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
       
        //Transformを取得
        Transform myTransform = this.transform;

        // 座標を取得
        Vector3 pos = myTransform.position;

        count++;

        //5秒経ったら
        if(count < 250)
        {
            // z座標へ0.1減算
            pos.z -= 0.04f;    
            // 座標を設定
            myTransform.position = pos;  
        }
        //10秒経ったら
        else if (count < 500)
        {
            // z座標へ0.01加算
            pos.z += 0.04f;
            // 座標を設定
            myTransform.position = pos;  
        }
        //それ以上になったら
        else 
        {
            //カウントを初期化する
            count = 0;
        }
        


    }
}
