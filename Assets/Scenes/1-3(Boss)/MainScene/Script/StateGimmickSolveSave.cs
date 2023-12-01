// ギミックのクリア状況を保存.

using UnityEngine;
using UnityEngine.SceneManagement;

public class StateGimmickSolveSave : MonoBehaviour
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

        Debug.Log($"{name}");

        DontDestroyOnLoad(gameObject);
    }

    private void FixedUpdate()
    {
        //if(SceneManager.GetActiveScene().name == "ClearScene1-3")
        //{
        //    SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());
        //}
    }
}
