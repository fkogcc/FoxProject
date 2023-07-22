using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaffoldMove : MonoBehaviour
{
    float _top;
    float _bottom;
    float _speed = 0.05f;
    float _exchange = 0.05f;
    

    // Start is called before the first frame update
    void Start()
    {
        _top = gameObject.transform.position.y + 3.0f;
        _bottom = gameObject.transform.position.y - 3.0f;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(gameObject.transform.position.y > _top)
        {
            _exchange = -_speed;
        }

        if(gameObject.transform.position.y < _bottom)
        {
            _exchange = _speed;
        }

        gameObject.transform.Translate(0, _exchange, 0);
    }

    
}
