// ギミックのクリア状況を保存.

using UnityEngine;
using UnityEngine.SceneManagement;

public class StateGimmickSolveSave : MonoBehaviour
{
    private GateFlag _transitionScene;

    private void Start()
    {
        _transitionScene = GameObject.FindWithTag("Player").GetComponent<GateFlag>();
        DontDestroyOnLoad(gameObject);
    }

    private void FixedUpdate()
    {
        if(_transitionScene._isGoal1_3)
        {
            SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());
        }
    }
}
