using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteasiba : MonoBehaviour
{

    //‘«ê‚ªƒvƒŒƒCƒ„[‚ÉÚG‚µ‚½‚Æ‚«.
    private void OnTriggerEnter(Collider other)
    {
        //‘«ê‚ğíœ‚·‚é.
        Destroy(this.gameObject);   
    }
}
