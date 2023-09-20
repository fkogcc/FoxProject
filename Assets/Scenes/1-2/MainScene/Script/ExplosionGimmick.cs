using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionGimmick : MonoBehaviour
{
    ExplosionGimmick _instance;

    [Header("爆風に当たった時に吹っ飛ぶ力の強さ")]
    [SerializeField] private float _blastPower;

    private void Awake()
    {
        // シングルトンの呪文
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
