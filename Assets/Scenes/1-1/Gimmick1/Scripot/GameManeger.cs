using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeger : MonoBehaviour
{
    public bool _isHit;

    // Start is called before the first frame update
    void Start()
    {
        _isHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(_isHit)
        {
            if(Input.GetKey("a"))
            {
                Debug.Log("a");
                this.GetComponent<Rota>().enabled = true;
            }
        }
    }

    void OnTriggerStay(Collider collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("tag");
            _isHit = true;
        }
        else
        {
          //  _isHit = false;
        }
    }
}
