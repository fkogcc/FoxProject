using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public Camera _playerCamera = null;
    public GameObject _avatar = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // ƒvƒŒƒCƒ„[‚ÌŒü‚«‚ð•Ï‚¦‚é
        if(_avatar != null)
        {
            //Vector3 rotateTarget = new Vector3(movement.x,0,movement.z);
            //if(rotateTarget.magnitude >0.1f)
            //{
            //    Quaternion lookRotation = Quaternion.LookRotation(rotateTarget);
            //    _avatar.transform.rotation = Quaternion.Lerp(lookRotation, _avatar.transform.rotation, turnSmoothing);
            //}
        }

    }
}
