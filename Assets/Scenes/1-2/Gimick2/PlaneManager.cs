using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneManager: MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        MovePlane2._isMoving = false;//“®‚«‘±‚¯‚éˆ—‚ğ~‚ß‚é
    }
}
