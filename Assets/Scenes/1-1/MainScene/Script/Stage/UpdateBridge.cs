// ‹´‚Ìˆ—

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateBridge : MonoBehaviour
{
    [SerializeField] private bool _solveGimmick = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // ƒMƒ~ƒbƒN‚ğ‰ğ‚¢‚Ä‚¢‚È‚©‚Á‚½‚çˆ—‚ğ’Ê‚³‚È‚¢.
        if (!_solveGimmick) return;
        SolveGimmickAfter();
    }


    private void SolveGimmickAfter()
    {

    }
}
