using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteasiba : MonoBehaviour
{

    //足場がプレイヤーに接触したとき.
    private void OnTriggerEnter(Collider other)
    {
        //足場を削除する.
        Destroy(this.gameObject);   
    }
}
