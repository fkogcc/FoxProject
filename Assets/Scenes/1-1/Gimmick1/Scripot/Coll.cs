using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coll : MonoBehaviour
{
    bool _isHit = false;
    bool _isItemGet = false;
    GameObject _playerObj;
    private void Start()
    {
        _playerObj = GameObject.Find("fox");
    }

    private void Update()
    {
        if (_isHit)
        {
            //Debug.Log("”ÍˆÍ“à");
            _isHit = false;
        }

        if(Input.GetKey("a"))
        {
            //Debug.Log("‰Ÿ‚µ‚Ä‚Ü‚·");
            _isItemGet = true;  
        }

        if(_isItemGet)
        {
            this.transform.position = _playerObj.transform.position;
        }

    }
    void OnTriggerStay(Collider collision)
    {
        
      
        if (collision.tag == "Player")
        {
            _isHit = true;
        }
        else
        {
            Debug.Log(collision.gameObject.name); // ‚Ô‚Â‚©‚Á‚½‘ŠŽè‚Ì–¼‘O‚ðŽæ“¾
            //Debug.Log("“–‚½‚Á‚½");
        }
    }
}
