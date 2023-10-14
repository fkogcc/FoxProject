// ‹´‚Ìˆ—.
// HACK:‹´‚Ì‰ñ“]ˆ—‚ğ‚à‚Á‚ÆƒXƒ}[ƒg‚É‚Å‚«‚»‚¤.

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GimmickBirdge : MonoBehaviour
{
    public static GimmickBirdge _instance;

    private GimmickManager1_1 _manager;

    // ‹´‚Ì’Ê˜H.
    // ¶.
    [SerializeField] private GameObject _birdgeLeft;
    // ‰E.
    [SerializeField] private GameObject _birdgeRight;

    // ‹´‚É‚¢‚é“G
    [SerializeField] private GameObject _birdgeEnemy;

    // ƒJƒƒ‰
    private Camera _camera;

    // ƒMƒ~ƒbƒN‚ªì“®’†‚©‚Ç‚¤‚©
    private bool _isOperationGimmick;
    // ƒMƒ~ƒbƒN‚ª“®‚¢‚½Œã‚É“G‚ª“®‚­‚©‚Ç‚¤‚©
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

    // ‹´‚ª‚©‚©‚éˆ—.
    public void UpdateBirdgeAisle()
    {
        // “G‚Ì“®‚«
        MoveEnemy();

        // ‹´‚ª‰Ë‚©‚é‚ÆˆÈ~ˆ—‚µ‚È‚¢.
        if (_birdgeLeft.transform.localEulerAngles == new Vector3(0.0f, 0.0f, 0.0f) ||
           _birdgeRight.transform.localEulerAngles == new Vector3(0.0f, 0.0f, 0.0f))
            return;

        

        if (!_isOperationGimmick) return;
        
        // ‹´‚Ì‰ñ“].
        RotateBirdgeAisle(_birdgeLeft, new Vector3(0.0f, 0.0f, -1.0f));
        RotateBirdgeAisle(_birdgeRight, new Vector3(0.0f, 0.0f, 1.0f));
        
    }

    // ˆê“x‰ñ“]‚µI‚í‚é‚Æˆ—‚ğ’Ê‚³‚È‚¢.
    /// <summary>
    /// ‹´‚Ì‚í‚½‚é•”•ª‚Ì‰ñ“].
    /// </summary>
    /// <param name="birdge">‰ñ“]‚³‚¹‚é‹´‚ÌƒIƒuƒWƒFƒNƒg</param>
    /// <param name="rotate">‰ñ“]</param>
    private void RotateBirdgeAisle(GameObject birdge, Vector3 rotate)
    {
        birdge.transform.Rotate(rotate);
        _isMoveEnemy = true;

        if (birdge.transform.localEulerAngles == new Vector3(0.0f, 0.0f, 0.0f))
        {
            _manager._operationGimmick[0] = false;
        }
    }

    // ‹´‚ª‰Ë‚©‚Á‚½‚Ì“G‚ÌˆÚ“®
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
