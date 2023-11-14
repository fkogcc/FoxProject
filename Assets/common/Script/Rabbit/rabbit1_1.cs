// ウサギの1-1の演出

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rabbit1_1 : MonoBehaviour
{
    // プレイヤーの情報を取得.
    [SerializeField] private GameObject _player;

    private Player2DMove _move;

    // アニメーション.
    private bool _jumping = false;
    private bool _jumpMoving = false;

    // イベント
    [SerializeField] private bool _isEvent;

    private Animator _animator;

    private int time = 0;

    private int _moveInterval = 0;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _move = _player.GetComponent<Player2DMove>();
    }

    // Update is called once per frame
    void Update()
    {
        

        Anim();

        if(_player.transform.position.x >= 145.0f && time <= 190)
        {
            _move._isMoveActive = false;
            _jumping = true;
            time++;
        }
        else if(time >= 190)
        {
            _jumping = false;
        }

        if(time >= 190 && !_jumping)
        {
            if(transform.localEulerAngles.y >= 100)
            {
                transform.Rotate(0f, -10f, 0f);
            }
            else
            {
                _jumping = true;

                _moveInterval++;

                if(_moveInterval < 60 && _moveInterval > 10)
                {
                    transform.position += new Vector3(0.2f, 0.0f, 0.0f);
                    
                }
                else if(_moveInterval > 90)
                {
                    _moveInterval = 0;
                }
                //transform.position += new Vector3(0.1f, 0.0f, 0.0f);
            }
        }

        if(transform.position.x >= 170)
        {
            _move._isMoveActive = true;
        }

        if(transform.position.x >= 200)
        {
            Destroy(gameObject);
        }

        //Debug.Log(time);
        
    }

    private void Anim()
    {
        _animator.SetBool("Jump", _jumping);
        _animator.SetBool("JumpMove", _jumpMoving);
    }

}
