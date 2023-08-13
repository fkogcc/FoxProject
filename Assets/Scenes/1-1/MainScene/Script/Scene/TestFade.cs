using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class TestFade : MonoBehaviour
{
    readonly float waitTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        StartCoroutine(nameof(Transition));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Transition()
    {
        yield return new WaitForSeconds(waitTime);

        Destroy(gameObject);
    }
}
