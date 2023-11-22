using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class EndPlayer : MonoBehaviour
{
    private const int kMoveFrame = 50 * 12;
    private const int kWaitFrame = kMoveFrame * 3;

    private Vector3 _startPos;
    private Vector3 _move;
    int _frame;

    private void Start()
    {
        _startPos = transform.position;
        _move = new Vector3(-0.1f, 0, 0);
        _frame = kMoveFrame * 2;
        GetComponent<PlayerAnim>()._run = true;
    }

    public void PlayerUpdate()
    {
        _frame++;

        if (_frame < kMoveFrame)
        {
            transform.position += _move;
        }
        else if (_frame < kWaitFrame)
        {
            // 何もしない    
        }
        else
        {
            _frame = 0;
            transform.position = _startPos;
        }
    }
}
