// 2D�J��������.
// HACK:�}�W�b�N�i���o�[���c���Ă���̂ŉ��Ƃ�����.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUpdate : MonoBehaviour
{
    // �J�������ǂ����W.
    private Vector3 _targetPosition;
    // �J�����̑��x
    private Vector3 _velocity = Vector3.zero;
    // �J�������ǂ����W�Ɍ���������.
    [SerializeField] private float _time = 0.2f;

    // �v���C���[�̃Q�[���I�u�W�F�N�g.
    private GameObject _targetPlayer;
    // �J�����̃|�W�V����.
    private float _cameraPosX;
    private float _cameraPosY;
    private float _cameraPosZ;

    // Start is called before the first frame update
    void Start()
    {
        _targetPlayer = GameObject.Find("Foxidle");

        // X,Y���W�Ƀv���C���[�̍��W����
        _cameraPosX = _targetPlayer.transform.position.x;
        _cameraPosY = _targetPlayer.transform.position.y;

        _cameraPosZ = -20.0f;
    }

    private void FixedUpdate()
    {
        // �J�����̒Ǐ].
        // �v���C���[�̍��W������������.
        _cameraPosX = _targetPlayer.transform.position.x;
        _cameraPosY = _targetPlayer.transform.position.y;

        // �����Ă�������ɂ���ăJ�����̈ʒu��ύX.
        if (!Player2DMove._instance._isDirection)
        {
            _targetPosition = new Vector3(_cameraPosX + 7, (_cameraPosY / 5.0f) + 6.0f, _cameraPosZ);
        }
        else
        {
            _targetPosition = new Vector3(_cameraPosX - 7, (_cameraPosY / 5.0f) + 6.0f, _cameraPosZ);
        }

        // �X�e�[�W�[�ɗ�����J�����̌Œ�.
        if(transform.position.x <= 0.0f || transform.position.x >= 160.0f)
        {
            transform.position = new Vector3(0, (_cameraPosY / 5.0f) + 6.0f, -20.0f);
        }
        

        MoveCamera();


    }

    // �f�o�b�O�p�J�����|�W�V����.
    private void DebugCameraPos()
    {
        float playerPosX = _targetPlayer.transform.position.x;
        float playerPosY = _targetPlayer.transform.position.y;
        transform.position = new Vector3(playerPosX + 7, (playerPosY / 5.0f) + 6.0f, _cameraPosZ);
    }

    // �J�����̈ړ�.
    private void MoveCamera()
    {
        // �ړ�.
        transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref _velocity, _time);
    }
}
