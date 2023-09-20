using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionGimmick : MonoBehaviour
{
    ExplosionGimmick _instance;

    [Header("”š•—‚É“–‚½‚Á‚½‚É‚Á”ò‚Ô—Í‚Ì‹­‚³")]
    [SerializeField] private float _blastPower;

    private void Awake()
    {
        // ƒVƒ“ƒOƒ‹ƒgƒ“‚Ìô•¶
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
