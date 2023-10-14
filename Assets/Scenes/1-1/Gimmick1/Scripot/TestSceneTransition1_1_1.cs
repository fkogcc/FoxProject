using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestSceneTransition1_1_1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // RBボタンでシーン遷移
        if(Input.GetKeyDown("joystick button 5"))
        {
            //GimmickManager1_1._operationGimmick[0] = true;
            SceneManager.LoadScene("MainScene1-1");
        }
    }
}
