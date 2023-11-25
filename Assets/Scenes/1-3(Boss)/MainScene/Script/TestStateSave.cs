using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStateSave : MonoBehaviour
{
    // インスタンスが存在するか.
    static bool _inctanceExit = false;

    private void Awake()
    {
        if (_inctanceExit)
        {
            Destroy(gameObject);

            return;
        }

        _inctanceExit = true;

        DontDestroyOnLoad(gameObject);
    }
}
