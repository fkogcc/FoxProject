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
    /// <param name="isOperationGimmick">�M�~�b�N�𓮂����̂��ǂ���</param>
    public void UpdateBirdgeAisle(bool isOperationGimmick)
    {
        // �����˂���ƈȍ~�������Ȃ�.
        if (_birdgeLeft.transform.localEulerAngles == new Vector3(0.0f, 0.0f, 0.0f) ||
           _birdgeRight.transform.localEulerAngles == new Vector3(0.0f, 0.0f, 0.0f))
            return;

        Debug.Log(isOperationGimmick);

        if (!isOperationGimmick) return;
        // ���̉�].
        //RotateBirdgeAisleLeft(solveGimmick);
        //RotateBirdgeAisleRight(solveGimmick);

        RotateBirdgeAisle(_birdgeLeft, isOperationGimmick, new Vector3(0.0f, 0.0f, -1.0f));
        RotateBirdgeAisle(_birdgeRight, isOperationGimmick, new Vector3(0.0f, 0.0f, 1.0f));
    }

    // ��x��]���I���Ə�����ʂ��Ȃ�.
    /// <summary>
    /// ���̂킽�镔���̉�].
    /// </summary>
    /// <param name="birdge">��]�����鋴�̃I�u�W�F�N�g</param>
    /// <param name="isOperationGimmick">���삵�Ă��邩�ǂ���</param>
    /// <param name="rotate"></param>
    private void RotateBirdgeAisle(GameObject birdge, bool isOperationGimmick, Vector3 rotate)
    {
        birdge.transform.Rotate(rotate);

        if(birdge.transform.localEulerAngles == new Vector3(0.0f, 0.0f, 0.0f))
        {
            isOperationGimmick = false;
        }
    }
}
