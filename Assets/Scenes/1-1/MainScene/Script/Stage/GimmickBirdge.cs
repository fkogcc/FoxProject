// ���̏���.
// HACK:���̉�]�����������ƃX�}�[�g�ɂł�����.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickBirdge : MonoBehaviour
{
    public static GimmickBirdge _instance;

    // ���̒ʘH.
    // ��.
    [SerializeField] private GameObject _birdgeLeft;
    // �E.
    [SerializeField] private GameObject _birdgeRight;

    // �J����
    private Camera _camera;

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
    }

    private void CameraWork()
    {

    }

    /// <summary>
    /// ���������鏈��.
    /// </summary>
    /// <param name="solveGimmick">�M�~�b�N�����������ǂ���</param>
    public void UpdateBirdgeAisle(bool solveGimmick)
    {
        // �����˂���ƈȍ~�������Ȃ�.
        if (_birdgeLeft.transform.localEulerAngles == new Vector3(0.0f, 0.0f, 0.0f) ||
           _birdgeRight.transform.localEulerAngles == new Vector3(0.0f, 0.0f, 0.0f))
            return;

        if (!solveGimmick) return;
        // ���̉�].
        RotateBirdgeAisleLeft(solveGimmick);
        RotateBirdgeAisleRight(solveGimmick);
    }

    // ���킽�镔���̂̉�].
    // ��x��]���I����Ə������s��Ȃ�.
    // ��.
    private void RotateBirdgeAisleLeft(bool solveGimmick)
    {
        _birdgeLeft.transform.Rotate(0,0,-1);

        if(_birdgeLeft.transform.localEulerAngles  == new Vector3(0.0f,0.0f,0.0f))
        {
            solveGimmick = false;
        }
    }

    // �E.
    private void RotateBirdgeAisleRight(bool solveGimmick)
    {
        _birdgeRight.transform.Rotate(0, 0, 1);

        if (_birdgeRight.transform.localEulerAngles == new Vector3(0.0f, 0.0f, 0.0f))
        {
            solveGimmick = false;
        }
    }
}
