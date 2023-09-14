using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    // Žè‚ÌˆÚ“®‘¬“x.
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // HACK ‚Æ‚è‚ ‚¦‚¸Žè‚ð“®‚©‚·—p‚Ìˆ—(Œã‚Å‚à‚Á‚Æ‚¢‚¢•û–@‚É‘‚«’¼‚µ‚½‚¢‚È).
        if (Input.GetAxis("Vertical") > 0)
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            transform.position -= transform.up * speed * Time.deltaTime;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
    }
}
