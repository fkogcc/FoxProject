using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionGimmick : MonoBehaviour
{
    ExplosionGimmick _instance;

    [Header("�����ɓ����������ɐ�����ԗ͂̋���")]
    [SerializeField] private float _blastPower;

    private void Awake()
    {
        // �V���O���g���̎���
        if( _instance == null )
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
