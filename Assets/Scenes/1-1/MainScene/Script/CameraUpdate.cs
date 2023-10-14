// 2D�J��������.
// HACK:�}�W�b�N�i���o�[���c���Ă���̂ŉ��Ƃ�����.

using UnityEngine;

public class CameraUpdate : MonoBehaviour
{
    // �J�������ǂ����W.
    private Vector3 _targetPosition;
    // �J�����̑��x
    private Vector3 _velocity = Vector3.zero;
    // �J�������ǂ����W�Ɍ���������.
    [SerializeField] private float _time = 0.2f;

    // �M�~�b�N�̏���
    private GimmickManager1_1 _manager;

    // �M�~�b�N�̍쓮���̃J�����̍��W.
    [SerializeField] private GameObject[] _operationGimmickCameraPosition;

    // �v���C���[�̃Q�[���I�u�W�F�N�g.
    private GameObject _targetPlayer;
    // �J�����̍��W.
    private float _cameraPosX;
    private float _cameraPosY;
    private float _cameraPosZ;
    // �X�e�[�W�[�̃J�����̌Œ���W.
    private float _cameraFixedPositionLeft = 0;
    private float _cameraFixedPositionRight = 160;

    // Start is called before the first frame update
    void Start()
    {
        _manager = GameObject.Find("GimmickManager").GetComponent<GimmickManager1_1>();

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
        if(transform.position.x <= _cameraFixedPositionLeft )
        {
            transform.position = new Vector3(_cameraFixedPositionLeft, (_cameraPosY / 5.0f) + 6.0f, -20.0f);
        }
        else if(transform.position.x >= _cameraFixedPositionRight)
        {
            transform.position = new Vector3(_cameraFixedPositionRight, (_cameraPosY / 5.0f) + 6.0f, -20.0f);
        }

        // �M�~�b�N���쓮���Ă�����J�����𓮂����Ȃ�
        if(!_manager.GetSolveGimmick(0) && !_manager.GetSolveGimmick(1))
        {
            MoveCamera();
        }
        else if(_manager.GetSolveGimmick(0))
        {
            OperationGimmickCamera();
        }
    }

    // �J�����̈ړ�.
    private void MoveCamera()
    {
        transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref _velocity, _time);
    }

    // �M�~�b�N�̍쓮���̂Ƃ��̃J�����̋���.
    private void OperationGimmickCamera()
    {
        transform.position = Vector3.SmoothDamp(transform.position, _operationGimmickCameraPosition[0].transform.position, ref _velocity, _time);
    }
}
