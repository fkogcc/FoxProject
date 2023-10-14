// ���̏���.
// HACK:���̉�]�����������ƃX�}�[�g�ɂł�����.

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GimmickBirdge : MonoBehaviour
{
    public static GimmickBirdge _instance;

    private GimmickManager1_1 _manager;

    // ���̒ʘH.
    // ��.
    [SerializeField] private GameObject _birdgeLeft;
    // �E.
    [SerializeField] private GameObject _birdgeRight;

    // ���ɂ���G
    [SerializeField] private GameObject _birdgeEnemy;

    // �J����
    private Camera _camera;

    // �M�~�b�N���쓮�����ǂ���
    private bool _isOperationGimmick;
    // �M�~�b�N����������ɓG���������ǂ���
    private bool _isMoveEnemy = false;

    private void Awake()
    {
        if( _instance == null )
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _camera = GameObject.Find("Camera").GetComponent<Camera>();
        _manager = GameObject.Find("GimmickManager").GetComponent<GimmickManager1_1>();
    }

    private void FixedUpdate()
    {
        _isOperationGimmick = _manager.GetSolveGimmick(0);
    }

    // ���������鏈��.
    public void UpdateBirdgeAisle()
    {
        // �G�̓���
        MoveEnemy();

        // �����˂���ƈȍ~�������Ȃ�.
        if (_birdgeLeft.transform.localEulerAngles == new Vector3(0.0f, 0.0f, 0.0f) ||
           _birdgeRight.transform.localEulerAngles == new Vector3(0.0f, 0.0f, 0.0f))
            return;

        

        if (!_isOperationGimmick) return;
        
        // ���̉�].
        RotateBirdgeAisle(_birdgeLeft, new Vector3(0.0f, 0.0f, -1.0f));
        RotateBirdgeAisle(_birdgeRight, new Vector3(0.0f, 0.0f, 1.0f));
        
    }

    // ��x��]���I���Ə�����ʂ��Ȃ�.
    /// <summary>
    /// ���̂킽�镔���̉�].
    /// </summary>
    /// <param name="birdge">��]�����鋴�̃I�u�W�F�N�g</param>
    /// <param name="rotate">��]</param>
    private void RotateBirdgeAisle(GameObject birdge, Vector3 rotate)
    {
        birdge.transform.Rotate(rotate);
        _isMoveEnemy = true;

        if (birdge.transform.localEulerAngles == new Vector3(0.0f, 0.0f, 0.0f))
        {
            _manager._operationGimmick[0] = false;
        }
    }

    // �����˂��������̓G�̈ړ�
    private void MoveEnemy()
    {
        if(!_isMoveEnemy) return;

        if(_birdgeEnemy.transform.position.y <= 50.0f)
        {
            _birdgeEnemy.transform.position += new Vector3(0.1f, 0.1f, 0.0f);
        }
        else
        {
            _birdgeEnemy.SetActive(false);
        }
            
    }
}
