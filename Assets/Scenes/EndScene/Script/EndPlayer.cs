using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class EndPlayer : MonoBehaviour
{
    private const int kMoveFrame = 50 * 12;
    private const int kWaitFrame = kMoveFrame * 3;
    private const int kLapsNo = 2;

    private Vector3 _startPos;
    private Vector3 _move;
    int _frame;

    int _lapsNum;

    private Quaternion _rot;
    int _rotFrame;


    private void Start()
    {
        _startPos = transform.position;
        _move = new Vector3(-0.1f, 0, 0);
        _frame = 0;
        _lapsNum = 0;
        GetComponent<PlayerAnim>()._run = true;

        float angle = -90.0f / 50.0f;
        _rot = Quaternion.AngleAxis(angle, new Vector3(0, 1, 0));
        _rotFrame = 0;
    }

    public void PlayerUpdate()
    {
        _frame++;

        if (_frame < kMoveFrame)
        {
            if (_lapsNum >= kLapsNo && _frame > kMoveFrame * 0.5f)
            {
                _frame--;

                GetComponent<PlayerAnim>()._run = false;
                GetComponent<PlayerAnim>()._waveHands = true;

                if (_rotFrame < 50)
                {
                    _rotFrame++;

                    transform.rotation = transform.rotation * _rot;
                }
            }
            else
            {
                transform.position += _move;
            }
        }
        else if (_frame < kWaitFrame)
        {
            // 何もしない    
        }
        else
        {
            _lapsNum++;
            _frame = 0;
            transform.position = _startPos;
        }
    }
}
